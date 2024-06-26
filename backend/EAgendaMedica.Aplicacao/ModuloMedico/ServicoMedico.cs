﻿using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloMedico;
using FluentResults;
using FluentValidation;
using Serilog;

namespace EAgendaMedica.Aplicacao.ModuloMedico
{
    public class ServicoMedico : AbstractValidator<Medico>
    {
        private readonly IRepositorioMedico repositorioMedico;

        private readonly IContextoPersistencia contextoPersistencia;
        public ServicoMedico(IRepositorioMedico repositorioMedico, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioMedico = repositorioMedico;
            this.contextoPersistencia = contextoPersistencia;
        }


        public async Task<Result<Medico>> Inserir(Medico medico)
        {
            var resultado = Validar(medico);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioMedico.Inserir(medico);

                await contextoPersistencia.SalvarDados();

                return Result.Ok(medico);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate key value"))
                    Result.Fail("CRM já cadastrado");

                return Result.Fail(ex.Message);
            }

        }

        public async Task<Result<Medico>> Editar(Medico medico)
        {
            try
            {
                var resultado = Validar(medico);

                if (resultado.IsFailed)
                    return Result.Fail(resultado.Errors);

                repositorioMedico.Editar(medico);

                await contextoPersistencia.SalvarDados();

                return Result.Ok(medico);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate key value"))
                    Result.Fail("CRM já cadastrado");

                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result<List<Medico>>> SelecionarTodos()
        {
            var medicos = await repositorioMedico.SelecionarTodos();

            return Result.Ok(medicos);

        }

        public async Task<Result<List<Medico>>> SelecionarPorStatus(bool ativo)
        {
            var medicos = await repositorioMedico.SelecionarPorStatus(ativo);

            return Result.Ok(medicos);

        }

        public async Task<Result<Medico>> SelecionarPorCRM(string CRM)
        {
            var medico = await repositorioMedico.SelecionarPorCRM(CRM);

            if (medico == null)
            {
                Log.Logger.Warning("Médico {MedicoCRM} não encontrado", CRM);

                return Result.Fail("Médico não encontrado");
            }

            return Result.Ok(medico);
        }

        public async Task<Result<Medico>> SelecionarPorId(Guid id)
        {
            var medico = await repositorioMedico.SelecionarPorId(id);

            if (medico == null)
            {
                Log.Logger.Warning("Médico {MedicoId} não encontrado", id);

                return Result.Fail("Médico não encontrado");
            }

            return Result.Ok(medico);
        }

        public async Task<Result<Medico>> Excluir(Medico medico)
        {
            repositorioMedico.Excluir(medico);

            await contextoPersistencia.SalvarDados();

            return Result.Ok();

        }

        public async Task<Result<List<Medico>>> SelecionarTop10(DateTime dataInicial, DateTime dataFinal)
        {
            var medicosComAtendimentos = await repositorioMedico
                .SelecionarMedicosComAtendimentosNoPeriodo(dataInicial, dataFinal);

            var listaOrdenada = medicosComAtendimentos
                .OrderByDescending(x => x.ObterHorasTrabalhadasPorPeriodo(dataInicial, dataFinal)).Take(10).ToList();

            return Result.Ok(listaOrdenada);
        }

        protected virtual Result Validar(Medico obj)
        {
            var validador = new ValidadorMedico();

            var resultadoValidacao = validador.Validate(obj);

            var erros = new List<Error>();

            foreach (var validationFailure in resultadoValidacao.Errors)
            {
                Log.Logger.Warning(validationFailure.ErrorMessage);

                erros.Add(new Error(validationFailure.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}

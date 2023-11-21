﻿using EAgendaMedica.Aplicacao.Compartilhado;
using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloCirurgia;
using FluentResults;
using Serilog;

namespace EAgendaMedica.Aplicacao.ModuloCirurgia
{
    public class ServicoCirurgia : ServicoAtividadeBase<Cirurgia, ValidadorCirurgia>
    {
        private readonly IRepositorioCirurgia repositorioCirurgia;

        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoCirurgia(IRepositorioCirurgia repositorioCirurgia, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCirurgia = repositorioCirurgia;
            this.contextoPersistencia = contextoPersistencia;
        }

        public async Task<Result<Cirurgia>> Inserir(Cirurgia cirurgia)
        {
            var resultado = Validar(cirurgia);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            await repositorioCirurgia.Inserir(cirurgia);

            await contextoPersistencia.SalvarDados();

            return Result.Ok(cirurgia);

        }

        public async Task<Result<Cirurgia>> Editar(Cirurgia cirurgia)
        {
            var resultado = Validar(cirurgia);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            repositorioCirurgia.Editar(cirurgia);

            await contextoPersistencia.SalvarDados();

            return Result.Ok(cirurgia);

        }

        public async Task<Result> Excluir(Cirurgia cirurgia)
        {
            repositorioCirurgia.Excluir(cirurgia);

            await contextoPersistencia.SalvarDados();

            return Result.Ok();
        }

        public async Task<Result<Cirurgia>>SelecionarPorId(Guid id)
        {
            var cirurgia = await repositorioCirurgia.SelecionarPorId(id);

            if (cirurgia == null)
            {
                Log.Logger.Warning("Cirurgia {CirurgiaId} não encontrada", id);

                return Result.Fail("Cirurgia não encontrada");
            }

            return Result.Ok(cirurgia);
        }

        public async Task<Result<List<Cirurgia>>> SelecionarTodos()
        {
            var cirurgias = await repositorioCirurgia.SelecionarTodos();

            return Result.Ok(cirurgias);

        }

        public async Task<Result<List<Cirurgia>>> SelecionarParaHoje()
        {
            var cirurgias = await repositorioCirurgia.SelecionarParaHoje();

            return Result.Ok(cirurgias);

        }

        public async Task<Result<List<Cirurgia>>> SelecionarProximos30Dias()
        {
            var cirurgias = await repositorioCirurgia.SelecionarProximos30Dias();

            return Result.Ok(cirurgias);

        }

        public async Task<Result<List<Cirurgia>>> SelecionarUltimos30Dias()
        {
            var cirurgias = await repositorioCirurgia.SelecionarUltimos30Dias();

            return Result.Ok(cirurgias);

        }

        public async Task<Result<List<Cirurgia>>> SelecionarPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            var cirurgias = await repositorioCirurgia.SelecionarPorPeriodo(dataInicial, dataFinal);

            return Result.Ok(cirurgias);

        }

        public async Task<Result<List<Cirurgia>>> SelecionarCirurgiasporMedico(string CRM)
        {
            var cirurgias = await repositorioCirurgia.ObterCirurgiasPorMedico(CRM);

            return Result.Ok(cirurgias);
        }

    }
}
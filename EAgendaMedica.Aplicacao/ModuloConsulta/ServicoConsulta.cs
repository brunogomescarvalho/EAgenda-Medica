using EAgendaMedica.Aplicacao.Compartilhado;
using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloConsulta;
using FluentResults;
using Serilog;

namespace EAgendaMedica.Aplicacao.ModuloConsulta
{
    public class ServicoConsulta : ServicoAtividadeBase<Consulta, ValidadorConsulta>
    {
        private readonly IRepositorioConsulta repositorioConsulta;

        private readonly IContextoPersistencia contextoPersistencia;
        public ServicoConsulta(IRepositorioConsulta repositorioConsulta, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioConsulta = repositorioConsulta;
            this.contextoPersistencia = contextoPersistencia;
        }


        public async Task<Result<Consulta>> Inserir(Consulta consulta)
        {
            var resultado = Validar(consulta);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            await repositorioConsulta.Inserir(consulta);

            await contextoPersistencia.SalvarDados();

            return Result.Ok(consulta);

        }

        public async Task<Result<Consulta>> Editar(Consulta consulta)
        {
            var resultado = Validar(consulta);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            repositorioConsulta.Editar(consulta);

            await contextoPersistencia.SalvarDados();

            return Result.Ok(consulta);

        }

        public async Task<Result> Excluir(Consulta consulta)
        {
            repositorioConsulta.Excluir(consulta);

            await contextoPersistencia.SalvarDados();

            return Result.Ok();
        }

        public async Task<Result<Consulta>> SelecionarPorId(Guid id)
        {
            var consulta = await repositorioConsulta.SelecionarPorId(id);

            if (consulta == null)
            {
                Log.Logger.Warning("consulta {consultaId} não encontrada", id);

                return Result.Fail("Consulta não encontrada");
            }

            return Result.Ok(consulta);
        }
        public async Task<Result<List<Consulta>>> SelecionarTodos()
        {
            var consultas = await repositorioConsulta.SelecionarTodos();

            return Result.Ok(consultas);

        }

        public async Task<Result<List<Consulta>>> SelecionarParaHoje()
        {
            var consultas = await repositorioConsulta.SelecionarParaHoje();

            return Result.Ok(consultas);

        }

        public async Task<Result<List<Consulta>>> SelecionarProximos30Dias()
        {
            var consultas = await repositorioConsulta.SelecionarProximos30Dias();

            return Result.Ok(consultas);

        }

        public async Task<Result<List<Consulta>>> SelecionarUltimos30Dias()
        {
            var consultas = await repositorioConsulta.SelecionarUltimos30Dias();

            return Result.Ok(consultas);

        }

        public async Task<Result<List<Consulta>>> SelecionarPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            var consultas = await repositorioConsulta.SelecionarPorPeriodo(dataInicial, dataFinal);

            return Result.Ok(consultas);

        }
    }
}

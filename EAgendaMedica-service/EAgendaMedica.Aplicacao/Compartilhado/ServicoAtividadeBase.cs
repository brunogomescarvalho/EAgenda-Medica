using FluentResults;
using FluentValidation;
using Serilog;
namespace EAgendaMedica.Aplicacao.Compartilhado
{

    public abstract class ServicoAtividadeBase<TAtividade, TValidador> where TValidador : AbstractValidator<TAtividade>, new()
    {      
        protected virtual Result Validar(TAtividade obj)
        {
            var validador = new TValidador();

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


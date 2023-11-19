using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.ModuloConsulta
{
    public class ValidadorConsulta : AbstractValidator<Consulta>
    {
        public ValidadorConsulta()
        {
            RuleFor(x => x.Medico).NotNull();

            RuleFor(x => x.DuracaoEmMinutos)
               .LessThan(121)
               .WithMessage("O tempo máximo para uma consulta é de 120 minutos");

            RuleFor(x => x.Medico).Custom(VerificarConflitos);
        }

        private void VerificarConflitos(Medico medico, ValidationContext<Consulta> context)
        {
            var ehValido = context.InstanceToValidate.VerificarDescansoMedico();

            if (ehValido == false)
            {
                context.AddFailure("Existem conflitos no horários da consulta com outros agendamentos do médico");
            }

        }
    }
}

﻿using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.ModuloCirurgia
{
    public class ValidadorCirurgia : AbstractValidator<Cirurgia>
    {
        public ValidadorCirurgia()
        {
            RuleFor(x => x.Medicos).NotEmpty().NotNull()
                .WithMessage("Falha oa incluir médicos. Verifique os dados informados");

            RuleFor(x => x.DuracaoEmMinutos)
               .GreaterThan(119)
               .WithMessage("O tempo mínimo para uma cirurgia é de 120 minutos");

            RuleFor(x => x.Medicos).Custom(VerificarConflitos);
        }

        private void VerificarConflitos(List<Medico> list, ValidationContext<Cirurgia> context)
        {
            var ehValido = context.InstanceToValidate.VerificarDescansoMedico();

            if (ehValido == false)
            {
                context.AddFailure("Existem conflitos no horários da cirurgia com outros agendamentos de algum dos médicos");
            }

        }
    }
}

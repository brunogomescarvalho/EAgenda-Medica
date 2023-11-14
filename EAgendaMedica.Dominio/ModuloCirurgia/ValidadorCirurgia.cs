namespace EAgendaMedica.Dominio.ModuloCirurgia
{
    public class ValidadorCirurgia : AbstractValidator<Cirurgia>
    {
        public ValidadorCirurgia()
        {
            RuleFor(x => x.Medicos).NotEmpty().NotNull();

            RuleFor(x => x.DuracaoEmMinutos)
               .GreaterThan(120)
               .WithMessage("O tempo mínimo para uma cirurgia é de 120 minutos");
        }
    }
}

namespace EAgendaMedica.Dominio.ModuloConsulta
{
    public class ValidadorConsulta : AbstractValidator<Consulta>
    {
        public ValidadorConsulta()
        {
            RuleFor(x => x.Medico).NotNull();

            RuleFor(x => x.DuracaoEmMinutos)
               .LessThan(120)
               .WithMessage("O tempo máximo para uma consulta é de 120 minutos");
              
        }
    }
}

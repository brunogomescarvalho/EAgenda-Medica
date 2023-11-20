using System.Text.RegularExpressions;

namespace EAgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.Nome).MinimumLength(3);

            RuleFor(x => x.CRM).Custom(ValidarCRM);

        }

        private void ValidarCRM(string crm, ValidationContext<Medico> context)
        {
            string pattern = @"^\d{5}-[A-Z]{2}$";

            if (!Regex.IsMatch(crm.ToUpper(), pattern))
            {
                context.AddFailure("CRM inválido. O CRM deve estar no formato 12345-XX");
            }
        }
    }
}

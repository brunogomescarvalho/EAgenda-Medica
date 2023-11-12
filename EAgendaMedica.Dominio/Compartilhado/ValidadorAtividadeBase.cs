namespace EAgendaMedica.Dominio.Compartilhado
{
    public class ValidadorAtividadeBase<T> : AbstractValidator<Atividade> where T : Atividade
    {
        public ValidadorAtividadeBase()
        {
            RuleFor(x => x.HoraInicio).LessThan(x => x.HoraTermino)
               .WithMessage("Horário de ínicio deve ser menor que Horário de Términio");
        }
    }
}

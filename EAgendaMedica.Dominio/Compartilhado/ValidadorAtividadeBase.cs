using EAgendaMedica.Dominio.Copartilhado;

namespace EAgendaMedica.Dominio.Compartilhado
{
    public class ValidadorAtividadeBase<T> : AbstractValidator<Atividade<T>> where T : Atividade<T>
    {
        public ValidadorAtividadeBase()
        {
            RuleFor(x => x.HoraInicio).LessThan(x => x.HoraTermino)
               .WithMessage("Horário de ínicio deve ser menor que Horário de Términio");
        }
    }
}

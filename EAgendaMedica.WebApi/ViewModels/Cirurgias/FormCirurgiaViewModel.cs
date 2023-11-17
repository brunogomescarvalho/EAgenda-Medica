using System.ComponentModel.DataAnnotations;

namespace EAgendaMedica.WebApi.ViewModels.Cirurgias
{
    public class FormCirurgiaViewModel
    {
        [Required(ErrorMessage = "Por favor, forneça uma data inicial.")]
        [Display(Name = "Data Inicial")]
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "Por favor, forneça uma hora inicial.")]
        [Display(Name = "Hora Inicial")]
        public TimeSpan HoraInicial { get; set; }

        [Required(ErrorMessage = "Por favor, forneça a duração em minutos.")]
        [Display(Name = "Tempo de Duração")]
        public int TempoDeDuracao { get; set; }

        [Required(ErrorMessage = "Por Favor, forneça os id's dos médicos.")]
        [Display(Name = "Médicos Ids")]
        public List<Guid>? MedicosIds { get; set; }
    }
}

using EAgendaMedica.WebApi.ViewModels.Medicos;

namespace EAgendaMedica.WebApi.ViewModels.Cirurgias
{
    public class VisualizarCirurgiaViewModel
    {
        public Guid Id { get; set; }
        public List<ListarMedicosViewModel>? Medicos { get; set; }
        public string? DataInicio { get; set; }
        public string? DataTermino { get; set; }
        public string? HoraIncio { get; set; }
        public string? HoraTermino { get; set; }
    }
}

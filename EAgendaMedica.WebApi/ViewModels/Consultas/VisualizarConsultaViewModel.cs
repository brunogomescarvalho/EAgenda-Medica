using EAgendaMedica.WebApi.ViewModels.Medicos;

namespace EAgendaMedica.WebApi.ViewModels.Consultas
{
    public class VisualizarConsultaViewModel
    {
        public ListarMedicosViewModel? Medico { get; set; }
        public string? DataInicio { get; set; }
        public string? DataTermino { get; set; }
        public string? HoraIncio { get; set; }
        public string? HoraTermino { get; set; }
    }
}

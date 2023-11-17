using AutoMapper;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.WebApi.ViewModels.Medicos;

namespace eAgendaWebApi.Configs.AutoMapper
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<Medico, FormMedicoViewModel>();

            CreateMap<Medico, VisualizarMedicoViewModel>()
                .ForMember(origem => origem.Atividades, opt => opt.MapFrom(x => x.TodasAtividades()
                .Select(a => new ListarAtividadesMedicoViewModel
                {
                    Id = a.Id,
                    DataInicio = a.DataInicio.ToShortDateString(),
                    HoraInicio = a.HoraInicio.ToString(),
                    HoraTermino = a.HoraTermino.ToString(),
                    TipoAtividade = a is Consulta ? "Consulta" : "Cirurgia"

                }).ToList()));

            CreateMap<Medico, ListarMedicosViewModel>();

            CreateMap<FormMedicoViewModel, Medico>();

        }
    }
}

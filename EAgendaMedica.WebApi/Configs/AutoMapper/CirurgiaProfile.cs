

using AutoMapper;
using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.WebApi.ViewModels.Cirurgias;
using EAgendaMedica.WebApi.ViewModels.Compartilhado;

namespace eAgendaWebApi.Configs.AutoMapper
{
    public class CirurgiaProfile : Profile
    {
        public CirurgiaProfile()
        {
            CreateMap<Cirurgia, FormCirurgiaViewModel>()
                .ForMember(origem => origem.MedicosIds, opt => opt.MapFrom(x => x.Medicos.Select(x => x.Id)));

            CreateMap<Cirurgia, ListarAtividadeViewModel>();

            CreateMap<Cirurgia, VisualizarCirurgiaViewModel>();

            CreateMap<FormCirurgiaViewModel, Cirurgia>()
                  .ForMember(origem => origem.Medicos, opt => opt.Ignore())
                  .AfterMap<InserirMedicosMappingAction>();
        }
    }

    public class InserirMedicosMappingAction : IMappingAction<FormCirurgiaViewModel, Cirurgia>
    {
        public InserirMedicosMappingAction(IRepositorioMedico repositorioMedico)
        {
            RepositorioMedico = repositorioMedico;
        }

        public IRepositorioMedico RepositorioMedico { get; }

        public void Process(FormCirurgiaViewModel source, Cirurgia destination, ResolutionContext context)
        {
            destination.Medicos = RepositorioMedico.SelecionarMuitos(source.MedicosIds!).Result;
        }
    }

}

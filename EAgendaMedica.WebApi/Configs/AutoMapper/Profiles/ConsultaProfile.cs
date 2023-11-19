using AutoMapper;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.WebApi.ViewModels.Consultas;
using EAgendaMedica.WebApi.ViewModels.Compartilhado;
using EAgendaMedica.Dominio;

namespace EAgendaMedica.WebApi.Configs.AutoMapper.Profiles
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            CreateMap<Consulta, FormConsultaViewModel>();

            CreateMap<Consulta, ListarAtividadeViewModel>()
            .BeforeMap((src, dest) => src.AtualizarInformacoes(src))
            .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(x => x.DataInicio.ToShortDateString()));

            CreateMap<Consulta, VisualizarConsultaViewModel>();

            CreateMap<FormConsultaViewModel, Consulta>()
                .ForMember(x=>x.MedicoId , opt =>opt.Ignore())           
                 .AfterMap<InserirMedicoMappingAction>();
        }
    }

    public class InserirMedicoMappingAction : IMappingAction<FormConsultaViewModel, Consulta>
    {
        public InserirMedicoMappingAction(IRepositorioMedico repositorioMedico)
        {
            RepositorioMedico = repositorioMedico;
        }

        public IRepositorioMedico RepositorioMedico { get; }

        public void Process(FormConsultaViewModel source, Consulta destination, ResolutionContext context)
        {
            destination.Medico = RepositorioMedico.SelecionarPorId(source.MedicoId).Result;


        }
    }
}


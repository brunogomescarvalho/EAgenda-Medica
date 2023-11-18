using AutoMapper;
using EAgendaMedica.Dominio.ModuloCirurgia;
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
               .AfterMap<MedicoVisualizacaoCompletaMappingAction>();

            CreateMap<Medico, ListarMedicosViewModel>();

            CreateMap<Medico, ListarRankingMedicosViewModel>();

            CreateMap<FormMedicoViewModel, Medico>();

        }
    }

    public class MedicoVisualizacaoCompletaMappingAction : IMappingAction<Medico, VisualizarMedicoViewModel>
    {
        public void Process(Medico source, VisualizarMedicoViewModel destination, ResolutionContext context)
        {
            source.TodasAtividades().ForEach(x => x.AtualizarInformacoes(x.DataInicio, x.HoraInicio, x.DuracaoEmMinutos));

            destination.Atividades ??= new();

            source.TodasAtividades().ForEach(x =>
            {
                destination.Atividades.Add(new ListarAtividadesMedicoViewModel()
                {
                    Id = x.Id,
                    DataInicio = x.DataInicio.ToShortDateString(),
                    HoraInicio = x.HoraInicio.ToString(@"hh\:mm"),
                    HoraTermino = x.HoraTermino.ToString(@"hh\:mm"),                 
                    TipoAtividade = x is Cirurgia ? "Cirurgia" : "Consulta"
                });
            });
        }
    }
}

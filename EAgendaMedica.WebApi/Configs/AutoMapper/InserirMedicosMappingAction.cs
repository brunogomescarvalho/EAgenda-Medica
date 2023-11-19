

using AutoMapper;
using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.WebApi.ViewModels.Cirurgias;

namespace EAgendaMedica.WebApi.Configs.AutoMapper
{
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

﻿using AutoMapper;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.WebApi.ViewModels.Consultas;
using EAgendaMedica.WebApi.ViewModels.Compartilhado;
using EAgendaMedica.Dominio;

namespace eAgendaWebApi.Configs.AutoMapper
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            CreateMap<Consulta, FormConsultaViewModel>();
               
            CreateMap<Consulta, ListarAtividadeViewModel>();
            CreateMap<Consulta, VisualizarConsultaViewModel>();

            CreateMap<FormConsultaViewModel, Consulta>()
                 .ForMember(origem => origem.MedicoId, opt => opt.Ignore())
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


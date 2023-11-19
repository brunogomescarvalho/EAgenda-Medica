﻿using AutoMapper;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.WebApi.ViewModels.Medicos;
using eAgendaWebApi.Configs.AutoMapper;

namespace EAgendaMedica.WebApi.Configs.AutoMapper.Profiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<Medico, FormMedicoViewModel>();

            CreateMap<Medico, VisualizarMedicoViewModel>()
               .AfterMap<MedicoVisualizacaoCompletaMappingAction>();

            CreateMap<Medico, VisualizarAgendaMedicoViewModel>()
             .AfterMap<MedicoAgendaDoDiaMappingAction>();

            CreateMap<Medico, ListarMedicosViewModel>()
                .ForMember(x => x.Situacao, opt => opt.MapFrom(x => x.Ativo ? "Ativo" : "Inativo"));

            CreateMap<Medico, ListarRankingMedicosViewModel>();

            CreateMap<FormMedicoViewModel, Medico>();

        }
    }
}

﻿namespace EAgendaMedica.WebApi.ViewModels.Medicos
{
    public class VisualizarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        public string? CRM { get; set; }

        public List<ListarAtividadesMedicoViewModel>? Atividades { get; set; }
    }
}

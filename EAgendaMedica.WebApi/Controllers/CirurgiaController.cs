﻿using AutoMapper;
using EAgendaMedica.Aplicacao.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.WebApi.ViewModels.Compartilhado;
using EAgendaMedica.WebApi.ViewModels.Cirurgias;
using eAgendaWebApi.Controllers.Compartilhado;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAgendaMedica.WebApi.Controllers
{
    [Route("api/cirurgias")]
    [ApiController]
    public class CirurgiaController : EagendaMedicaControllerBase
    {
        private ServicoCirurgia servicoCirurgia;

        public CirurgiaController(ServicoCirurgia servicoCirurgia, IMapper mapper) : base(mapper)
        {
            this.servicoCirurgia = servicoCirurgia;
        }


        [HttpGet]
        [ProducesResponseType((typeof(ListarAtividadeViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarTodos()
        {
            var result = await servicoCirurgia.SelecionarTodos();

            return ProcessarResultado(result, mapper.Map<List<ListarAtividadeViewModel>>(result.Value));
        }

        [HttpPost]
        [ProducesResponseType((typeof(VisualizarCirurgiaViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Inserir(FormCirurgiaViewModel CirurgiaVM)
        {
            var cirurgia = mapper.Map<Cirurgia>(CirurgiaVM);

            var result = await servicoCirurgia.Inserir(cirurgia);

            var novaCirurgiaVM = mapper.Map<VisualizarCirurgiaViewModel>(result.Value);

            return ProcessarResultado(result, novaCirurgiaVM);
        }

        [HttpPut]
        [ProducesResponseType((typeof(VisualizarCirurgiaViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Editar(Guid id, FormCirurgiaViewModel CirurgiaVM)
        {
            var result = await servicoCirurgia.SelecionarPorId(id);

            if (result.IsFailed)
                return NotFound(result);

            var Cirurgia = mapper.Map(CirurgiaVM, result.Value);

            var resultUpdate = await servicoCirurgia.Editar(Cirurgia);

            var CirurgiaEditadaVM = mapper.Map<VisualizarCirurgiaViewModel>(resultUpdate.Value);

            return ProcessarResultado(resultUpdate, CirurgiaEditadaVM);

        }

        [HttpGet("medico/{crm}")]
        [ProducesResponseType((typeof(ListarAtividadeViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCirurgiasPorMedico(string crm)
        {
            var result = await servicoCirurgia.SelecionarCirurgiasporMedico(crm);

            return ProcessarResultado(result, mapper.Map<List<ListarAtividadeViewModel>>(result.Value));
        }


        [HttpGet("periodo")]
        [ProducesResponseType((typeof(ListarAtividadeViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCirurgiasPorPeriodo([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            var result = await servicoCirurgia.SelecionarPorPeriodo(dataInicio, dataFim);

            return ProcessarResultado(result, mapper.Map<List<ListarAtividadeViewModel>>(result.Value));
        }


        [HttpGet("{id}")]
        [ProducesResponseType((typeof(FormCirurgiaViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCirurgiasId(Guid id)
        {
            var result = await servicoCirurgia.SelecionarPorId(id);

            return ProcessarResultado(result, mapper.Map<FormCirurgiaViewModel>(result.Value));
        }


        [HttpGet("hoje")]
        [ProducesResponseType((typeof(ListarAtividadeViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCirurgiasParaHoje()
        {
            var result = await servicoCirurgia.SelecionarParaHoje();

            return ProcessarResultado(result, mapper.Map<List<ListarAtividadeViewModel>>(result.Value));
        }

        [HttpGet("passadas")]
        [ProducesResponseType((typeof(ListarAtividadeViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCirurgiasPassadas()
        {
            var result = await servicoCirurgia.SelecionarUltimos30Dias();

            return ProcessarResultado(result, mapper.Map<List<ListarAtividadeViewModel>>(result.Value));
        }


        [HttpGet("futuras")]
        [ProducesResponseType((typeof(ListarAtividadeViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCirurgiasFuturas()
        {
            var result = await servicoCirurgia.SelecionarProximos30Dias();

            return ProcessarResultado(result, mapper.Map<List<ListarAtividadeViewModel>>(result.Value));
        }


        [HttpGet("detalhes/{id}")]
        [ProducesResponseType((typeof(VisualizarCirurgiaViewModel)), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> VisualizarCirurgiaCompleta(Guid id)
        {
            var result = await servicoCirurgia.SelecionarPorId(id);

            return ProcessarResultado(result, mapper.Map<VisualizarCirurgiaViewModel>(result.Value));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await servicoCirurgia.SelecionarPorId(id);

            if (result.IsFailed)
                return NotFound(result);

            var resultDelete = await servicoCirurgia.Excluir(result.Value);

            return ProcessarResultado((Result<Cirurgia>)resultDelete, $"Cirurgia excluída com sucesso");
        }
    }
}


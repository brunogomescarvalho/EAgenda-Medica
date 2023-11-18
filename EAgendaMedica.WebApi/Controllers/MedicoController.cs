using AutoMapper;
using EAgendaMedica.Aplicacao.ModuloMedico;
using EAgendaMedica.WebApi.ViewModels.Medicos;
using eAgendaWebApi.Controllers.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace EAgendaMedica.WebApi.Controllers
{
    [ApiController]
    [Route("api/medicos")]
    public class MedicoController : EagendaMedicaControllerBase
    {
        private ServicoMedico servicoMedico;
        public MedicoController(IMapper mapper, ServicoMedico servicoMedico) : base(mapper)
        {
            this.servicoMedico = servicoMedico;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarTodos()
        {
            var result = await servicoMedico.SelecionarTodos();

            var medicosVM = mapper.Map<List<ListarMedicosViewModel>>(result.Value);

            return ProcessarResultado(result, medicosVM);
        }

        [HttpGet("detalhes/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType((typeof(string[])), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarDetalhes(Guid id)
        {
            var result = await servicoMedico.SelecionarPorId(id);

            if (result.IsFailed)
                return NotFound(result);

            return ProcessarResultado(result, mapper.Map<VisualizarMedicoViewModel>(result.Value));
        }

        [HttpGet("top10")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarTop10(DateTime dataInicial,DateTime dataFinal)
        {
            var result = await servicoMedico.SelecionarTop10(dataInicial, dataFinal);

            if (result.IsFailed)
                return NotFound(result);

            return ProcessarResultado(result, mapper.Map<List<ListarRankingMedicosViewModel>>(result.Value));
        }

        [HttpGet("atividades-de-hoje/{crm}")]
        [ProducesResponseType(200)]
        [ProducesResponseType((typeof(string[])), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarPorCRM(string crm)
        {
            var result = await servicoMedico.SelecionarPorCRM(crm);

            if (result.IsFailed)
                return NotFound(result);

            return ProcessarResultado(result, mapper.Map<VisualizarAgendaMedicoViewModel>(result.Value));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType((typeof(string[])), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var result = await servicoMedico.SelecionarPorId(id);

            if (result.IsFailed)
                return NotFound(result);

            return ProcessarResultado(result, mapper.Map<FormMedicoViewModel>(result.Value));
        }
    }
}

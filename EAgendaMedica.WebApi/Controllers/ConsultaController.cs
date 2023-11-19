using AutoMapper;
using EAgendaMedica.Aplicacao.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.WebApi.ViewModels.Compartilhado;
using EAgendaMedica.WebApi.ViewModels.Consultas;
using eAgendaWebApi.Controllers.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace EAgendaMedica.WebApi.Controllers
{
    [Route("api/consultas")]
    [ApiController]

    public class ConsultaController : EagendaMedicaControllerBase
    {

        ServicoConsulta servicoConsulta;

        public ConsultaController(ServicoConsulta servicoConsulta, IMapper mapper) : base(mapper)
        {
            this.servicoConsulta = servicoConsulta;
        }


        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var result = await servicoConsulta.SelecionarTodos();

            return ProcessarResultado(result, mapper.Map<List<ListarAtividadeViewModel>>(result.Value));
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(FormConsultaViewModel consultaVM)
        {
            var consulta = mapper.Map<Consulta>(consultaVM);

            var result = await servicoConsulta.Inserir(consulta);

            var novaConsulta = mapper.Map<ListarAtividadeViewModel>(result.Value);

            return ProcessarResultado(result, novaConsulta);

        }
    }
}

using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaWebApi.Controllers.Compartilhado
{

    [ApiController]
    public abstract class EagendaMedicaControllerBase : ControllerBase
    {
        protected IMapper mapper;
        protected EagendaMedicaControllerBase(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected BadRequestObjectResult BadRequest<T>(Result<T> result)
        {
            var resposta = new
            {
                sucesso = false,
                erros = result.Reasons.Select(m => m.Message).ToArray(),
            };

            return new BadRequestObjectResult(resposta);
        }

        protected NotFoundObjectResult NotFound<T>(Result<T> result)
        {
            var resposta = new
            {
                sucesso = false,
                erros = result.Reasons.Select(m => m.Message).ToArray()
            };

            return new NotFoundObjectResult(resposta);
        }

        public override OkObjectResult Ok(object? obj)
        {
            var resposta = new
            {
                sucesso = true,
                dados = obj
            };

            return new OkObjectResult(resposta);
        }

        protected IActionResult ProcessarResultado<T>(Result<T> result, object obj)
        {
            if (result.IsSuccess)
                return Ok(obj);

            else if (result.IsFailed)
                return BadRequest(result);

            return NotFound(result);
        }
    }
}

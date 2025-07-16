using HDP.Application.Interfaces;
using HDP.Core.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDP.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _service;

        public DepartamentoController(IDepartamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(StatusEnum status)
        {

            var retorno = await this._service.BuscarTodas(status);

            return Ok(retorno);
        }
    }
}

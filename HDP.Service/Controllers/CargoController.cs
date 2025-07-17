using HDP.Application.Interfaces;
using HDP.Core.Enum;
using HDP.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDP.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CargoViewModelInput input)
        {
            var retorno = await this._service.Adicionar(input);

            return Ok(retorno);
        }

        [HttpGet]
        public async Task<List<CargoViewModelOutput>> GetAll([FromQuery] StatusEnum? status)
        {
            return await this._service.BuscarTodos(status);

        }

        [HttpGet("{id}")]
        public async Task<CargoViewModelOutput> GetById(int id)
        {
            return await this._service.BuscarPorId(id);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> AtivarInativar(int codigo)
        {
            var retorno = await this._service.AtivarInativar(codigo);

            return Ok(new { mensagem = "Registro excluído com sucesso" });
        }
    }
}

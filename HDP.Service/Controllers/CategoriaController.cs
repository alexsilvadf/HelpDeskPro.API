using HDP.Application.Interfaces;
using HDP.Core.Entidade;
using HDP.Core.Interface;
using HDP.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDP.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoriaViewModelInput input)
        {
            var retorno = await this._service.Adicionar(input);

            return Ok(retorno);
        }
      
        [HttpGet]
        public async Task<List<CategoriaViewModelOutput>> GetAll()
        {
            return await this._service.BuscarTodas();
          
        }

        [HttpGet("{id}")]
        public async Task<CategoriaViewModelOutput> GetById(int id)
        {
            return await this._service.BuscarPorId(id);
        }

        [HttpDelete("{codigo}")]
        public async Task<bool> AtivarInativar(int codigo)
        {
            var retorno = await this._service.AtivarInativar(codigo);

            return true;
        }
    }
}


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
        public async Task<IActionResult> Adicionar([FromBody] CategoriaViewModelInput input)
        {
            var retorno = await this._service.Adicionar(input);

            return Ok(retorno);
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, CategoriaViewModelInput input)
        {
            return true;
        }

        [HttpGet]
        public async Task<CategoriaViewModelOutput> GetAll()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<CategoriaViewModelOutput> GetById(int id)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return true;
        }
    }
}


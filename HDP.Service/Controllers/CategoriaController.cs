using HDP.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDP.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> Create([FromBody] CategoriaViewModelInput input)
        {
            return true;
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

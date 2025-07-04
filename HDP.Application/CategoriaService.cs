using AutoMapper;
using HDP.Application.Interfaces;
using HDP.Core.Entidade;
using HDP.Core.Interface;
using HDP.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepositorioGenerico<Categoria> _repositorio;
        private readonly IMapper _mapper;

        public CategoriaService(IRepositorioGenerico<Categoria> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<CategoriaViewModelOutput> Adicionar(CategoriaViewModelInput input)
        {
            var categoria = await this._repositorio.IQueryable().Where(s => s.Nome == input.Nome).FirstOrDefaultAsync();

            if(categoria == null)
            {
                var mapping = this._mapper.Map<Categoria>(input);

                this._repositorio.Adicionar(mapping);               

                var resultado = this._mapper.Map<CategoriaViewModelOutput>(mapping);

                return resultado;
            }
            else
            {
                categoria.Status = input.Status;

                var resultado = this._mapper.Map<CategoriaViewModelOutput>(categoria);

                await this._repositorio.SaveChangesAsync();

                return resultado;
            }

            


        }
    }
}

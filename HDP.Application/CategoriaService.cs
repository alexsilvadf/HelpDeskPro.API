using AutoMapper;
using HDP.Application.Interfaces;
using HDP.Core.Entidade;
using HDP.Core.Interface;
using HDP.Core.ViewModels;
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
            if (input.Id.Value == 0)
            {
               var mapping = this._mapper.Map<Categoria>(input);

               this._repositorio.Adicionar(mapping);

                await this._repositorio.SaveChangesAsync();

                var resultado = this._mapper.Map<CategoriaViewModelOutput>(mapping);

                return resultado;

            }
            else
            {
                return null;
            }
        }
    }
}

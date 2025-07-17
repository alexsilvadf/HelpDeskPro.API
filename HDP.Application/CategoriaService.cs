using AutoMapper;
using HDP.Application.Interfaces;
using HDP.Core.Entidade;
using HDP.Core.Enum;
using HDP.Core.Interface;
using HDP.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
            if (input.Nome == null)
            {
                throw new Exception("Campo nome obrigatório");
            }


            var categoria = await this._repositorio.IQueryable().Where(s => s.Nome == input.Nome).FirstOrDefaultAsync();

            if(categoria == null)
            {
                var mapping = this._mapper.Map<Categoria>(input);

                this._repositorio.Adicionar(mapping);               

                var resultado = this._mapper.Map<CategoriaViewModelOutput>(mapping);

                await this._repositorio.SaveChangesAsync();

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

        public async Task<List<CategoriaViewModelOutput>> BuscarTodas(StatusEnum? status)
        {
            if(status == null || status == StatusEnum.Todos)
            {
                var categorias = await this._repositorio.IQueryable().ToListAsync();
                var mapping = this._mapper.Map<List<CategoriaViewModelOutput>>(categorias);

                return mapping;
            }
            else
            {
                var categorias = await this._repositorio.IQueryable().Where(s => s.Status == status).ToListAsync();
                var mapping = this._mapper.Map<List<CategoriaViewModelOutput>>(categorias);

                return mapping;
            }
        }

        

        public async Task<bool> AtivarInativar(int codigo)
        {
            var categoria = await this._repositorio.IQueryable().Where(s => s.Id == codigo).FirstOrDefaultAsync();

            if(categoria == null)
            {
                throw new Exception("Categoria não existe");
            }

            //Nao pode deletar a categoria, fazer consulta nas tabelas filhas para ver se tem registros, senão, ai pode deletar
            this._repositorio.Deletar(categoria);

            await this._repositorio.SaveChangesAsync();           

            return true;


        }

        public async Task<CategoriaViewModelOutput> BuscarPorId(int id)
        {
            var categoria = await this._repositorio.IQueryable().Where(s => s.Id == id).FirstOrDefaultAsync();

            var mapping = this._mapper.Map<CategoriaViewModelOutput>(categoria);

            return mapping;
        }
    }
}

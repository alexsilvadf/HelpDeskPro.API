using AutoMapper;
using HDP.Application.Interfaces;
using HDP.Core.Entidade;
using HDP.Core.Enum;
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
    public class PerfilService : IPerfilService
    {
        private readonly IRepositorioGenerico<Perfil> _repositorio;
        private readonly IMapper _mapper;

        public PerfilService(IRepositorioGenerico<Perfil> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<PerfilViewModelOutput> Adicionar(PerfilViewModelInput input)
        {
            if (input.Nome == null)
            {
                throw new Exception("Campo nome obrigatório");
            }


            var perfil = await this._repositorio.IQueryable().Where(s => s.Nome == input.Nome).FirstOrDefaultAsync();

            if (perfil == null)
            {
                var mapping = this._mapper.Map<Perfil>(input);

                this._repositorio.Adicionar(mapping);

                var resultado = this._mapper.Map<PerfilViewModelOutput>(mapping);

                await this._repositorio.SaveChangesAsync();

                return resultado;
            }
            else
            {
                perfil.Status = input.Status;

                var resultado = this._mapper.Map<PerfilViewModelOutput>(perfil);

                await this._repositorio.SaveChangesAsync();

                return resultado;
            }
        }

        public async Task<bool> AtivarInativar(int codigo)
        {
            var perfil = await this._repositorio.IQueryable().Where(s => s.Id == codigo).FirstOrDefaultAsync();

            if (perfil == null)
            {
                throw new Exception("Perfil não existe");
            }

            //Nao pode deletar a categoria, fazer consulta nas tabelas filhas para ver se tem registros, senão, ai pode deletar
            this._repositorio.Deletar(perfil);

            await this._repositorio.SaveChangesAsync();

            return true;
        }

        public async Task<PerfilViewModelOutput> BuscarPorId(int codigo)
        {
            var perfil = await this._repositorio.IQueryable().Where(s => s.Id == codigo).FirstOrDefaultAsync();

            var mapping = this._mapper.Map<PerfilViewModelOutput>(perfil);

            return mapping;
        }

        public async Task<List<PerfilViewModelOutput>> BuscarTodos(StatusEnum? status)
        {
            if (status == null || status == StatusEnum.Todos)
            {
                var perfis = await this._repositorio.IQueryable().ToListAsync();
                var mapping = this._mapper.Map<List<PerfilViewModelOutput>>(perfis);

                return mapping;
            }
            else
            {
                var perfis = await this._repositorio.IQueryable().Where(s => s.Status == status).ToListAsync();
                var mapping = this._mapper.Map<List<PerfilViewModelOutput>>(perfis);

                return mapping;
            }
        }
    }
}

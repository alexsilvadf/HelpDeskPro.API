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
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IRepositorioGenerico<Departamento> _repositorio;
        private readonly IMapper _mapper;

        public DepartamentoService(IRepositorioGenerico<Departamento> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<DepartamentoViewModelOutput> Adicionar(DepartamentoViewModelInput input)
        {
            if (input.Nome == null)
            {
                throw new Exception("Campo nome obrigatório");
            }


            var departamento = await this._repositorio.IQueryable().Where(s => s.Nome == input.Nome).FirstOrDefaultAsync();

            if (departamento == null)
            {
                var mapping = this._mapper.Map<Departamento>(input);

                this._repositorio.Adicionar(mapping);

                var resultado = this._mapper.Map<DepartamentoViewModelOutput>(mapping);

                await this._repositorio.SaveChangesAsync();

                return resultado;
            }
            else
            {
                departamento.Status = input.Status;

                var resultado = this._mapper.Map<DepartamentoViewModelOutput>(departamento);

                await this._repositorio.SaveChangesAsync();

                return resultado;
            }




        }

        public async Task<List<DepartamentoViewModelOutput>> BuscarTodas(StatusEnum status)
        {
            if (status == null || status == StatusEnum.Todos)
            {
                var departamentos = await this._repositorio.IQueryable().ToListAsync();
                var mapping = this._mapper.Map<List<DepartamentoViewModelOutput>>(departamentos);

                return mapping;
            }
            else
            {
                var departamentos = await this._repositorio.IQueryable().Where(s => s.Status == status).ToListAsync();
                var mapping = this._mapper.Map<List<DepartamentoViewModelOutput>>(departamentos);

                return mapping;
            }
        }

        public async Task<DepartamentoViewModelOutput> BuscarPorId(int id)
        {
            var departamento = await this._repositorio.IQueryable().Where(s => s.Id == id).FirstOrDefaultAsync();

            var mapping = this._mapper.Map<DepartamentoViewModelOutput>(departamento);

            return mapping;
        }

        public async Task<bool> AtivarInativar(int codigo)
        {
            var departamento = await this._repositorio.IQueryable().Where(s => s.Id == codigo).FirstOrDefaultAsync();

            if (departamento == null)
            {
                throw new Exception("Departamento não existe");
            }

            //Nao pode deletar a departamento, fazer consulta nas tabelas filhas para ver se tem registros, senão, ai pode deletar
            this._repositorio.Deletar(departamento);

            await this._repositorio.SaveChangesAsync();

            return true;


        }
    }
}

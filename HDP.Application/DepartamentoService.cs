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
    }
}

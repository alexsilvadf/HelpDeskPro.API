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
    public class CargoService : ICargoService
    {
        private readonly IRepositorioGenerico<Cargo> _repositorio;
        private readonly IMapper _mapper;

        public CargoService(IRepositorioGenerico<Cargo> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<CargoViewModelOutput> Adicionar(CargoViewModelInput input)
        {
            if (input.Nome == null)
            {
                throw new Exception("Campo nome obrigatório");
            }

            var cargo = await this._repositorio.IQueryable().Where(s => s.Nome == input.Nome).FirstOrDefaultAsync();

            if (cargo == null)
            {
                var mapping = this._mapper.Map<Cargo>(input);

                this._repositorio.Adicionar(mapping);

                var resultado = this._mapper.Map<CargoViewModelOutput>(mapping);

                await this._repositorio.SaveChangesAsync();

                return resultado;
            }
            else
            {
                cargo.Status = input.Status;

                var resultado = this._mapper.Map<CargoViewModelOutput>(cargo);

                await this._repositorio.SaveChangesAsync();

                return resultado;
            }
        }

        public async Task<bool> AtivarInativar(int id)
        {
            var cargo = await this._repositorio.IQueryable().Where(s => s.Id == id).FirstOrDefaultAsync();

            if (cargo == null)
            {
                throw new Exception("Cargo não existe");
            }

            //Nao pode deletar a categoria, fazer consulta nas tabelas filhas para ver se tem registros, senão, ai pode deletar
            this._repositorio.Deletar(cargo);

            await this._repositorio.SaveChangesAsync();

            return true;
        }

        public async Task<CargoViewModelOutput> BuscarPorId(int id)
        {
            var cargo = await this._repositorio.IQueryable().Where(s => s.Id == id).FirstOrDefaultAsync();

            var mapping = this._mapper.Map<CargoViewModelOutput>(cargo);

            return mapping;
        }

        public async Task<List<CargoViewModelOutput>> BuscarTodos(StatusEnum? status)
        {
            if (status == null || status == StatusEnum.Todos)
            {
                var cargos = await this._repositorio.IQueryable().ToListAsync();
                var mapping = this._mapper.Map<List<CargoViewModelOutput>>(cargos);

                return mapping;
            }
            else
            {
                var cargos = await this._repositorio.IQueryable().Where(s => s.Status == status).ToListAsync();
                var mapping = this._mapper.Map<List<CargoViewModelOutput>>(cargos);

                return mapping;
            }
        }
    }
}

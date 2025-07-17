using HDP.Core.Enum;
using HDP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application.Interfaces
{
    public interface ICargoService
    {
        Task<CargoViewModelOutput> Adicionar(CargoViewModelInput input);
        Task<List<CargoViewModelOutput>> BuscarTodos(StatusEnum? status);
        Task<CargoViewModelOutput> BuscarPorId(int id);
        Task<bool> AtivarInativar(int id);
    }
}

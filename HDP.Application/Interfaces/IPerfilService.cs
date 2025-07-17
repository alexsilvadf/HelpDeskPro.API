using HDP.Core.Enum;
using HDP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application.Interfaces
{
    public interface IPerfilService
    {
        Task<PerfilViewModelOutput> Adicionar(PerfilViewModelInput input);
        Task<List<PerfilViewModelOutput>> BuscarTodos(StatusEnum? status);
        Task<PerfilViewModelOutput> BuscarPorId(int codigo);
        Task<bool> AtivarInativar(int codigo);
    }
}

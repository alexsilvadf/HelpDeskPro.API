using HDP.Core.Enum;
using HDP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application.Interfaces
{
    public interface IDepartamentoService
    {
        Task<DepartamentoViewModelOutput> Adicionar(DepartamentoViewModelInput input);
        Task<List<DepartamentoViewModelOutput>> BuscarTodas(StatusEnum status);
        Task<DepartamentoViewModelOutput> BuscarPorId(int id);
        Task<bool> AtivarInativar(int id);
    }
}

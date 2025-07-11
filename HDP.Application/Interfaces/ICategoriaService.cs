using HDP.Core.Enum;
using HDP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaViewModelOutput> Adicionar(CategoriaViewModelInput input);
        Task<List<CategoriaViewModelOutput>> BuscarTodas(StatusEnum? status);
        Task<CategoriaViewModelOutput> BuscarPorId(int id);
        Task<bool> AtivarInativar(int id);
    }
}

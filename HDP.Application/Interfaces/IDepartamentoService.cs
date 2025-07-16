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
        Task<List<DepartamentoViewModelOutput>> BuscarTodas(StatusEnum status);
    }
}

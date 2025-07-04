using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Core.Interface
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T Adicionar(T entidade);
        void Editar(T entidade);
        void Deletar(T entidade);

        Task<bool> SaveChangesAsync();
    }
}

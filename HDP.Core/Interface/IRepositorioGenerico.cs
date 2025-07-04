using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Core.Interface
{
    public interface IRepositorioGenerico<T> : IConsultaGenerica<T> where T : class
    {
        T Adicionar(T entidade);
        void Editar(T entidade);
        void Deletar(T entidade);

        Task<bool> SaveChangesAsync();
    }

    public interface IConsultaGenerica<T> where T: class
    {
        IQueryable<T> IQueryable();
    }
}

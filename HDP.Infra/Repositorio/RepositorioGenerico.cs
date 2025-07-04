using HDP.Core.Interface;
using HDP.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Infra.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly HDPContext _context;

        public RepositorioGenerico(HDPContext context)
        {
            _context = context;
        }


        public T Adicionar(T entidade)
        {
            _context.AddAsync(entidade);
            return entidade;
        }

        public void Deletar(T entidade)
        {
            _context.Set<T>().Remove(entidade);
        }

        public void Editar(T entidade)
        {
            _context.Attach<T>(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();

            return (await _context.SaveChangesAsync()) > 0;
        }

        public IQueryable<T> IQueryable()
        {
            return _context.Set<T>();
        }
    }
}

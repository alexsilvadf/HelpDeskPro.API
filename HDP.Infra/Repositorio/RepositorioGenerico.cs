using HDP.Application.Interfaces;
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
        private readonly IAutenticationService _autenticationService;

        public RepositorioGenerico(HDPContext context, IAutenticationService autenticationService)
        {
            _context = context;
            _autenticationService = autenticationService;
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
            var entidadesCriadas = this._context.ChangeTracker
                                       .Entries()
                                       .Where(x => typeof(IEntidadeAuditavel).IsAssignableFrom(x.Entity.GetType()) && x.State == EntityState.Added)
                                       .ToList();

            var entidadesModificadas = this._context.ChangeTracker
                                      .Entries()
                                      .Where(x => typeof(IEntidadeAuditavel).IsAssignableFrom(x.Entity.GetType()) && x.State == EntityState.Modified)
                                      .ToList();

            var usuarioLogado = this._autenticationService.RecuperarUsuario();

            foreach (var entity in entidadesModificadas)
            {
                var entidadeAuditavel = (entity.Entity as IEntidadeAuditavel);

                if(entidadeAuditavel != null)
                {
                    entidadeAuditavel.UsuarioAlteracao = usuarioLogado.Login;
                    entidadeAuditavel.DataHoraAlteracao = DateTime.Now;
                }

            }

            foreach (var entity in entidadesCriadas)
            {
                var entidadeAuditavel = (entity.Entity as IEntidadeAuditavel);

                if (entidadeAuditavel != null)
                {
                    entidadeAuditavel.UsuarioInclusao = usuarioLogado.Login;
                    entidadeAuditavel.UsuarioAlteracao = usuarioLogado.Login;
                    entidadeAuditavel.DataHoraInclusao = DateTime.Now;                   
                    entidadeAuditavel.DataHoraAlteracao = DateTime.Now;
                }

            }            

            return (await _context.SaveChangesAsync()) > 0;
        }

        public IQueryable<T> IQueryable()
        {
            return _context.Set<T>();
        }
    }
}

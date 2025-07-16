using HDP.Core.Entidade;
using HDP.Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Infra.Data
{
    public class HDPContext : DbContext
    {
        public HDPContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<Departamento> Departamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
           modelBuilder.ApplyConfiguration(new DepartamentoConfiguration());
                    
        }

       
    }
}

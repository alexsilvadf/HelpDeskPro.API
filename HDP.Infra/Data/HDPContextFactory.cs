using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Infra.Data
{
    public class HDPContextFactory : IDesignTimeDbContextFactory<HDPContext>
    {
        public HDPContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HDPContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS; Database=HelpDeskPro;User Id=sa;Password=123456789; Integrated Security=False");

            return new HDPContext(optionsBuilder.Options);
        }
    }
}

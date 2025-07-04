using HDP.Core.Enum;
using HDP.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Core.Entidade
{
    public class Categoria: IEntidadeAuditavel
    {     
        public string? Nome { get; set; }
        public StatusEnum Status { get; set; }
    }
}

using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Chamado : Base
    {
        public string Titulo { get; set; }
        public string DescricaoProblema { get; set; }
        public string Anexo { get; set; }
        public PrioridadeEnum Prioridade { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}

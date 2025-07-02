using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Core.Enum
{
    public enum StatusEnum
    {
        [Description("Ativo")]
        Ativo = 0,

        [Description("Inativo")]
        Inativo = 1,

        [Description("Todos")]
        Todos = -1,
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Core.Interface
{
    public interface IEntidadeAuditavel
    {     
        string? UsuarioInclusao { get; set; }
        DateTime? DataHoraInclusao { get; set; }
        string? UsuarioAlteracao { get; set; }
        DateTime? DataHoraAlteracao { get; set; }

    }
}

﻿using HDP.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application.Interfaces
{
    public interface IAutenticationService
    {
        Usuario RecuperarUsuario();
        
    }
}

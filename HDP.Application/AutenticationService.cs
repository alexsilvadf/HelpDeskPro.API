using HDP.Application.Interfaces;
using HDP.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application
{
    public class AutenticationService : IAutenticationService
    {
        public Usuario RecuperarUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alex",
                Login = "lekinho"
            };

            return usuario;
        }
    }
}

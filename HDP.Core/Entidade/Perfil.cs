using HDP.Core.Enum;
using HDP.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Core.Entidade
{
    public class Perfil : IEntidadeAuditavel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public StatusEnum Status { get; set; }
        public string? UsuarioInclusao { get; set; }
        public DateTime? DataHoraInclusao { get; set; }
        public string? UsuarioAlteracao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
    }
}

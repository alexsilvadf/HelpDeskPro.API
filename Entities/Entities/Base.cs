using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Base : Notifica
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraInclusao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public bool Status { get; set; }
    }
}

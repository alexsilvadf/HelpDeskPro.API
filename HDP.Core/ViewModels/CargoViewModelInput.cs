using HDP.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Core.ViewModels
{
    public class CargoViewModelInput
    {
        public string Nome { get; set; }
        public StatusEnum Status { get; set; }
    }
}

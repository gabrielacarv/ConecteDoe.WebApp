using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConecteDoe.Dominio.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

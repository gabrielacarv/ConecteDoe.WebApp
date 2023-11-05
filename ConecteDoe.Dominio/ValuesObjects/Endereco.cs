﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConecteDoe.Dominio.ValuesObjects
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContas.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoConta { get; set; }
        public string Valor { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}

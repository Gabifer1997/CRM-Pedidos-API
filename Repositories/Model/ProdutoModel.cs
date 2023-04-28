using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Model
{
    public class ProdutoModel
    {
        public int? ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Apagado { get; set; }
    }
}

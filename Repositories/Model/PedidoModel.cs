using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Model
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int StatusId { get; set; }
        public int ClienteId { get; set; }
        public int Quantidade { get; set; }
        public bool Apagado { get; set; }
    }
    public class PedidoRequestModel
    {
        public int ProdutoId { get; set; }
        public int StatusId { get; set; }
        public int ClienteId { get; set; }
        public int Quantidade { get; set; }
    }
}

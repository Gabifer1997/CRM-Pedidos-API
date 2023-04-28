using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Model
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Apagado { get; set; }
    }
}

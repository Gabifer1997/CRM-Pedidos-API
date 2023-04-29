using Microsoft.Extensions.Configuration;
using Repositories.DAL;
using Repositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteServices
    {
        public async Task<List<ClienteModel>> BuscaClientes(IConfiguration configuration) => await new ClienteDAL().BuscaClientes(configuration);
        public async Task<int> AdicionaClientes(IConfiguration configuration, ClienteRequestModel cliente) => await new ClienteDAL().InsertClientes(configuration, cliente);
        public async Task<bool> AlteraClientes(IConfiguration configuration, ClienteModel cliente) => await new ClienteDAL().UpdateClientes(configuration, cliente);
        public async Task<bool> ApagaClientes(IConfiguration configuration, int codigoCliente) => await new ClienteDAL().ApagaClientes(configuration, codigoCliente);
        public async Task<ClienteModel> BuscaClientesById(IConfiguration configuration, int codigoCliente) => await new ClienteDAL().BuscaClientesById(configuration, codigoCliente);
    }
}

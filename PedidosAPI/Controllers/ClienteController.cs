using Microsoft.AspNetCore.Mvc;
using Repositories.Model;
using Services;

namespace PedidosAPI.Controllers
{
    [Route("pedidosAPI/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly ILogger<ClienteController> logger;
        public readonly IConfiguration configuration;

        public ClienteController(ILoggerFactory loggerFactory, IConfiguration config)
        {
            this.logger = loggerFactory.CreateLogger<ClienteController>();
            this.configuration = config;
        }
        static readonly ClienteServices bll = new ClienteServices();
        [HttpGet]
        [Route("BuscaClientes")]
        public async Task<List<ClienteModel>> BuscaClientes()
        {
            var result = await bll.BuscaClientes(configuration);
            return result;
        }
        [HttpGet]
        [Route("BuscaClientesById")]
        public async Task<ClienteModel> BuscaClientesById(int codigoCliente)
        {
            var result = await bll.BuscaClientesById(configuration, codigoCliente);
            return result;
        }
        [HttpPost]
        [Route("AdicionaClientes")]
        public async Task<int> AdicionaClientes(ClienteModel cliente)
        {
            var result = await bll.AdicionaClientes(configuration, cliente);
            return result;
        }
        [HttpPut]
        [Route("AlteraClientes")]
        public async Task<bool> AlteraClientes(ClienteModel cliente)
        {
            var result = await bll.AlteraClientes(configuration, cliente);
            return result;
        }
        [HttpGet]
        [Route("ApagaClientes")]
        public async Task<bool> ApagaClientes(int codigoCliente)
        {
            var result = await bll.ApagaClientes(configuration, codigoCliente);
            return result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Repositories.Model;
using Services;

namespace PedidosAPI.Controllers
{
    [Route("pedidosAPI/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        readonly ILogger<PedidoController> logger;
        public readonly IConfiguration configuration;

        public PedidoController(ILoggerFactory loggerFactory, IConfiguration config)
        {
            this.logger = loggerFactory.CreateLogger<PedidoController>();
            this.configuration = config;
        }
        static readonly PedidoServices bll = new PedidoServices();
        [HttpGet]
        [Route("BuscaPedidos")]
        public async Task<List<PedidoModel>> BuscaPedidos()
        {
            var result = await bll.BuscaPedidos(configuration);
            return result;
        }
        [HttpGet]
        [Route("BuscaPedidosDetalhado")]
        public async Task<List<PedidoDetalhadoModel>> BuscaPedidosDetalhado()
        {
            var result = await bll.BuscaPedidosDetalhado(configuration);
            return result;
        }
        [HttpGet]
        [Route("BuscaPedidosDetalhadoByClienteDocumento")]
        public async Task<List<PedidoDetalhadoModel>> BuscaPedidosDetalhadoByClienteDocumento(string documento)
        {
            var result = await bll.BuscaPedidosDetalhadoByClienteDocumento(configuration, documento);
            return result;
        }
        [HttpGet]
        [Route("BuscaPedidosDetalhadoById")]
        public async Task<PedidoDetalhadoModel> BuscaPedidosDetalhadoById(int pedidoId)
        {
            var result = await bll.BuscaPedidosDetalhadoById(configuration, pedidoId);
            return result;
        }
        [HttpPost]
        [Route("AdicionaPedidos")]
        public async Task<int> AdicionaPedidos(PedidoRequestModel pedido)
        {
            var result = await bll.AdicionaPedidos(configuration, pedido);
            return result;
        }
        [HttpPost]
        [Route("CancelaPedidos")]
        public async Task<bool> CancelaPedidos(int pedidoId)
        {
            var result = await bll.CancelaPedidos(configuration, pedidoId);
            return result;
        }
        [HttpGet]
        [Route("ApagaPedidos")]
        public async Task<bool> ApagaPedidos(int codigoPedido)
        {
            var result = await bll.ApagaPedidos(configuration, codigoPedido);
            return result;
        }
    }
}

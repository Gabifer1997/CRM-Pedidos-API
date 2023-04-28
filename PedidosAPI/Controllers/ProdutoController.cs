using Microsoft.AspNetCore.Mvc;
using Repositories.Model;
using Services;

namespace PedidosAPI.Controllers
{
    [Route("pedidosAPI/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        readonly ILogger<ProdutoController> logger;
        public readonly IConfiguration configuration;

        public ProdutoController(ILoggerFactory loggerFactory, IConfiguration config)
        {
            this.logger = loggerFactory.CreateLogger<ProdutoController>();
            this.configuration = config;
        }
        static readonly ProdutoServices bll = new ProdutoServices();
        [HttpGet]
        [Route("BuscaProdutos")]
        public async Task<List<ProdutoModel>> BuscaProdutos()
        {
            var result = await bll.BuscaProdutos(configuration);
            return result;
        }
        [HttpGet]
        [Route("BuscaProdutosById")]
        public async Task<ProdutoModel> BuscaProdutosById(int produtoId)
        {
            var result = await bll.BuscaProdutosById(configuration, produtoId);
            return result;
        }
        [HttpPost]
        [Route("AdicionaProdutos")]
        public async Task<int> AdicionaProdutos(ProdutoModel produto)
        {
            var result = await bll.AdicionaProdutos(configuration, produto);
            return result;
        }
        [HttpPut]
        [Route("AlteraProdutos")]
        public async Task<bool> AlteraProdutos(ProdutoModel produto)
        {
            var result = await bll.AlteraProdutos(configuration, produto);
            return result;
        }
        [HttpGet]
        [Route("ApagaProdutos")]
        public async Task<bool> ApagaProdutos(int codigoProduto)
        {
            var result = await bll.ApagaProdutos(configuration, codigoProduto);
            return result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Repositories.Model;
using Services;

namespace PedidosAPI.Controllers
{
    [Route("pedidosAPI/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        readonly ILogger<StatusController> logger;
        public readonly IConfiguration configuration;

        public StatusController(ILoggerFactory loggerFactory, IConfiguration config)
        {
            this.logger = loggerFactory.CreateLogger<StatusController>();
            this.configuration = config;
        }
        static readonly StatusServices bll = new StatusServices();
        [HttpGet]
        [Route("BuscaStatus")]
        public async Task<List<StatusModel>> BuscaStatus()
        {
            var result = await bll.BuscaStatus(configuration);
            return result;
        }
        [HttpGet]
        [Route("BuscaStatusIdByDescricao")]
        public async Task<int> BuscaStatusIdByDescricao(string descricao)
        {
            var result = await bll.BuscaStatusIdByDescricao(configuration, descricao);
            return result;
        }
        [HttpPost]
        [Route("AdicionaStatus")]
        public async Task<int> AdicionaStatus(StatusModel status)
        {
            var result = await bll.AdicionaStatus(configuration, status);
            return result;
        }
        [HttpPut]
        [Route("AlteraStatus")]
        public async Task<bool> AlteraStatus(StatusModel status)
        {
            var result = await bll.AlteraStatus(configuration, status);
            return result;
        }
        [HttpGet]
        [Route("ApagaStatus")]
        public async Task<bool> ApagaStatus(int codigoStatus)
        {
            var result = await bll.ApagaStatus(configuration, codigoStatus);
            return result;
        }
    }
}

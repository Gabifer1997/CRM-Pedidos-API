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
    public class StatusServices
    {
        public async Task<List<StatusModel>> BuscaStatus(IConfiguration config) => await new StatusDAL().BuscaStatus(config);
        public async Task<int> AdicionaStatus(IConfiguration config, StatusModel status) => await new StatusDAL().InsertStatus(config, status);
        public async Task<bool> AlteraStatus(IConfiguration config, StatusModel status) => await new StatusDAL().UpdateStatus(config, status);
        public async Task<bool> ApagaStatus(IConfiguration config, int codigoStatus) => await new StatusDAL().ApagaStatus(config, codigoStatus);
        public async Task<int> BuscaStatusIdByDescricao(IConfiguration config, string descricao) => await new StatusDAL().BuscaStatusIdByDescricao(config, descricao);
    }
}

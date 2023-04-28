using Dapper;
using Microsoft.Extensions.Configuration;
using Repositories.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DAL
{
    public class ClienteDAL
    {
        public async Task<List<ClienteModel>> BuscaClientes(IConfiguration configuration)
        {
            var valor = new List<ClienteModel>();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("[ClienteId] ");
                sql.Append(",[Nome] ");
                sql.Append(",[Documento] ");
                sql.Append(",[Email] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado] ");
                sql.Append("FROM [dbo].[Cliente] (NOLOCK) ");
                sql.Append("WHERE [Apagado] = 0 ");

                var result = conn.Query<ClienteModel>(sql.ToString());
                if (result?.Count() > 0)
                {
                    valor = result.ToList();
                }
            }
            return valor;
        }
        public async Task<int> InsertClientes(IConfiguration configuration, ClienteModel model)
        {
            var id = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO [dbo].[Cliente] ");
                sql.Append("([Nome] ");
                sql.Append(",[Documento] ");
                sql.Append(",[Email] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado]) ");
                sql.Append("VALUES ");
                sql.Append("(@Nome ");
                sql.Append(",@Documento ");
                sql.Append(",@Email ");
                sql.Append(",GETDATE() ");
                sql.Append(",0 ");
                sql.Append(");SELECT CAST(SCOPE_IDENTITY() AS INT)");
                var result = conn.Query<int>(sql.ToString(), model);
                if (result?.Count() > 0)
                {
                    id = result.FirstOrDefault();
                }
            }
            return id;
        }
        public async Task<bool> UpdateClientes(IConfiguration configuration, ClienteModel model)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Cliente] ");
                sql.Append("SET [Nome] = @Nome ");
                sql.Append(",[Documento] = @Documento ");
                sql.Append(",[Email] = @Email ");
                sql.Append(",[Apagado] = @Apagado ");
                sql.Append("WHERE [ClienteId] = @ClienteId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), model);
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<bool> ApagaClientes(IConfiguration configuration, int clienteId)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Cliente] ");
                sql.Append("SET [Apagado] = 1 ");
                sql.Append("WHERE [ClienteId] = @clienteId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), new { clienteId });
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<ClienteModel> BuscaClientesById(IConfiguration configuration, int clienteId)
        {
            var valor = new ClienteModel();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("[ClienteId] ");
                sql.Append(",[Nome] ");
                sql.Append(",[Documento] ");
                sql.Append(",[Email] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado] ");
                sql.Append("FROM [dbo].[Cliente] (NOLOCK) ");
                sql.Append("WHERE [Apagado] = 0 AND [ClienteId] = @clienteId");

                var result = conn.Query<ClienteModel>(sql.ToString(), new { clienteId });
                if (result?.Count() > 0)
                {
                    valor = result.FirstOrDefault();
                }
            }
            return valor;
        }
    }
}

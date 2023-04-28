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
    public class StatusDAL
    {
        public async Task<List<StatusModel>> BuscaStatus(IConfiguration configuration)
        {
            var valor = new List<StatusModel>();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("[StatusId] ");
                sql.Append(",[Descricao] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado] ");
                sql.Append("FROM [dbo].[Status] (NOLOCK) ");
                sql.Append("WHERE [Apagado] = 0 ");

                var result = conn.Query<StatusModel>(sql.ToString());
                if (result?.Count() > 0)
                {
                    valor = result.ToList();
                }
            }
            return valor;
        }
        public async Task<int> InsertStatus(IConfiguration configuration, StatusModel model)
        {
            var id = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO [dbo].[Status] ");
                sql.Append("([Descricao] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado]) ");
                sql.Append("VALUES ");
                sql.Append("(@Descricao ");
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
        public async Task<bool> UpdateStatus(IConfiguration configuration, StatusModel model)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Status] ");
                sql.Append("SET [Descricao] = @Descricao ");
                sql.Append(",[Apagado] = @Apagado ");
                sql.Append("WHERE [StatusId] = @StatusId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), model);
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<bool> ApagaStatus(IConfiguration configuration, int statusId)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Status] ");
                sql.Append("SET [Apagado] = 1 ");
                sql.Append("WHERE [StatusId] = @statusId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), new { statusId });
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<int> BuscaStatusIdByDescricao(IConfiguration configuration, string descricao)
        {
            var valor = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("[StatusId] ");
                sql.Append("FROM [dbo].[Status] (NOLOCK) ");
                sql.Append($"WHERE [Apagado] = 0 AND [Descricao] LIKE '%{descricao}%' ");

                var result = conn.Query<int>(sql.ToString(), new { descricao });
                if (result?.Count() > 0)
                {
                    valor = result.FirstOrDefault();
                }
            }
            return valor;
        }
    }
}

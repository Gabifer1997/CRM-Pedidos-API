using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Repositories.Model;

namespace Repositories.DAL
{
    public class ProdutoDAL
    {
        public async Task<List<ProdutoModel>> BuscaProdutos(IConfiguration configuration)
        {
            var valor = new List<ProdutoModel>();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("[ProdutoId] ");
                sql.Append(",[Descricao] ");
                sql.Append(",[Valor] ");
                sql.Append(",[Quantidade] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado] ");
                sql.Append("FROM [dbo].[Produto] (NOLOCK) ");
                sql.Append("WHERE [Apagado] = 0 ");

                var result = conn.Query<ProdutoModel>(sql.ToString());
                if (result?.Count() > 0)
                {
                    valor = result.ToList();
                }
            }
            return valor;
        }
        public async Task<int> InsertProdutos(IConfiguration configuration, ProdutoModel model)
        {
            var id = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO [dbo].[Produto] ");
                sql.Append("([Descricao] ");
                sql.Append(",[Valor] ");
                sql.Append(",[Quantidade] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado]) ");
                sql.Append("VALUES ");
                sql.Append("(@Descricao ");
                sql.Append(",@Valor ");
                sql.Append(",@Quantidade ");
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
        public async Task<bool> UpdateProdutos(IConfiguration configuration, ProdutoModel model)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Produto] ");
                sql.Append("SET [Descricao] = @Descricao ");
                sql.Append(",[Valor] = @Valor ");
                sql.Append(",[Quantidade] = @Quantidade ");
                sql.Append(",[Apagado] = @Apagado ");
                sql.Append("WHERE [ProdutoId] = @ProdutoId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), model);
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<bool> ApagaProdutos(IConfiguration configuration, int produtoId)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Produto] ");
                sql.Append("SET [Apagado] = 1 ");
                sql.Append("WHERE [ProdutoId] = @produtoId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), new { produtoId });
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<ProdutoModel> BuscaProdutosById(IConfiguration configuration, int produtoId)
        {
            var valor = new ProdutoModel();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("[ProdutoId] ");
                sql.Append(",[Descricao] ");
                sql.Append(",[Valor] ");
                sql.Append(",[Quantidade] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado] ");
                sql.Append("FROM [dbo].[Produto] (NOLOCK) ");
                sql.Append("WHERE [Apagado] = 0 AND [ProdutoId] = @produtoId ");

                var result = conn.Query<ProdutoModel>(sql.ToString(), new { produtoId });
                if (result?.Count() > 0)
                {
                    valor = result.FirstOrDefault();
                }
            }
            return valor;
        }
    }
}

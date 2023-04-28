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
    public class PedidoDAL
    {
        public async Task<List<PedidoModel>> BuscaPedidos(IConfiguration configuration)
        {
            var valor = new List<PedidoModel>();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("[PedidoId] ");
                sql.Append(",[Quantidade] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado] ");
                sql.Append(",[ProdutoId] ");
                sql.Append(",[StatusId] ");
                sql.Append(",[ClienteId] ");
                sql.Append("FROM [dbo].[Pedido] (NOLOCK) ");
                sql.Append("WHERE [Apagado] = 0 ");

                var result = conn.Query<PedidoModel>(sql.ToString());
                if (result?.Count() > 0)
                {
                    valor = result.ToList();
                }
            }
            return valor;
        }
        public async Task<int> InsertPedidos(IConfiguration configuration, PedidoModel model)
        {
            var id = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO [dbo].[Pedido] ");
                sql.Append("([ProdutoId] ");
                sql.Append(",[StatusId] ");
                sql.Append(",[ClienteId] ");
                sql.Append(",[Quantidade] ");
                sql.Append(",[DataCriacao] ");
                sql.Append(",[Apagado]) ");
                sql.Append("VALUES ");
                sql.Append("(@ProdutoId ");
                sql.Append(",@StatusId ");
                sql.Append(",@ClienteId ");
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
        public async Task<bool> UpdatePedidos(IConfiguration configuration, PedidoModel model)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Pedido] ");
                sql.Append("SET [ProdutoId] = @ProdutoId ");
                sql.Append(",[StatusId] = @StatusId ");
                sql.Append(",[ClienteId] = @ClienteId ");
                sql.Append(",[Quantidade] = @Quantidade ");
                sql.Append(",[Apagado] = @Apagado ");
                sql.Append("WHERE [PedidoId] = @PedidoId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), model);
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<bool> ApagaPedidos(IConfiguration configuration, int pedidoId)
        {
            var rowsAffected = 0;
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE [dbo].[Pedido] ");
                sql.Append("SET [Apagado] = 1 ");
                sql.Append("WHERE [PedidoId] = @pedidoId ");
                sql.Append(";SELECT @@ROWCOUNT AS [RowsAffected]");

                var result = conn.Query<int>(sql.ToString(), new { pedidoId });
                if (result?.Count() > 0)
                {
                    rowsAffected = result.FirstOrDefault();
                }
            }
            return rowsAffected == 1;
        }
        public async Task<List<PedidoDetalhadoModel>> BuscaPedidosDetalhado(IConfiguration configuration)
        {
            var valor = new List<PedidoDetalhadoModel>();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("PE.[PedidoId] ");
                sql.Append(",PE.[Quantidade] ");
                sql.Append(",PE.[DataCriacao] ");
                sql.Append(",PE.[Apagado] ");
                sql.Append(",PE.[ProdutoId] ");
                sql.Append(",P.[Descricao] AS 'ProdutoDescricao' ");
                sql.Append(",PE.[StatusId] ");
                sql.Append(",S.[Descricao] AS 'StatusDescricao' ");
                sql.Append(",PE.[ClienteId] ");
                sql.Append(",C.[Nome] ");
                sql.Append("FROM [dbo].[Pedido] PE (NOLOCK) ");
                sql.Append("INNER JOIN [Produto] P ON P.[ProdutoId] = PE.[ProdutoId] ");
                sql.Append("INNER JOIN [Status] S ON S.[StatusId] = PE.[StatusId] ");
                sql.Append("INNER JOIN [Cliente] C ON C.[ClienteId] = PE.[ClienteId] ");
                sql.Append("WHERE PE.[Apagado] = 0 ");

                var result = conn.Query<PedidoDetalhadoModel>(sql.ToString(), new { });
                if (result?.Count() > 0)
                {
                    valor = result.ToList();
                }
            }
            return valor;
        }
        public async Task<List<PedidoDetalhadoModel>> BuscaPedidosDetalhadoByClienteDocumento(IConfiguration configuration, string documento)
        {
            var valor = new List<PedidoDetalhadoModel>();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("PE.[PedidoId] ");
                sql.Append(",PE.[Quantidade] ");
                sql.Append(",PE.[DataCriacao] ");
                sql.Append(",PE.[Apagado] ");
                sql.Append(",PE.[ProdutoId] ");
                sql.Append(",P.[Descricao] AS 'ProdutoDescricao' ");
                sql.Append(",PE.[StatusId] ");
                sql.Append(",S.[Descricao] AS 'StatusDescricao' ");
                sql.Append(",PE.[ClienteId] ");
                sql.Append(",C.[Nome] ");
                sql.Append("FROM [dbo].[Pedido] PE (NOLOCK) ");
                sql.Append("INNER JOIN [Produto] P ON P.[ProdutoId] = PE.[ProdutoId] ");
                sql.Append("INNER JOIN [Status] S ON S.[StatusId] = PE.[StatusId] ");
                sql.Append("INNER JOIN [Cliente] C ON C.[ClienteId] = PE.[ClienteId] ");
                sql.Append("WHERE PE.[Apagado] = 0 AND C.[Documento] = @documento");

                var result = conn.Query<PedidoDetalhadoModel>(sql.ToString(), new { documento });
                if (result?.Count() > 0)
                {
                    valor = result.ToList();
                }
            }
            return valor;
        }
        public async Task<PedidoDetalhadoModel> BuscaPedidosDetalhadoById(IConfiguration configuration, int pedidoId)
        {
            var valor = new PedidoDetalhadoModel();
            using (var conn = new SqlConnection(configuration.GetConnectionString("BD_Connection")))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT /*+ RULE */ ");
                sql.Append("PE.[PedidoId] ");
                sql.Append(",PE.[Quantidade] ");
                sql.Append(",PE.[DataCriacao] ");
                sql.Append(",PE.[Apagado] ");
                sql.Append(",PE.[ProdutoId] ");
                sql.Append(",P.[Descricao] AS 'ProdutoDescricao' ");
                sql.Append(",PE.[StatusId] ");
                sql.Append(",S.[Descricao] AS 'StatusDescricao' ");
                sql.Append(",PE.[ClienteId] ");
                sql.Append(",C.[Nome] ");
                sql.Append("FROM [dbo].[Pedido] PE (NOLOCK) ");
                sql.Append("INNER JOIN [Produto] P ON P.[ProdutoId] = PE.[ProdutoId] ");
                sql.Append("INNER JOIN [Status] S ON S.[StatusId] = PE.[StatusId] ");
                sql.Append("INNER JOIN [Cliente] C ON C.[ClienteId] = PE.[ClienteId] ");
                sql.Append("WHERE PE.[Apagado] = 0 AND PE.[PedidoId] = @pedidoId");

                var result = conn.Query<PedidoDetalhadoModel>(sql.ToString(), new { pedidoId });
                if (result?.Count() > 0)
                {
                    valor = result.FirstOrDefault();
                }
            }
            return valor;
        }
    }
}

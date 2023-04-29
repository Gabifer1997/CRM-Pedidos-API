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
    public class PedidoServices
    {
        public async Task<List<PedidoModel>> BuscaPedidos(IConfiguration configuration) => await new PedidoDAL().BuscaPedidos(configuration);
        public async Task<int> AdicionaPedidos(IConfiguration configuration, PedidoRequestModel pedido)
        {
            var produto = await new ProdutoServices().BuscaProdutosById(configuration, pedido.ProdutoId);
            var pedidoId = 0;
            if (produto.Quantidade > pedido.Quantidade)
            {
                pedidoId = await new PedidoDAL().InsertPedidos(configuration, pedido);

                produto.Quantidade -= pedido.Quantidade;
                await new ProdutoServices().AlteraProdutos(configuration, produto);
            }
            else
                throw new Exception("Estoque Insuficiente");

            return pedidoId;
        }
        public async Task<bool> CancelaPedidos(IConfiguration configuration, int codigoPedido)
        {
            var pedido = await BuscaPedidosDetalhadoById(configuration, codigoPedido);
            pedido.StatusId = await new StatusServices().BuscaStatusIdByDescricao(configuration, "Cancelado");

            return await AlteraPedidos(configuration, new PedidoModel()
            {
                PedidoId = codigoPedido,
                Apagado = pedido.Apagado,
                StatusId = pedido.StatusId,
                Quantidade = pedido.Quantidade,
                ClienteId = pedido.ClienteId,
                ProdutoId = pedido.ProdutoId
            });
        }
        public async Task<bool> AlteraPedidos(IConfiguration configuration, PedidoModel pedido)
        {
            var pedidoAntigo = await BuscaPedidosDetalhadoById(configuration, pedido.PedidoId);
            var produto = await new ProdutoServices().BuscaProdutosById(configuration, pedido.ProdutoId);
            produto.Quantidade += pedidoAntigo.Quantidade;
            await new ProdutoServices().AlteraProdutos(configuration, produto);
            return await new PedidoDAL().UpdatePedidos(configuration, pedido);
        }
        public async Task<bool> ApagaPedidos(IConfiguration configuration, int codigoPedido) => await new PedidoDAL().ApagaPedidos(configuration, codigoPedido);
        public async Task<List<PedidoDetalhadoModel>> BuscaPedidosDetalhado(IConfiguration configuration) => await new PedidoDAL().BuscaPedidosDetalhado(configuration);
        public async Task<List<PedidoDetalhadoModel>> BuscaPedidosDetalhadoByClienteDocumento(IConfiguration configuration, string documento) => await new PedidoDAL().BuscaPedidosDetalhadoByClienteDocumento(configuration, documento);
        public async Task<PedidoDetalhadoModel> BuscaPedidosDetalhadoById(IConfiguration configuration, int pedidoId) => await new PedidoDAL().BuscaPedidosDetalhadoById(configuration, pedidoId);
    }
}

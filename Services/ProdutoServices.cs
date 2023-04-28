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
    public class ProdutoServices
    {
        public async Task<List<ProdutoModel>> BuscaProdutos(IConfiguration configuration) => await new ProdutoDAL().BuscaProdutos(configuration);
        public async Task<int> AdicionaProdutos(IConfiguration configuration, ProdutoModel produto) => await new ProdutoDAL().InsertProdutos(configuration, produto);
        public async Task<bool> AlteraProdutos(IConfiguration configuration, ProdutoModel produto) => await new ProdutoDAL().UpdateProdutos(configuration, produto);
        public async Task<bool> ApagaProdutos(IConfiguration configuration, int codigoProduto) => await new ProdutoDAL().ApagaProdutos(configuration, codigoProduto);
        public async Task<ProdutoModel> BuscaProdutosById(IConfiguration configuration, int produtoId) => await new ProdutoDAL().BuscaProdutosById(configuration, produtoId);
    }
}

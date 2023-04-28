# Projeto API CRM
## Resumo

O projeto consiste na criação de uma Rest API utilizando C#, esta API tem como função ser um  simples CRM de controle de pedido, podendo adicionar produtos, clientes, e pedidos.
O projeto também tem como função alteração dos dados de todas as tabelas como também cancelamentos dos pedidos.

## Material utilizado

Para realização deste projeto foi necessário algumas ferramentas:

 1. Linguagem C#
 2. Visual Studio 2022
 3. Microsoft SQL Server
 4. .NET

## Os Endpoint desenvolvidos na API

 1. Cliente
 - `/pedidosAPI/Cliente/BuscaClientes`
 - `/pedidosAPI/Cliente/BuscaClientesById`
 - `/pedidosAPI/Cliente/AdicionaClientes`
 - `/pedidosAPI/Cliente/AlteraClientes`
 - `/pedidosAPI/Cliente/ApagaClientes`
 2. Pedido
  - `/pedidosAPI/Pedido/BuscaPedidos`
 - `/pedidosAPI/Pedido/BuscaPedidosDetalhado`
 - `/pedidosAPI/Pedido/BuscaPedidosDetalhadoByClienteDocumento`
 - `/pedidosAPI/Pedido/BuscaPedidosDetalhadoById`
 - `/pedidosAPI/Pedido/AdicionaPedidos`
 - `/pedidosAPI/Pedido/CancelaPedidos`
 - `/pedidosAPI/Pedido/ApagaPedidos`
 3. Produto
 - `/pedidosAPI/Produto/BuscaProdutos`
 - `/pedidosAPI/Produto/BuscaProdutosById`
 - `/pedidosAPI/Produto/AdicionaProdutos`
 - `/pedidosAPI/Produto/AlteraProdutos`
 - `/pedidosAPI/Produto/ApagaProdutos`
 4. Status
 - `/pedidosAPI/Status/BuscaStatus`
 - `/pedidosAPI/Status/BuscaStatusById`
 - `/pedidosAPI/Status/AdicionaStatus`
 - `/pedidosAPI/Status/AlteraStatus`
 - `/pedidosAPI/Status/ApagaStatus`

## Funcionamento da API

 1. Listar todas os produtos, pedidos, clientes, status, pedidos detalhados
 2. Listar por id: produtos, pedidos, clientes, status, pedidos detalhados
 3. Adicionar novos produtos, pedidos, clientes, status, pedidos detalhados. Redução de estoque com a quantidade do pedido adicionado
 4. Atualizar produtos, clientes, status, pedidos detalhados
 5. Cancelar pedidos e atualizar estoque com a adição da quantidade do pedido cancelado
 6. Apagar produtos, pedidos, clientes, status, pedidos detalhados

## Como utilizar o projeto

 - `Compilar o projeto`: Compilar o projeto para que suas dependências sejam instaladas.


using Strategy.Interfaces;
using Strategy.Models;

namespace Strategy.Services;

public class PagamentoCartaoCreditoService : IPagamentoCartaoCreditoService
{
    private readonly IPagamentoCartaoCreditoFacade _pagamentoCartaoCreditoFacade;

    public PagamentoCartaoCreditoService(IPagamentoCartaoCreditoFacade pagamentoCartaoCreditoFacade)
    {
        _pagamentoCartaoCreditoFacade = pagamentoCartaoCreditoFacade;
    }

    public MeioPagamento MeioPagamento => MeioPagamento.CartaoCredito;

    public async Task<Pagamento> RealizarPagamento(Pedido pedido)
    {
        pedido.Pagamento.Valor = pedido.Produtos.Sum(p => p.Valor);
        Console.WriteLine("Iniciando Pagamento via Cartão de Crédito - Valor R$ " + pedido.Pagamento.Valor);

        if (_pagamentoCartaoCreditoFacade.RealizarPagamento(pedido, pedido.Pagamento))
        {
            pedido.Pagamento.Status = "Pago via Cartão de Crédito";
            return pedido.Pagamento;
        }

        pedido.Pagamento.Status = "Cartão de Crédito Recusado!";
        return pedido.Pagamento;
    }

}

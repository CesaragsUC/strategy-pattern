using Strategy.Interfaces;
using Strategy.Models;

namespace Strategy.Services;

public class PagamentoTransferenciaService : IPagamentoBoletoService
{
    private readonly IPagamentoTransferenciaFacade _pagamentoTransferenciaFacade;

    public PagamentoTransferenciaService(IPagamentoTransferenciaFacade pagamentoTransferenciaFacade)
    {
        _pagamentoTransferenciaFacade = pagamentoTransferenciaFacade;
    }

    public MeioPagamento MeioPagamento => MeioPagamento.TransferenciaBancaria;

    public async Task<Pagamento> RealizarPagamento(Pedido pedido)
    {
        pedido.Pagamento.Valor = pedido.Produtos.Sum(p => p.Valor);
        Console.WriteLine("Iniciando Pagamento via Transferência - Valor R$ " + pedido.Pagamento.Valor);

        pedido.Pagamento.ConfirmacaoTransferencia = _pagamentoTransferenciaFacade.RealizarTransferencia();
        pedido.Pagamento.Status = "Pago via Transferência";
        return pedido.Pagamento;
    }
}
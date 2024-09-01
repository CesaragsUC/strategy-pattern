using Strategy.Interfaces;
using Strategy.Models;

namespace Strategy.Services;

public class PagamentoBoletoService : IPagamentoBoletoService
{
    private readonly IPagamentoBoletoFacade _pagamentoBoletoFacade;

    public PagamentoBoletoService(IPagamentoBoletoFacade pagamentoBoletoFacade)
    {
        _pagamentoBoletoFacade = pagamentoBoletoFacade;
    }
    public MeioPagamento MeioPagamento => MeioPagamento.Boleto;

    public async Task<Pagamento> RealizarPagamento(Pedido pedido)
    {
        pedido.Pagamento.Valor = pedido.Produtos.Sum(p => p.Valor);
        Console.WriteLine("Iniciando Pagamento via Boleto - Valor R$ " + pedido.Pagamento.Valor);


        pedido.Pagamento.LinhaDigitavelBoleto = _pagamentoBoletoFacade.GerarBoleto();
        pedido.Pagamento.Status = "Aguardando Pagamento";
        return pedido.Pagamento;
    }
}

using Strategy.Interfaces;
using Strategy.Models;

namespace Strategy.Facade;

public class PagamentoCartaoCreditoFacade : IPagamentoCartaoCreditoFacade
{
    private readonly IPayPalGateway _payPalGateway;
    private readonly IConfiguration _configManager;

    public PagamentoCartaoCreditoFacade(IPayPalGateway payPalGateway, IConfiguration configManager)
    {
        _payPalGateway = payPalGateway;
        _configManager = configManager;
    }

    public bool RealizarPagamento(Pedido pedido, Pagamento pagamento)
    {
        var apiKey = _configManager.GetSection("PayPalSettings:ClientId");
        var encriptionKey = _configManager.GetSection("PayPalSettings:ClientSecret");

        var serviceKey = _payPalGateway.GetPayPalServiceKey(apiKey.Value!, encriptionKey.Value!);
        var cardHashKey = _payPalGateway.GetCardHashKey(serviceKey, pagamento.CartaoCredito);

        var pagamentoResult = _payPalGateway.CommitTransaction(cardHashKey, pedido.Id.ToString(), pagamento.Valor);

        return pagamentoResult;
    }
}

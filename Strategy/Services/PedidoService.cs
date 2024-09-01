using Strategy.Interfaces;
using Strategy.Models;

namespace Strategy.Services;

#region Opção Com service locator

/// <summary>
/// Opção com  (ServiceLocator). Service provider para criar a instancia do serviço de pagamento
/// </summary>
//public class PedidoService : IPedidoService
//{
//    private readonly IServiceProvider _serviceProvider;

//    public PedidoService(IServiceProvider serviceProvider)
//    {
//        _serviceProvider = serviceProvider;
//    }

//    public async Task<Pagamento> RealizarPagamento(Pedido pedido)
//    {
//        var _serviceType = CreatePagamento(pedido.Pagamento.MeioPagamento);
//        return await _serviceType.RealizarPagamento(pedido);
//    }

//    private IPagamento? CreatePagamento(MeioPagamento meioPagamento)
//    {
//        return meioPagamento switch
//        {
//            MeioPagamento.CartaoCredito => _serviceProvider.GetService<IPagamentoCartaoCreditoService>(),
//            MeioPagamento.Boleto => _serviceProvider.GetService<IPagamentoBoletoService>(),
//            MeioPagamento.TransferenciaBancaria => _serviceProvider.GetService<IPagamentoTransferenciaService>(),
//            _ => null
//        };
//    }
//}


#endregion



public class PedidoService : IPedidoService
{
    private readonly IEnumerable<IPagamento> _pagamentos;

    public PedidoService(IEnumerable<IPagamento> pagamentos)
    {
        _pagamentos = pagamentos;
    }

    public async Task<Pagamento> RealizarPagamento(Pedido pedido)
    {
        var _serviceType =  _pagamentos.FirstOrDefault(x=> x.MeioPagamento == pedido.Pagamento.MeioPagamento);

        if (_serviceType == null)
        {
            throw new ApplicationException("Meio de Pagamento não conhecido");
        }

        return await _serviceType.RealizarPagamento(pedido);
    }
}


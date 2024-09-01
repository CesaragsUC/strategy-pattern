using Strategy.Interfaces;
using Strategy.Models;

namespace Strategy.Factory;

public class PagamentoFactory : IPagamentoFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PagamentoFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IPagamento? CreatePagamento(MeioPagamento meioPagamento)
    {
        return meioPagamento switch
        {
            MeioPagamento.CartaoCredito => _serviceProvider.GetService<IPagamentoCartaoCreditoService>(),
            MeioPagamento.Boleto => _serviceProvider.GetService<IPagamentoBoletoService>(),
            MeioPagamento.TransferenciaBancaria => _serviceProvider.GetService<IPagamentoTransferenciaService>(),
            _ => null
        };
    }
}



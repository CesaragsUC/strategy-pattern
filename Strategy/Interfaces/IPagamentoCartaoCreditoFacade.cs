using Strategy.Models;

namespace Strategy.Interfaces;

public interface IPagamentoCartaoCreditoFacade : IFacade
{
    bool RealizarPagamento(Pedido pedido, Pagamento pagamento);
}

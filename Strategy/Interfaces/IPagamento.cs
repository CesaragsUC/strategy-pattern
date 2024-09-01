using Strategy.Models;

namespace Strategy.Interfaces;

public interface IPagamento : IServices
{
    MeioPagamento MeioPagamento { get; }
    Task<Pagamento> RealizarPagamento(Pedido pedido);
}

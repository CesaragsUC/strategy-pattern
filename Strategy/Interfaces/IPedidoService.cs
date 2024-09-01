using Strategy.Models;
using Strategy.Services;

namespace Strategy.Interfaces;

public interface IPedidoService : IServices
{
    Task<Pagamento> RealizarPagamento(Pedido pedido);
}

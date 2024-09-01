using Strategy.Models;

namespace Strategy.Interfaces;

public interface IPagamentoFactory : IServices
{
    IPagamento? CreatePagamento(MeioPagamento meioPagamento);
}
using Strategy.Interfaces;

namespace Strategy.Facade;

public class PagamentoTransferenciaFacade : IPagamentoTransferenciaFacade
{
    public string RealizarTransferencia()
    {
        // RealizarTransferencia
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}
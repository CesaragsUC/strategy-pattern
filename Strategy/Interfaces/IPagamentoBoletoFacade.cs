namespace Strategy.Interfaces;

public interface IPagamentoBoletoFacade : IFacade
{
    string GerarBoleto();
}
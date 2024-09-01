namespace Strategy.Interfaces;

public interface IPayPalGateway : IServices
{
    string GetPayPalServiceKey(string apiKey, string encriptionKey);
    string GetCardHashKey(string serviceKey, string cartaoCredito);
    bool CommitTransaction(string cardHashKey, string orderId, decimal amount);
}

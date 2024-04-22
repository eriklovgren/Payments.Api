using Payments.Api.Interfaces;
using Payments.Api.Models;

namespace Payments.Api.Implementations;

public class PaymentService
{
    private readonly Dictionary<string, IEnumerable<Payment>> _transactions = new();

    public bool SavePayment(string clientId, Payment payment)
    {
        _transactions.TryGetValue(clientId, out var clientTransactions);
        if (clientTransactions is null)
        {
            return _transactions.TryAdd(clientId, new List<Payment> {payment});
        }

        _transactions[clientId] = clientTransactions.Append(payment);

        return true;
    }
    
    public IEnumerable<Payment>? GetPayments(string clientId)
    {
        _transactions.TryGetValue(clientId, out var clientTransactions);
        return clientTransactions;
    }
}
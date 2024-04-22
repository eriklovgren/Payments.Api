using Payments.Api.Models;

namespace Payments.Api.Interfaces;

public interface ITransactionService
{
    
    public Task<Guid?> InitiatePayment(Payment payment, string clientId);
    public IEnumerable<Payment>? TransactionsForClient(string clientId);

}
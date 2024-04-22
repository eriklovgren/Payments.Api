using Payments.Api.Interfaces;
using Payments.Api.Models;

namespace Payments.Api.Implementations;

public class TransactionService : ITransactionService
{
    private readonly PaymentService _paymentService;

    public TransactionService(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    public Task<Guid?> InitiatePayment(Payment payment, string clientId)
    {
        Thread.Sleep(3000);

        payment.PaymentId = Guid.NewGuid();
        _paymentService.SavePayment(clientId, payment);

        return Task.FromResult(payment.PaymentId);
    }
    
    public IEnumerable<Payment>? TransactionsForClient(string clientId)
    {
        return _paymentService.GetPayments(clientId);
    }
}
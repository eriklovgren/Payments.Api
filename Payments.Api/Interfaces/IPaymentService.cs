using Payments.Api.Models;

namespace Payments.Api.Interfaces;

public interface IPaymentService
{
    public Task<Guid> InitiatePayment(Payment payment, string clientId);
}
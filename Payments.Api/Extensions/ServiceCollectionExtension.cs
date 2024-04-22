using Payments.Api.Implementations;
using Payments.Api.Interfaces;

namespace Payments.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPaymentServices(this IServiceCollection services)
    {
        services.AddTransient<ITransactionService, TransactionService>();
        services.AddSingleton<ClientService>();
        services.AddSingleton<PaymentService>();
    }
}
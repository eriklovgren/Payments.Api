using Microsoft.Extensions.Primitives;
using Payments.Api.Interfaces;
using Payments.Api.Models;

namespace Payments.Api.Implementations;

public class ClientService
{
    
    private readonly Dictionary<string, Payment> _activeTransactions = new();

    public IEnumerable<string> ActiveTransactions => _activeTransactions.Keys;
    public bool TryAddTransaction(string clientId, Payment payment) => _activeTransactions.TryAdd(clientId, payment);
    public bool TryGetTransaction(string clientId) => _activeTransactions.TryGetValue(clientId, out _);
    public bool CompleteTransaction(string clientId) => _activeTransactions.Remove(clientId);
}
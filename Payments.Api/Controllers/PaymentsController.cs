using Microsoft.AspNetCore.Mvc;
using Payments.Api.Extensions;
using Payments.Api.Implementations;
using Payments.Api.Interfaces;
using Payments.Api.Models;

namespace Payments.Api.Controllers;

[ApiController]
[Route("payments")]
public class PaymentsController : ControllerBase
{
    private readonly ILogger<PaymentsController> _logger;
    private readonly ITransactionService _transactionService;
    private readonly ClientService _clientService;

    public PaymentsController(
        ILogger<PaymentsController> logger,
        ITransactionService transactionService,
        ClientService clientService)
    {
        _logger = logger;
        _transactionService = transactionService;
        _clientService = clientService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Get(Payment payment)
    {
        var clientId = HttpContext.Request.ClientIdFromHeader();

        if (string.IsNullOrEmpty(clientId))
        {
            return BadRequest("Client-ID is required");
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var transactionCanStart = _clientService.TryAddTransaction(clientId, payment);
        if (!transactionCanStart)
        {
            return Conflict("Transaction with Client ID is already running.");
        }
        
        // Initiate Transaction
        var transactionId = await _transactionService.InitiatePayment(payment, clientId);
        
        // Remove client id from ActiveTransactions
        _clientService.CompleteTransaction(clientId);
        
        return Created("created", transactionId);
    }
}
using Microsoft.AspNetCore.Mvc;
using Payments.Api.Interfaces;

namespace Payments.Api.Controllers;

[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ILogger<TransactionsController> _logger;
    private readonly ITransactionService _transactionService;

    public TransactionsController(
        ILogger<TransactionsController> logger,
        ITransactionService transactionService)
    {
        _logger = logger;
        _transactionService = transactionService;
    }

    [HttpGet("accounts/{iban}/transactions")]
    public IActionResult Get(string iban)
    {
        var result = _transactionService.TransactionsForClient(iban);

        if (result is null)
        {
            return NoContent();
        }
        return Ok(_transactionService.TransactionsForClient(iban));
    }
}
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

    /// <summary>
    ///     Gets a list of transactions for a given account
    /// </summary>
    /// <param name="iban">Iban of the account</param>
    /// <returns>"History of transactions for a account"</returns>
    /// <response code="200">Successfully fetched transactions.</response>
    /// <response code="204">No content if there are no transactions connected to the Client ID.</response>
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
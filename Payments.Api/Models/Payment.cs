using System.ComponentModel.DataAnnotations;

namespace Payments.Api.Models;

public class Payment
{
    public Guid? PaymentId { get; set; }

    public required decimal TransactionAmount { get; set; }
    
    [CurrencyValidator]
    public required string Currency { get; set; }
    
    [RegularExpression("^[a-zA-Z0-9]*$")]
    [StringLength(34)]
    public required string DebtorAccount { get; set; }

    [RegularExpression("^[a-zA-Z0-9]*$")]
    [StringLength(34)]
    public required string CreditorAccount { get; set; }
    
}
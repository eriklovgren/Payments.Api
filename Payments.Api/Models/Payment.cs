using System.ComponentModel.DataAnnotations;

namespace Payments.Api.Models;

public class Payment
{
    public Guid? PaymentId { get; set; }

    [Required(ErrorMessage = "Transaction Amount is required.")]
    public decimal TransactionAmount { get; set; }
    
    [Required(ErrorMessage = "Currency is required.")]
    [CurrencyValidator]
    public string Currency { get; set; }
    
    [Required(ErrorMessage = "Debtor Account is required.")]
    [RegularExpression("^[a-zA-Z0-9]*$")]
    [StringLength(34)]
    public string DebtorAccount { get; set; }

    [Required(ErrorMessage = "Creditor Account is required.")]
    [RegularExpression("^[a-zA-Z0-9]*$")]
    [StringLength(34)]
    public string CreditorAccount { get; set; }
    
}
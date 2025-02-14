using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Shared.RequestModel
{
    public class PaymentReviewRequestModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "Beneficiary must be at least 1 characters long.")]
        public required string BeneficiaryId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Account number must be at least 1 characters long.")]
        public required string AccountNumber { get; set; }   

        public decimal Amount { get; set; }
    }
}

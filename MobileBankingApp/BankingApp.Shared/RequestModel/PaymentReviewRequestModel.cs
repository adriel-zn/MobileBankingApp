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
        public string? BeneficiaryId { get; set; }

        public string? AccountNumber { get; set; }   

        public decimal Amount { get; set; }
    }
}

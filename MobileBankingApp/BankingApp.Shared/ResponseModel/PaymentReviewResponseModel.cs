using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Shared.ResponseModel
{
    public class PaymentReviewResponseModel
    {
        public string InstructionIdentifier { get; set; }
        public decimal Fees { get; set; }
    }
}

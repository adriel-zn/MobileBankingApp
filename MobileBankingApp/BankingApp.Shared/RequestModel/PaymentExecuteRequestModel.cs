using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Shared.RequestModel
{
    public class PaymentExecuteRequestModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "Instruction identifier must be at least 1 characters long.")]
        public required string InstructionIdentifier { get; set; }
    }
}

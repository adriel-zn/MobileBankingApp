using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Shared.ResponseModel
{
    public class PaymentExecuteResponseModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "Instruction reference must be at least 1 characters long.")]
        public required string InstructionReference { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Shared.Models
{
    public class AccountBeneficiaryModel
    {
        public IList<AccountModel> Accounts { get; set; }

        public IList<BeneficiaryModel> Beneficiaries { get; set; }
    }
}

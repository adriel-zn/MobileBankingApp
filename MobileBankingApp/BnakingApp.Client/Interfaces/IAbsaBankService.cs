using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Shared.Models;

namespace BankingApp.Client.Interfaces
{
    public interface IAbsaBankService
    {
        #region GET METHODS
        Task<BeneficiaryModel> PaymentInitialiseAsync();
        #endregion
    }
}

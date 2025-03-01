﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Shared.Models;
using BankingApp.Shared.RequestModel;
using BankingApp.Shared.ResponseModel;

namespace BankingApp.Client.Interfaces
{
    public interface IAbsaBankService
    {
        #region GET METHODS
        Task<AccountBeneficiaryModel> PaymentInitialiseAsync();
        #endregion

        #region POST METHOD
        Task<PaymentReviewResponseModel> SubmitPaymentReviewAsync(PaymentReviewRequestModel paymentReviewRequestModel);
        Task<PaymentExecuteResponseModel> SubmitPaymentExecuteAsync(PaymentExecuteRequestModel paymentExecuteRequestModel);
        #endregion
    }

}

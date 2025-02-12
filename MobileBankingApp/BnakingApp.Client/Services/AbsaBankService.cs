using System.Net.Http.Json;
using BankingApp.Client.Interfaces;
using BankingApp.Shared.Models;
using BnakingApp.Client;

namespace BankingApp.Client.Services
{
    public class AbsaBankService : IAbsaBankService
    {
        private readonly BankingHttpClient _bankingHttpClient;

        public AbsaBankService(BankingHttpClient bankingHttpClient)
        {
            _bankingHttpClient = bankingHttpClient;
        }


        #region GET METHOD
        public async Task<BeneficiaryModel> PaymentInitialiseAsync()
        {
            var uri = $"https://testbankapi.azurewebsites.net/PaymentInitialise";
            return await _bankingHttpClient.HttpClient.GetFromJsonAsync<BeneficiaryModel>(uri) 
                ?? throw new Exception("Error occurred while retrieving data for payment initialise api.");
        }
        #endregion


        #region POST METHOD
        public async Task<>


        #endregion
    }
}

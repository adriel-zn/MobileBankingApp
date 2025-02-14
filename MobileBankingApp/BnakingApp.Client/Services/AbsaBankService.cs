using System.Net.Http.Json;
using System.Text.Json;
using BankingApp.Client.Interfaces;
using BankingApp.Shared.Models;
using BankingApp.Shared.RequestModel;
using BankingApp.Shared.ResponseModel;
using BankingApp.Client;
using System.Text;
using System;

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
        public async Task<AccountBeneficiaryModel> PaymentInitialiseAsync()
        {
            var uri = $"https://testbankapi.azurewebsites.net/PaymentInitialise";
            return await _bankingHttpClient.HttpClient.GetFromJsonAsync<AccountBeneficiaryModel>(uri)
                ?? throw new Exception("Error occurred while retrieving data for payment initialise api.");
        }
        #endregion


        #region POST METHOD
        public async Task<PaymentReviewResponseModel> PaymentReviewAsync(PaymentReviewRequestModel paymentReviewRequestModel)
        {
            try
            {
                var uri = $"https://testbankapi.azurewebsites.net/PaymentReview";
                var jsonContent = JsonSerializer.Serialize(paymentReviewRequestModel,
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _bankingHttpClient.HttpClient.PostAsync(uri, content);
                string responseBody = await response.Content.ReadAsStringAsync();


                var responseModel = JsonSerializer.Deserialize<PaymentReviewResponseModel>(responseBody);
                return responseModel;
            }
            catch (JsonException ex)
            {
                throw new Exception($"Invalid JSON: {ex.Message}");

            }


        }

        public async Task<PaymentExecuteResponseModel> PaymentExecuteAsync(PaymentExecuteRequestModel paymentExecuteRequestModel)
        {
            try
            {
                var uri = $"https://testbankapi.azurewebsites.net/PaymentExecute";
                var jsonContent = JsonSerializer.Serialize(paymentExecuteRequestModel, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                var response = await _bankingHttpClient.HttpClient.PostAsJsonAsync(uri, jsonContent);
                var responseBody = await response.Content.ReadAsStringAsync();

                var responseModel = JsonSerializer.Deserialize<PaymentExecuteResponseModel>(responseBody);
                return responseModel;
            }
            catch (JsonException ex)
            {
                throw new Exception($"Invalid JSON: {ex.Message}");

            }
        }
        #endregion
    }
}

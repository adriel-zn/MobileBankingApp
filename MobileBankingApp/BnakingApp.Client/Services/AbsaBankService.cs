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
        public async Task<PaymentReviewResponseModel> SubmitPaymentReviewAsync(PaymentReviewRequestModel paymentReviewRequestModel)
        {
            try
            {
                var uri = "https://testbankapi.azurewebsites.net/PaymentReview";
                var jsonContent = JsonSerializer.Serialize(paymentReviewRequestModel,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                using HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await _bankingHttpClient.HttpClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP Request failed with status code {response.StatusCode}");
                }

                string responseBody = await response.Content.ReadAsStringAsync();

                var responseModel = JsonSerializer.Deserialize<PaymentReviewResponseModel>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (responseModel == null)
                {
                    throw new JsonException("Deserialized response is null.");
                }

                return responseModel;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error in HTTP request: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Invalid JSON response: {ex.Message}", ex);
            }
        }

        public async Task<PaymentExecuteResponseModel> SubmitPaymentExecuteAsync(PaymentExecuteRequestModel paymentExecuteRequestModel)
        {
            try
            {
                //return new PaymentExecuteResponseModel() { InstructionReference = "222222222" };

                var uri = $"https://testbankapi.azurewebsites.net/PaymentExecute";
                var jsonContent = JsonSerializer.Serialize(paymentExecuteRequestModel,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                using HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await _bankingHttpClient.HttpClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP Request failed with status code {response.StatusCode}");
                }

                string responseBody = await response.Content.ReadAsStringAsync();

                var responseModel = JsonSerializer.Deserialize<PaymentExecuteResponseModel>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (responseModel == null)
                {
                    throw new JsonException("Deserialized response is null.");
                }

                return responseModel;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error in HTTP request: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Invalid JSON response: {ex.Message}", ex);
            }
        }
        #endregion
    }
}

namespace BankingApp.Client
{
    public class BankingHttpClient
    {
        public HttpClient HttpClient { get; }

        public BankingHttpClient(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("UserKey", "12345678");
            HttpClient = httpClient;            
        }
    }
}

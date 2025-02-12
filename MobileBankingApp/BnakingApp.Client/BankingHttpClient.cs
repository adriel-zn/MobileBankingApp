namespace BnakingApp.Client
{
    public class BankingHttpClient
    {
        public HttpClient HttpClient { get; set; }

        public BankingHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}

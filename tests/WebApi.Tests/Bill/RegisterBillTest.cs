using CommonTestsLibraries;

namespace WebApi.Tests.Bill
{
    public  class RegisterBillTest : IClassFixture<CustomWebApplicatioFactory>
    {
        private readonly HttpClient _httpClient;

        private const string METHOD = "api/fatura";

        public RegisterBillTest(CustomWebApplicatioFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        public async Task Sucess()
        {

        }
    }
}

using CommonTestsLibraries;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace WebApi.Tests.Users.Register
{
    public class RegisterUserTest : IClassFixture<CustomWebApplicatioFactory>
    {
        private readonly HttpClient _httpClient;

        private const string METHOD = "api/user";

        public RegisterUserTest(CustomWebApplicatioFactory webHttp)
        {
            _httpClient = webHttp.CreateClient();
        }

        [Fact]  
        public async Task Sucess()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var result = await _httpClient.PostAsJsonAsync(METHOD, request);

            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}

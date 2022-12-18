using Calculator.Web.IntegrationTests.Infrastructure;
using Calculator.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calculator.Web.IntegrationTests
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public async Task Get_EndpointReturnsAllData() {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            var testServer = new TestServer(builder);
            var httpClient = testServer.CreateClient();

            var result = await httpClient.GetAsync("/calculator/operations");

            result.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Get_UseApp_EndpointReturnsAllData() {
            var app = new CalculatorApplication();
            var client = app.CreateClient();

            var result = await client.GetAsync("/calculator/operations");

            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var serializationOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var parsedResult = JsonSerializer.Deserialize<IReadOnlyCollection<CalculatorOperationViewModel>>(content, serializationOptions);
        }
    }
}
using Calculator.Web.Data.Models;
using Calculator.Web.Data.Source;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Calculator.Web.IntegrationTests.Infrastructure
{
    public class CalculatorApplication : WebApplicationFactory<Startup>
    {
        protected override IHost CreateHost(IHostBuilder builder) {
            SetupData();

            return base.CreateHost(builder);
        }

        // TODO: Call reset of data after each test.
        private void SetupData() {
            var source = CalculatorOperationsSource.Source;
            source.Clear();
            source.AddRange(new List<CalculatorOperation> {
                new CalculatorOperation {
                    Id = "1",
                    
                },
                new CalculatorOperation {
                    Id = "2"
                }
            });

        }
    }
}

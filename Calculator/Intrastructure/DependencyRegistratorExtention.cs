using Calculator.Web.Data;
using Calculator.Web.Data.Implementations;
using Calculator.Web.Operations;
using Calculator.Web.Operations.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator.Web.Intrastructure
{
    public static class DependencyRegistratorExtention
    {
        public static void RegisterDependencies(this IServiceCollection serviceCollection) {
            serviceCollection.AddScoped<ICalculatorOperationsRepository, CalculatorOperationsRepository>()
                             .AddScoped<IGetAllCalculatorOperationsOperation, GetAllCalculatorOperationsOperation>()
                             .AddScoped<IGetCalculatorOperationOperation, GetCalculatorOperationOperation>()
                             .AddScoped<IPlusOperation, PlusOperation>()
                             .AddScoped<IIdProvider, IdProvider>()
                             .AddTransient(typeof(Lazy<>), typeof(Lazy<>));

        }
    }
}

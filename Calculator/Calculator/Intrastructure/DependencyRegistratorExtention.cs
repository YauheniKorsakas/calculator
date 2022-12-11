using Calculator.Data;
using Calculator.Data.Implementations;
using Calculator.Operations;
using Calculator.Operations.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator.Intrastructure
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

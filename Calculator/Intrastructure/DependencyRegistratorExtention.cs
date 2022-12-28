using Calculator.Web.Data;
using Calculator.Web.Data.Implementations;
using Calculator.Web.Operations;
using Calculator.Web.Operations.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
                             .AddTransient(typeof(Lazy<>), typeof(Lazy<>)); // Does not work with default serviceCollection

        }

        /// <summary>
        /// possible implementation of resolving lazy instance for service collection.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AsLazy(this IServiceCollection serviceCollection) {
            var lastRegistration = serviceCollection.Last();
            var lazyServiceType = typeof(Lazy<>).MakeGenericType(lastRegistration.ServiceType);
            var lazyImplementationType = typeof(Lazy<>).MakeGenericType(lastRegistration.ImplementationType);
            var serviceDescriptor = new ServiceDescriptor(
                lazyServiceType,
                serviceLocator => Activator.CreateInstance(lazyImplementationType, serviceLocator.GetRequiredService(lastRegistration.ServiceType)),
                lastRegistration.Lifetime);
            serviceCollection.Add(serviceDescriptor);

            return serviceCollection;
        }
    }
}

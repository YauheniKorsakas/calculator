using AutoMapper;
using Calculator.Web.Data;
using Calculator.Web.Data.Models;
using Calculator.Web.ViewModels;
using System;

namespace Calculator.Web.Operations.Implementations
{
    public class PlusOperation : IPlusOperation
    {
        private readonly ICalculatorOperationsRepository calculatorOperationsRepository;
        private readonly IMapper mapper;

        public PlusOperation(ICalculatorOperationsRepository calculatorOperationsRepository, IMapper mapper) {
            this.calculatorOperationsRepository = calculatorOperationsRepository ?? throw new ArgumentNullException(nameof(calculatorOperationsRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Execute(double first, double second) {
            var result = first + second;
            var operation = new CalculatorOperationViewModel {
                FirstArgument = first,
                SecondArgument = second,
                OperationName = nameof(PlusOperation),
                OperationResult = result
            };
            var toSave = mapper.Map<CalculatorOperation>(operation);
            calculatorOperationsRepository.Add(toSave);
        }
    }
}

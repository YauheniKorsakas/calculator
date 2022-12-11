using AutoMapper;
using Calculator.Data;
using Calculator.Data.Models;
using Calculator.ViewModels;
using System;

namespace Calculator.Operations.Implementations
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

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

        public PlusOperation(ICalculatorOperationsRepository calculatorOperationsRepository) {
            this.calculatorOperationsRepository = calculatorOperationsRepository ?? throw new ArgumentNullException(nameof(calculatorOperationsRepository));
        }

        public void Execute(double firstOperand, double secondOperand) {
            var result = firstOperand + secondOperand;
            // Could be potentially moved into another entity that maps props directly.
            var toSave = new CalculatorOperation {
                FirstOperand = firstOperand,
                SecondOperand = secondOperand,
                OperationName = nameof(PlusOperation),
                OperationResult = result
            };
            calculatorOperationsRepository.Add(toSave);
        }
    }
}

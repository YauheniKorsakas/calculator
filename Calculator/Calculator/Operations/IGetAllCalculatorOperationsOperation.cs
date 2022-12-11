using Calculator.ViewModels;
using System.Collections.Generic;

namespace Calculator.Operations
{
    public interface IGetAllCalculatorOperationsOperation
    {
        IReadOnlyCollection<CalculatorOperationViewModel> Execute();
    }
}

using Calculator.Web.ViewModels;
using System.Collections.Generic;

namespace Calculator.Web.Operations
{
    public interface IGetAllCalculatorOperationsOperation
    {
        IReadOnlyCollection<CalculatorOperationViewModel> Execute();
    }
}

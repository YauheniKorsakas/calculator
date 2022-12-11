using Calculator.Web.ViewModels;

namespace Calculator.Web.Operations
{
    public interface IGetCalculatorOperationOperation
    {
        CalculatorOperationViewModel Execute(string id);
    }
}

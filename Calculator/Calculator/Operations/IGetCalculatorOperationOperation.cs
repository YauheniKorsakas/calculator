using Calculator.ViewModels;

namespace Calculator.Operations
{
    public interface IGetCalculatorOperationOperation
    {
        CalculatorOperationViewModel Execute(string id);
    }
}

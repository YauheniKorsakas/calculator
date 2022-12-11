namespace Calculator.Web.ViewModels
{
    public class CalculatorOperationViewModel
    {
        public string Id { get; set; }
        public string OperationName { get; set; }
        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public double OperationResult { get; set; }
    }
}

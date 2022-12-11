namespace Calculator.Web.Data.Models
{
    public class CalculatorOperation
    {
        public string Id { get; set; }
        public string OperationName { get; set; }
        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public double OperationResult { get; set; }
    }
}

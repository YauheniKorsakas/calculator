﻿namespace Calculator.ViewModels
{
    public class CalculatorOperationViewModel
    {
        public string Id { get; set; }
        public string OperationName { get; set; }
        public double FirstArgument { get; set; }
        public double SecondArgument { get; set; }
        public double OperationResult { get; set; }
    }
}

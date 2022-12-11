using AutoMapper;
using Calculator.Data.Models;
using Calculator.ViewModels;

namespace Calculator.Mapper
{
    public class CalculatorOperationsProfile : Profile
    {
        public CalculatorOperationsProfile() {
            CreateMap<CalculatorOperation, CalculatorOperationViewModel>().ReverseMap();
        }
    }
}

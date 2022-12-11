using AutoMapper;
using Calculator.Web.Data.Models;
using Calculator.Web.ViewModels;

namespace Calculator.Web.Mapper
{
    public class CalculatorOperationsProfile : Profile
    {
        public CalculatorOperationsProfile() {
            CreateMap<CalculatorOperation, CalculatorOperationViewModel>().ReverseMap();
        }
    }
}

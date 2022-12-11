using AutoMapper;
using Calculator.Data;
using Calculator.ViewModels;
using System;
using System.Collections.Generic;

namespace Calculator.Operations.Implementations
{
    public class GetAllCalculatorOperationsOperation : IGetAllCalculatorOperationsOperation
    {
        private readonly ICalculatorOperationsRepository repository;
        private readonly IMapper mapper;

        public GetAllCalculatorOperationsOperation(ICalculatorOperationsRepository repository, IMapper mapper) {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IReadOnlyCollection<CalculatorOperationViewModel> Execute() {
            var operations = repository.Get();
            var result = mapper.Map<IReadOnlyCollection<CalculatorOperationViewModel>>(operations);

            return result;
        }
    }
}

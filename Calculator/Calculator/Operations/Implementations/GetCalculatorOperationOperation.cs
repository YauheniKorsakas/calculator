using AutoMapper;
using Calculator.Data;
using Calculator.ViewModels;
using System;

namespace Calculator.Operations.Implementations
{
    public class GetCalculatorOperationOperation : IGetCalculatorOperationOperation
    {
        private readonly ICalculatorOperationsRepository repository;
        private readonly IMapper mapper;

        public GetCalculatorOperationOperation(ICalculatorOperationsRepository repository, IMapper mapper) {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public CalculatorOperationViewModel Execute(string id) {
            var operationById = repository.Get(id);
            var result = mapper.Map<CalculatorOperationViewModel>(operationById);

            return result;
        }
    }
}

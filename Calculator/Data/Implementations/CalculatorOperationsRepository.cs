using Calculator.Web.Data.Models;
using Calculator.Web.Data.Source;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Web.Data.Implementations
{
    public class CalculatorOperationsRepository : BaseRepository, ICalculatorOperationsRepository
    {
        public CalculatorOperationsRepository(IIdProvider idProvider) : base(idProvider) { }

        public void Add(CalculatorOperation model) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            if (!string.IsNullOrEmpty(model.Id)) throw new ArgumentException("Model should not contain model id for save.");
            model.Id = GetId();
            CalculatorOperationsSource.Source.Add(model);
        }

        public void Delete(string id) {
            CalculatorOperationsSource.Source.RemoveAll(s => s.Id == id);
        }

        public CalculatorOperation Get(string id) => CalculatorOperationsSource.Source.FirstOrDefault(s => s.Id == id);

        public IReadOnlyCollection<CalculatorOperation> Get() => CalculatorOperationsSource.Source;
    }
}

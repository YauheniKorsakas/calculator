using System.Collections.Generic;

namespace Calculator.Data
{
    public interface IGenericRepository<T> where T: class
    {
        T Get(string id);
        IReadOnlyCollection<T> Get();
        void Add(T model);
        void Delete(string id);
    }
}

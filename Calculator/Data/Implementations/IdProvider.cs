using System;

namespace Calculator.Web.Data.Implementations
{
    public class IdProvider : IIdProvider
    {
        public string GetId() => Guid.NewGuid().ToString().Substring(0, 6);
    }
}

using System;

namespace Calculator.Web.Data
{
    public abstract class BaseRepository : IIdProvider
    {
        private readonly IIdProvider idProvider;

        public BaseRepository(IIdProvider idProvider) {
            this.idProvider = idProvider ?? throw new ArgumentNullException(nameof(idProvider));
        }

        public string GetId() => idProvider.GetId();
    }
}

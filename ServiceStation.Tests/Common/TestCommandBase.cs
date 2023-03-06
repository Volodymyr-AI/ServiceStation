using ServiceStation.Persistense;

namespace ServiceStation.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly AppDbContext Context;

        public TestCommandBase()
        {
            Context = ServiceStationContextFactory.Create();
        }
        public void Dispose()
        {
            ServiceStationContextFactory.Destroy(Context);
        }
    }
}

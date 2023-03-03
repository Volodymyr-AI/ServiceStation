using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Interfaces;
using ServiceStation.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public AppDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = ServiceStationContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IAppDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();  
        }

        public void Dispose()
        {
            ServiceStationContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

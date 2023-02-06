using ServiceStation.API.Entities;
using System.Reflection;

namespace ServiceStation.API.Controllers
{
    public static class IncludedEntities
    {
        public static IReadOnlyList<TypeInfo> Types;

        static IncludedEntities()
        {
            var assembly = typeof(IncludedEntities).GetTypeInfo().Assembly;
            var typeList = new List<TypeInfo>();

            foreach(Type type in assembly.GetTypes())
            {
                if(type.GetCustomAttributes(typeof(Vehicle), true).Length > 0)
                {
                    typeList.Add(type.GetTypeInfo());
                }
            }
            Types = typeList;
        }
    }
}

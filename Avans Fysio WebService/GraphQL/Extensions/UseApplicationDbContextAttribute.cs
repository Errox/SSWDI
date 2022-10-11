using Fysio_Codes.DAL;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace Avans_Fysio_WebService.GraphQL.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<FysioCodeDbContext>();
        }
    }

}

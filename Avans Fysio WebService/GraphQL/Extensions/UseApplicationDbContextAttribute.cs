using HotChocolate.Types.Descriptors;
using HotChocolate.Types;
using System.Reflection;
using Fysio_Codes.DAL;

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

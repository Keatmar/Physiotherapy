using Physiotherapy.Context;
using Physiotherapy.Model;

namespace Physiotherapy.IDA
{
    public interface IRoleDA
    {
        RoleVO FindAdminRole(RoleContext ctx);
    }
}
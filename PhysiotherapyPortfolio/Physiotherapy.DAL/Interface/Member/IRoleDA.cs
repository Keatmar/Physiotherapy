using Physiotherapy.Context;
using Physiotherapy.Model;

namespace Physiotherapy.IDA
{
    public interface IRoleDA
    {
        /// <summary>
        /// Find admin role
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        RoleVO FindAdminRole(RoleContext ctx);

        /// <summary>
        /// Find role by id
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleVO FindRoleById(RoleContext ctx, int id);
    }
}
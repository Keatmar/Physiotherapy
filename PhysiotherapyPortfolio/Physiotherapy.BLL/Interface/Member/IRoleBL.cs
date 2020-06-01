using Physiotherapy.Model;

namespace Physiotherapy.BLL.Interface
{
    public interface IRoleBL
    {
        /// <summary>
        /// Get admin role
        /// </summary>
        /// <returns></returns>
        RoleVO GetAdminRole();

        /// <summary>
        /// Get role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleVO GetRoleById(int id);
    }
}
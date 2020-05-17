using Physiotherapy.BLL.Interface;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.Model;
using System;

namespace Physiotherapy.BLL
{
    public class RoleBL : IRoleRepository
    {
        /// <summary>
        /// Get Admin Role
        /// </summary>
        /// <returns></returns>
        public RoleVO GetAdminRole()
        {
            RoleVO roles;
            try
            {
                using (var _ctx = new RoleContext())
                {
                    roles = new RoleDA().FindAdminRole(_ctx);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return roles;
        }
    }
}
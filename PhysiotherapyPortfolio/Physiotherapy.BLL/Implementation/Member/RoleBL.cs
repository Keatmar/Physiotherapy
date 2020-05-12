using Physiotherapy.BLL.Interface;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.BLL
{
    public  class RoleBL :IRoleRepository
    {
       
        /// <summary>
        /// Get Admin Role
        /// </summary>
        /// <returns></returns>
        public RoleVO GetAdminRole()
        {
            RoleVO roles;
            using (var _ctx = new PhysiotherapyContext())
            {
                roles = _ctx.Role.Where(s => s.Name == "Admin").FirstOrDefault<RoleVO>();
            }
            return roles;
        }
    }
}

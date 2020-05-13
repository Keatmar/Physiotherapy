using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public class RoleDA : IRoleDA
    {
        public RoleVO FindAdminRole(RoleContext ctx) 
        {
            RoleVO role = null;
            try
            {
                role = ctx.Role.Where(s => s.Name == "Admin").SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return role;
        }

    }
}

using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Linq;

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
            catch
            {
                throw;
            }
            return role;
        }
    }
}
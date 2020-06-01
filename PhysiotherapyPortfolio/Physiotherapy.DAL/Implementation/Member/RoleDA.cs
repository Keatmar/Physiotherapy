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

        public RoleVO FindRoleById(RoleContext ctx, int id)
        {
            RoleVO role = new RoleVO();
            try
            {
                var query = (from r in ctx.Role
                             where r.Id == id
                             select new { r.Name }).Single();
                role.Id = id;
                role.Name = FillItemForDatabase.FillItem(query.Name);
            }
            catch
            {
                throw;
            }
            return role;
        }
    }
}
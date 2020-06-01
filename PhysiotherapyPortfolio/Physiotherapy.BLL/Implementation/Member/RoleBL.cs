using Physiotherapy.BLL.Interface;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;

namespace Physiotherapy.BLL
{
    public class RoleBL : IRoleBL
    {
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

        public RoleVO GetRoleById(int id)
        {
            RoleVO model = new RoleVO();
            try
            {
                using(var ctx = new RoleContext())
                {
                    IRoleDA da = new RoleDA();
                    model = da.FindRoleById(ctx,id);
                }

            }catch
            {
                throw;
            }
            return model;
        }
    }
}
using Physiotherapy.BLL.Interface;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.BLL
{
    public class AdminBL : IAdminBL
    {
        public void Save(UrlVO model)
        {
            try
            {
                using(var ctx = new AdminContext())
                {
                    IAdminDA da = new AdminDA();
                    da.Insert(ctx, model);
                }
            }
            catch
            {
                throw;
            }
        }

        public UrlVO GetUrlByUrl(string url)
        {
            UrlVO model = new UrlVO();
            try
            {
                using(var ctx = new AdminContext())
                {
                    IAdminDA da = new AdminDA();
                    model = da.FindUrlByUrl(ctx, url);
                    using (var ctxM = new MemberContext())
                    {
                        IMemberDA mDa = new MemberDA();
                    }
                }
            }
            catch
            {
                throw;
            }
            return model;
        }
    }
}

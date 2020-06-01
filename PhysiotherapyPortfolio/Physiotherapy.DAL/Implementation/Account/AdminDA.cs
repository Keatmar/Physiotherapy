using Physiotherapy.Context;
using Physiotherapy.DAL.Interface;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL.Implementation.Account
{
    public class AdminDA : IAdminDA
    {
        public void Insert(AdminContext ctx, UrlVO model)
        {
            try
            {
                ctx.Url.Add(model);
                ctx.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public UrlVO FindUrlByUrl(AdminContext ctx, string url)
        {
            UrlVO model = new UrlVO();
            try
            {
                var query = (from u in ctx.Url
                             where u.Url == url
                             select new
                             {
                                 u.Id,
                                 u.GUID,
                                 u.CreationDate,
                                 u.ExpireDate
                             }).Single();
                model.Id = FillItemForDatabase.FillItem(query.Id);
                model.Url = url;
                model.GUID = FillItemForDatabase.FillItem(query.GUID);
                model.CreationDate = FillItemForDatabase.FillItem(query.CreationDate);
                model.ExpireDate = FillItemForDatabase.FillItem(query.ExpireDate);
            }
            catch
            {
                throw;
            }
            return model;
        }
    }
}

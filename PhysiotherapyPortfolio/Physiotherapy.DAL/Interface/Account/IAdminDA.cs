using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL.Interface
{
    public interface IAdminDA
    {
        /// <summary>
        /// Insert new url to database
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name=""></param>
        void Insert(AdminContext ctx, UrlVO model);

        /// <summary>
        /// Find Url model by ulr string
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        UrlVO FindUrlByUrl(AdminContext ctx, string url);
    }
}

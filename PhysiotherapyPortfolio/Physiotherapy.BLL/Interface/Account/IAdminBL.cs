using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.BLL.Interface
{
    public interface IAdminBL
    {
        /// <summary>
        /// Insert new url to database
        /// </summary>
        /// <param name="model"></param>
        void Save(UrlVO model);

        /// <summary>
        /// Get Url model by url string
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        UrlVO GetUrlByUrl(string url);
    }
}

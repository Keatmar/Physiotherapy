using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physiotherapy.Common._Resources;
using Physiotherapy.Model;

namespace Physiotherapy.BLL.Person
{
    public class EmailBL
    {
        /// <summary>
        /// Get an email address and split it to create domain and extension
        /// </summary>
        /// <param name="address">email address</param>
        /// <param name="model">model to save domain and extension</param>
        /// <returns>model</returns>
        public EmailVO ConvertAddressToModel(string address, EmailVO model)
        {
            try
            {
                string[] temp, temp1;
                if (string.IsNullOrEmpty(address))
                    throw new Exception(Resource.Er0002);

                temp = address.Split('@');
                if (temp.Length > 1)
                {
                    temp1 = temp[1].Split('.');
                    if (temp1.Length > 1) {
                        model.Domain = temp1[0];
                        model.Extension = temp1[1];
                    }
                    else
                        throw new Exception(Resource.Er0001);
                }
                else
                    throw new Exception(Resource.Er0001);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}

using Physiotherapic.Context;
using Physiotherapic.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public class PhoneDA : IPhoneDA
    {
       public List<PhoneVO> FindPhonesByPersonId(PhoneContext ctx, int personId)
        {
            List<PhoneVO> model = new List<PhoneVO>();
            try
            {
                model = ctx.Phones.Where(x => x.PersonId == personId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
      
    }
}

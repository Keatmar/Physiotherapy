using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
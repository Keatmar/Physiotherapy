using Physiotherapy.Context;
using Physiotherapy.DataAccess.Interface.Person;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DA
{
    public class EmailDA : IEmailDA
    {
        public async Task<List<EmailVO>> FindEmailsByPersonId(PhysiotherapyContext ctx, int personId)
        {
            List<EmailVO> model = new List<EmailVO>();
            try
            {
                var query = await (from email in ctx.Emails
                                   where email.PersonId == personId
                                   select new
                                   {
                                       email.Id,
                                       email.Domain
                                   }).ToListAsync();
                foreach(var email in query)
                {
                    EmailVO em = new EmailVO();
                    em.Id = email.Id.Equals(DBNull.Value) ? 0 : (int)email.Id;
                    em.Domain = email.Domain.Equals(DBNull.Value) ? null : (string)email.Domain;
                    model.Add(em);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;

        }

    }
}

using Physiotherapic.Context;
using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public class EmailDA : IEmailDA
    {
        public async Task<List<EmailVO>> FindEmailsByPersonId(EmailContext ctx, int personId)
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
                foreach (var email in query)
                {
                    EmailVO em = new EmailVO()
                    {
                        Id = email.Id.Equals(DBNull.Value) ? 0 : (int)email.Id,
                        Domain = email.Domain.Equals(DBNull.Value) ? null : (string)email.Domain
                    };
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

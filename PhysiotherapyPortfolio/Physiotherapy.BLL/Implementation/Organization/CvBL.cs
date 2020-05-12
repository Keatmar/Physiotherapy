using Physiotherapy.BLL.Interface;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.IDA;
using Physiotherapy.DA;

namespace Physiotherapy.BLL
{
    public class CvBL : ICvBL
    {
        public CvVO GetCvByMemberId(int memberId)
        {
            CvVO model = new CvVO();
            try
            {
                using (var ctx = new PhysiotherapyContext())
                {

                    model = new CvDA().FindCvByMemberId(ctx, memberId);
                    if (model.Id != 0 && model.Member != null && model.MemberId != 0 && model.Member.Person != null && model.Member.PersonId != 0)
                    {
                        Task<List<AddressVO>> addrTask = Task.Run(() => new AddressDA().FindAddressesByPersonId(ctx, model.Member.PersonId));
                        Task.WhenAll(addrTask);
                        model.Member.Person.Addresses = addrTask.Result;
                        Task<List<EmailVO>> emailTask = Task.Run(() => new EmailDA().FindEmailsByPersonId(ctx, model.Member.PersonId));
                        Task.WhenAll(emailTask);
                        model.Member.Person.Emails = emailTask.Result;
                            
                    }
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

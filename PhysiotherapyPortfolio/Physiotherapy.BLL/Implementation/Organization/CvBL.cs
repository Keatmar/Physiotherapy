using Physiotherapic.Context;
using Physiotherapy.BLL.Interface;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Physiotherapy.BLL
{
    public class CvBL : ICvBL
    {
        public CvVO GetCvByMemberId(int memberId)
        {
            CvVO model = new CvVO();
            try
            {
                using (var ctx = new CvContext())
                {
                    model = new CvDA().FindCvByMemberId(ctx, memberId);
                    if (model.Id != 0 && model.Member != null && model.MemberId != 0 && model.Member.Person != null && model.Member.PersonId != 0)
                    {
                        Task<List<AddressVO>> addrTask;
                        using (var ctxAddr = new AddressContext())
                        {
                            addrTask = Task.Run(() => new AddressDA().FindAddressesByPersonId(ctxAddr, model.Member.PersonId));
                            using (var ctxEmail = new EmailContext())
                            {
                                Task<List<EmailVO>> emailTask = Task.Run(() => new EmailDA().FindEmailsByPersonId(ctxEmail, model.Member.PersonId));
                                using (var ctxPhone = new PhoneContext())
                                {
                                    Task<List<PhoneVO>> phoneTask = Task.Run(() => new PhoneDA().FindPhonesByPersonId(ctxPhone, model.Member.PersonId));
                                    Task.WhenAll(phoneTask, addrTask, emailTask);
                                    model.Member.Person.Addresses = addrTask.Result;
                                    model.Member.Person.Emails = emailTask.Result;
                                    model.Member.Person.Phones = phoneTask.Result;
                                }
                            }
                        }
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
using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Linq;

namespace Physiotherapy.DAL
{
    public class CvDA : ICvDA
    {
        /// <summary>
        /// Get Cv included member,person from memberId
        /// </summary>
        /// <param name="ctx">Application ctx</param>
        /// <param name="memberId">filter for take cv</param>
        /// <returns>CvVO</returns>
        public CvVO FindCvByMemberId(CvContext ctx, int memberId)
        {
            CvVO model = new CvVO();
            try
            {
                var query = (from cv in ctx.Cv
                             join member in ctx.Member on cv.MemberId equals member.Id
                             join person in ctx.Person on member.PersonId equals person.Id
                             where member.Id == memberId
                             select new
                             {
                                 cv.Id,
                                 cv.MemberId,
                                 member.Username,
                                 member.PersonId,
                                 person.BirthDate,
                                 person.FirstName_el,
                                 person.LastName_el,
                                 person.FirstName_en,
                                 person.LastName_en
                             }).SingleOrDefault();
                if (query != null)
                {
                    model.Id = query.Id.Equals(DBNull.Value) ? 0 : (int)query.Id;
                    model.MemberId = query.MemberId.Equals(DBNull.Value) ? 0 : (int)query.MemberId;
                    model.Member = new MemberVO()
                    {
                        Id = model.MemberId,
                        Username = query.Username.Equals(DBNull.Value) ? null : (string)query.Username,
                        PersonId = query.PersonId.Equals(DBNull.Value) ? 0 : (int)query.PersonId
                    };
                    model.Member.Person = new PersonVO()
                    {
                        Id = model.Member.PersonId,
                        BirthDate = query.BirthDate.Equals(DBNull.Value) ? DateTime.MinValue : (DateTime)query.BirthDate,
                        FirstName_el = query.FirstName_el.Equals(DBNull.Value) ? null : (string)query.FirstName_el,
                        LastName_el = query.LastName_el.Equals(DBNull.Value) ? null : (string)query.LastName_el,
                        FirstName_en = query.FirstName_en.Equals(DBNull.Value) ? null : (string)query.FirstName_en,
                        LastName_en = query.LastName_en.Equals(DBNull.Value) ? null : (string)query.LastName_en
                    };
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
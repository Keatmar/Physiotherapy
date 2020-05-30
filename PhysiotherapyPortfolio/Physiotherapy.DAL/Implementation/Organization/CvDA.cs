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
                             }).Single();
                model.Id = FillItemForDatabase.FillItem(query.Id);
                model.MemberId = FillItemForDatabase.FillItem(query.MemberId);
                model.Member = new MemberVO()
                {
                    Id = model.MemberId,
                    Username = FillItemForDatabase.FillItem(query.Username),
                    PersonId = FillItemForDatabase.FillItem(query.PersonId)
                };
                model.Member.Person = new PersonVO()
                {
                    Id = model.Member.PersonId,
                    BirthDate = FillItemForDatabase.FillItem(query.BirthDate),
                    FirstName_el = FillItemForDatabase.FillItem(query.FirstName_el),
                    LastName_el = FillItemForDatabase.FillItem(query.LastName_el),
                    FirstName_en = FillItemForDatabase.FillItem(query.FirstName_en),
                    LastName_en = FillItemForDatabase.FillItem(query.LastName_en)
                };
            }
            catch
            {
                throw;
            }
            return model;
        }
    }
}
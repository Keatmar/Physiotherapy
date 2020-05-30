using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Linq;

namespace Physiotherapy.DAL
{
    public class MemberDA : IMemberDA
    {
        public MemberVO FindMemberByUserName(MemberContext ctx, string username)
        {
            MemberVO member = null;
            try
            {
                member = ctx.Member.Where(m => m.Username == username).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member;
        }

        public MemberVO RegisterMember(MemberContext ctx, MemberVO member)
        {
            try
            {
                ctx.Member.Add(member);
                ctx.Cv.Add(new CvVO { MemberId = member.Id });
                ctx.Person.Add(member.Person);
                ctx.Addresses.Add(member.Person.Address);
                ctx.Emails.Add(member.Person.Email);
                ctx.Phones.Add(member.Person.Phone);
                ctx.Phones.Add(member.Person.Mobile);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member;
        }

        public int FindIdByUsername(MemberContext ctx, string username)
        {
            int id = 0;
            try
            {
                var query = (from mem in ctx.Member
                             where mem.Username == username
                             select new
                             {
                                 mem.Id
                             }).Single();
                id = FillItemForDatabase.FillItem(query.Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return id;
        }
        public MemberVO FindMemberById(MemberContext ctx, int id)
        {
            MemberVO member = null;
            try
            {
                member = ctx.Member.Where(model => model.Id == id).SingleOrDefault();
            }
            catch
            {
                throw;
            }
            return member;
        }
    }
}
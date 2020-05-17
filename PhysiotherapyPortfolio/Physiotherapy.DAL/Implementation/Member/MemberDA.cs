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
            MemberVO model = null;
            try
            {
                ctx.Member.Add(member);
                ctx.Cv.Add(new CvVO { MemberId = member.Id });
                ctx.Person.Add(member.Person);
                ctx.Addresses.Add(member.Person.Address);
                ctx.Emails.Add(member.Person.Email);
                ctx.Phones.Add(member.Person.Phone);
                ctx.Phones.Add(member.Person.Mobile);
                ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public MemberVO FindMemberById(MemberContext ctx, int id)
        {
            MemberVO member = null;
            try
            {
                member = ctx.Member.Where(model => model.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member;
        }
    }
}
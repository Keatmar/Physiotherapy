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
            MemberVO member = new MemberVO();
            try
            {
                var query = (from m in ctx.Member
                             where m.Username == username
                             select new
                             {
                                 m.Password,
                                 m.Id,
                                 m.RoleId,
                                 m.DefaultCultrure,
                                 m.PersonId,
                                 m.UrlId
                             }).Single();
                member.Id = FillItemForDatabase.FillItem(query.Id);
                member.Username = username;
                member.Password = FillItemForDatabase.FillItem(query.Password);
                member.RoleId = FillItemForDatabase.FillItem(query.RoleId);
                member.DefaultCultrure = FillItemForDatabase.FillItem(query.DefaultCultrure);
                member.PersonId = FillItemForDatabase.FillItem(query.PersonId);
                member.UrlId = FillItemForDatabase.FillItem(query.UrlId);
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
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }
        public MemberVO FindMemberById(MemberContext ctx, int id)
        {
            MemberVO member = new MemberVO();
            try
            {
                var query = (from mem in ctx.Member
                             join rol in ctx.Role on mem.RoleId equals rol.Id
                             where mem.Id == id
                             select new
                             {
                                 mem.Username,
                                 mem.Id,
                                 mem.DefaultCultrure,
                                 rol.Name
                             }).Single();
                member.Username = FillItemForDatabase.FillItem(query.Username);
                member.Id = FillItemForDatabase.FillItem(query.Id);
                member.DefaultCultrure = FillItemForDatabase.FillItem(query.DefaultCultrure);
                member.Role = new RoleVO();
                member.Role.Name = FillItemForDatabase.FillItem(query.Name);
            }
            catch
            {
                throw;
            }
            return member;
        }
    }
}
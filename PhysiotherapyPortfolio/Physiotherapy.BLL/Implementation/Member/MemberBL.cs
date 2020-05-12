using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Physiotherapy.Model;
using Physiotherapy.BLL;
using System.Threading.Tasks;
using Physiotherapy.BLL.Interface;
using Physiotherapy.DAL;
using System.Globalization;
using Physiotherapy.Common._Resources;
using Physiotherapy.Context;
using System.Text.RegularExpressions;

namespace Physiotherapy.BLL
{
    public class MemberBL : IMemberBL
    {
        public List<MemberVO> GetPersons()
        {
            using (var _ctx = new PhysiotherapyContext())
            {
                return _ctx.Members.ToList();
            }
        }

        /// <summary>
        /// Get Member with id = Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>return Member with id = Id</returns>
        public MemberVO GetMemberById(int Id)
        {
            MemberVO member = null;
            try
            {
                using (var ctx = new PhysiotherapyContext())
                {
                    member = ctx.Members.Where(model => model.Id == Id).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return member;
        }

        /// <summary>
        /// Add new admin Member 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public MemberVO AddAdminMember(MemberVO member)
        {
            try
            {
                member.Person.CreationDate = member.CreationDate = TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.UtcNow);
                member.DefaultCultrure = CultureInfo.CurrentUICulture.TextInfo.CultureName;
                member.Password = Password.ComputeHash("a12345678A", null);
                member.ConfirmPassword = member.Password;
                RoleVO adminRole = new RoleBL().GetAdminRole();
                member.RoleId = adminRole.Id;
                using (var ctx = new PhysiotherapyContext())
                {
                    ctx.Members.Add(member);
                    ctx.Cvs.Add(new CvVO { MemberId = member.Id });
                    ctx.Persons.Add(member.Person);
                    ctx.Addresses.Add(member.Person.Address);
                    ctx.Emails.Add(member.Person.Email);
                    ctx.Phones.Add(member.Person.Phone);
                    ctx.Phones.Add(member.Person.Mobile);
                    ctx.SaveChangesAsync();
                }
                return member;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MemberVO LoginMember(string username, string password)
        {
            MemberState state = MemberStateBL.State;
            MemberVO member;
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new Exception(Resource.Er0005);
                Regex rx = new Regex(@"^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$");
                if (!rx.IsMatch(password))
                    throw new Exception(Resource.PasswordErrorMessage);
                if (string.IsNullOrWhiteSpace(password))
                    throw new Exception(Resource.Er0006);
                if (password.Length < 7)
                    throw new Exception(Resource.Er0004);
                using (var ctx = new PhysiotherapyContext())
                {
                    member = ctx.Members.Where(m => m.Username == username).SingleOrDefault();
                    if (member == null || member.Id == 0)
                        throw new Exception(Resource.Er0003);
                    bool success = Password.ConfirmPassword(password, member.Password);
                    if (!success)
                        throw new Exception(Resource.Er0004);
                    else
                       MemberStateBL.SetMemberState(member.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member;
        }
    }
}

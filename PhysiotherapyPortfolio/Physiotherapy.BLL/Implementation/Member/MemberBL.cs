using Physiotherapy.BLL.Interface;
using Physiotherapy.Common._Resources;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.Model;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Physiotherapy.BLL
{
    public class MemberBL : IMemberBL
    {
        /// <summary>
        /// Get Member by this id
        /// </summary>
        /// <param name="id">id to search member</param>
        /// <returns></returns>
        public MemberVO GetMemberById(int id)
        {
            MemberVO member = null;
            try
            {
                using (var ctx = new MemberContext())
                {
                    member = new MemberDA().FindMemberById(ctx, id);
                }
            }
            catch (Exception ex)
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
                if (adminRole == null)
                    throw new Exception(Resource.Er0007);
                member.RoleId = adminRole.Id;
                using (var ctx = new MemberContext())
                {
                    member = new MemberDA().RegisterMember(ctx, member);
                    if (member == null)
                        throw new Exception(Resource.Er0007);
                }
                return member;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Login member to app
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MemberVO LoginMember(string username, string password)
        {
            MemberVO member;
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new InvalidOperationException(Resource.Er0005);
                Regex rx = new Regex(@"^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$");
                if (!rx.IsMatch(password))
                    throw new InvalidOperationException(Resource.PasswordErrorMessage);
                if (string.IsNullOrWhiteSpace(password))
                    throw new InvalidOperationException(Resource.Er0006);
                if (password.Length < 7)
                    throw new InvalidOperationException(Resource.Er0004);
                using (var ctx = new MemberContext())
                {
                    member = new MemberDA().FindMemberByUserName(ctx, username);
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
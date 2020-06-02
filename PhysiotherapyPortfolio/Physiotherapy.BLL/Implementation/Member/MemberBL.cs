using Physiotherapy.BLL.Interface;
using Physiotherapy.Common._Resources;
using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.IDA;
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
                    IMemberDA da = new MemberDA();
                    member = da.FindMemberById(ctx, id);
                }
            }
            catch
            {
                throw;
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
                    throw new Exception(Resource.ErSomethingWrong);
                member.RoleId = adminRole.Id;
#if SuperUser
                member.UrlId = 1;
                member.RoleId = 2;
#endif
                using (var ctx = new MemberContext())
                {
                    IMemberDA da = new MemberDA();
                    member = da.RegisterMember(ctx, member);
                    member.Id = da.FindIdByUsername(ctx, member.Username);
                    if (member == null)
                        throw new Exception(Resource.ErSomethingWrong);
                }
                return member;
            }
            catch
            {
                throw;
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
                    {
                        IRoleBL blRole = new RoleBL();
                        member.Role = blRole.GetRoleById(member.RoleId);
                        MemberStateBL.SetMemberState(member.Id);
                    }
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
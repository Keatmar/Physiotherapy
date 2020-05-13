using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.IDA
{
    public interface IMemberDA
    {
        /// <summary>
        /// Find member by username
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="username">username data</param>
        /// <returns>Get member model</returns>
        MemberVO FindMemberByUserName(MemberContext ctx, string username);

        /// <summary>
        /// Create new Member to application.
        /// Also created person, an address, an email, two phone (Phone and Mobile) and your empty cv.
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="member">data of member to be created</param>
        /// <returns>Created Member</returns>
        MemberVO RegisterMember(MemberContext ctx, MemberVO member);

        /// <summary>
        /// Find Member by Id
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="id">id to search member</param>
        /// <returns></returns>
        MemberVO FindMemberById(MemberContext ctx, int id);
    }
}

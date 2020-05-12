using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.BLL.Interface
{
    public interface IMemberBL /*<TEntry> where TEntry:class*/
    {
        List<MemberVO> GetPersons();
        MemberVO AddAdminMember(MemberVO member);
        MemberVO LoginMember(string username, string password);
    }
}

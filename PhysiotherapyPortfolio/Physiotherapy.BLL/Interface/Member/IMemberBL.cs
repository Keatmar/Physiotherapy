using Physiotherapy.Model;

namespace Physiotherapy.BLL.Interface
{
    public interface IMemberBL /*<TEntry> where TEntry:class*/
    {
        MemberVO AddAdminMember(MemberVO member);

        MemberVO LoginMember(string username, string password);
    }
}
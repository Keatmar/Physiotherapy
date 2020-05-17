using Physiotherapy.Model;
using System.Globalization;

namespace Physiotherapy.BLL
{
    internal class StatePrepareBL
    {
        private MemberState State { get; set; }

        internal StatePrepareBL(MemberState state)
        {
            this.State = state;
        }

        /// <summary>
        /// Initialize Member State
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        internal MemberState SetState(int memberId = 0)
        {
            try
            {
                State = new MemberState();
                State.Member = new MemberBL().GetMemberById(memberId);
                State.IsReady = true;
                State.IsValid = true;
                State.IsLogin = true;
                State.Culture = CultureInfo.CurrentUICulture.TextInfo.CultureName;
            }
            catch
            {
                State.IsValid = false;
                State.IsReady = false;
            }
            return State;
        }
    }
}
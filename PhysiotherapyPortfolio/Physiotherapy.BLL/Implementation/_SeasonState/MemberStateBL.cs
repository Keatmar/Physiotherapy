using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Physiotherapy.BLL
{
    public class MemberStateBL
    {
        public static MemberState State
        {
            get
            {
                if (HttpContext.Current != null
                    && HttpContext.Current.Session != null
                    && HttpContext.Current.Session["membState"] != null)
                {
                    return ((MemberState)HttpContext.Current.Session["membState"]);
                }
                else
                {
                    MemberState state = new MemberState();
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
                        HttpContext.Current.Session["membState"] = state;
                    return state;
                }
            }
            set
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    HttpContext.Current.Session["membState"] = value;
            }
        }

        public static bool SetMemberState(int memberId = 0)
        {
            StatePrepareBL statePrepareBL = new StatePrepareBL(State);
            State = statePrepareBL.SetState(memberId);
            return State.IsReady;
        }

        public static void SignOut()
        {
            State.Member = null;
            State.IsLogin = false;
        }
    }
}

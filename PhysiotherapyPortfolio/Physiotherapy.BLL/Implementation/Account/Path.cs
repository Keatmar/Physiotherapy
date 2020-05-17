using Physiotherapy.Common._Resources;
using System;
using Physiotherapy.Model;
using System.Web;

namespace Physiotherapy.BLL
{
    public enum eMain : byte
    {
        Cv = 0
    }

    public class eMainIcon
    {
        private eMainIcon(string value) { Value = value; }

        public string Value { get; set; }

        public static eMainIcon Cv { get { return new eMainIcon("<i class=\"far fa-address-card \"></i>"); } }
    }

    public class eMainText
    {
        private eMainText(string value) { Value = value; }

        public string Value { get; set; }

        public static eMainText Cv { get { return new eMainText(Resource.MyCV); } }
    }

    /// <summary>
    /// View path page to organization items
    /// </summary>
    public class Path
    {
        /// <summary>
        /// if Member connected and the page is organization initialize path 
        /// </summary>
        public static void InitializePath(byte main)
        {
            MemberState state = MemberStateBL.State;
            try
            {
                if (state.IsLogin)
                {
                    if (main == (byte)eMain.Cv)
                    {
                        string icon = eMainIcon.Cv.Value;
                        string text = eMainText.Cv.Value;
                        HttpContext.Current.Session["MainIcon"] = icon;
                        HttpContext.Current.Session["Main"] = text;
                        HttpContext.Current.Session["PathAction"] = "Index";
                    }
                }
                else
                    throw new Exception(Resource.Er0008);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

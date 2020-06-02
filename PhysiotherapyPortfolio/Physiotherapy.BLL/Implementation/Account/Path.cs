using Physiotherapy.Common._Resources;
using System;
using Physiotherapy.Model;
using System.Web;
using System.Collections.Generic;
using System.Linq;

namespace Physiotherapy.BLL
{
    public enum eMain : byte
    {
        Cv = 0,
        Admin = 1,
    }

    public sealed class eMainIcon
    {
        private eMainIcon(string value) { Value = value; }

        public string Value { get; set; }

        public static eMainIcon Cv { get { return new eMainIcon("<i class=\"far fa-address-card \"></i>"); } }

        public static eMainIcon Admin { get { return new eMainIcon("<i class=\"fas fa-tools\"></i>"); } }
    }

    public sealed class eMainText
    {
        private eMainText(string value) { Value = value; }

        public string Value { get; set; }

        public static eMainText Cv { get { return new eMainText(Resource.MyCV); } }

        public static eMainText Admin { get { return new eMainText(Resource.Admin); } }
    }

    /// <summary>
    /// View path page to organization items
    /// </summary>
    public class Path
    {
        private readonly List<UIPath> Items = new List<UIPath>();

        public Path()
        {
            Items = new List<UIPath>();
            HttpContext.Current.Session["Path"] = null;
        }
        /// <summary>
        /// if Member connected and the page is organization initialize path
        /// </summary>
        public void InsertMainItemToPath(byte main)
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
                        HttpContext.Current.Session["PathController"] = "CV";
                    }
                    else if (main == (byte)eMain.Admin)
                    {
                        string icon = eMainIcon.Admin.Value;
                        string text = eMainText.Admin.Value;
                        HttpContext.Current.Session["MainIcon"] = icon;
                        HttpContext.Current.Session["Main"] = text;
                        HttpContext.Current.Session["PathAction"] = "Admin";
                        HttpContext.Current.Session["PathController"] = "Admin";
                    }
                }
                else
                {
                    throw new Exception(Resource.Er0008);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create Url Path
        /// </summary>
        /// <param name="main"></param>
        /// <param name="text"></param>
        /// <param name="action"></param>
        public void InsertItemToPath(byte main, string text, string action)
        {
            UIPath item = new UIPath();
            item.Action = action;

            if (main == (byte)eMain.Cv)
                item.Controller = "CV";
            else if (main == (byte)eMain.Admin)
                item.Controller = "Admin";

            item.Text = text;
            item.Action = action;

            if (Items.Count != 0)
            {
                UIPath lastItem = Items.Last();
                item.Sequence = lastItem.Sequence + 1;
            }
            else
            {
                item.Sequence = 0;
            }
            this.Items.Add(item);
        }

        public void CreateSessionPath()
        {
            HttpContext.Current.Session["Path"] = Items.OrderBy(x => x.Sequence).ToList();
        }
    }
}

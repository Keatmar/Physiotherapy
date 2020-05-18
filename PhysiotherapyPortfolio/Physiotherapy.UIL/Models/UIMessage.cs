namespace Physiotherapy.UIModel
{
    /// <summary>
    /// Message Type
    /// </summary>
    public enum eUIMsgType : byte
    {
        notSet = 0,
        success = 1,
        info = 2,
        warning = 3,

        error = 4,

        /// <summary>
        /// if we have error message
        /// </summary>
        danger = 5
    }

    /// <summary>
    /// Message for pages
    /// </summary>
    public class UIMessage
    {
        /// <summary>
        /// Message Constractor
        /// </summary>
        /// <param name="msg">message body</param>
        /// <param name="msgType">message type</param>
        public UIMessage(string msg, eUIMsgType msgType)
        {
            Msg = msg;
            MsgType = msgType;
        }

        /// <summary>
        /// Message body
        /// </summary>
        public string Msg;

        /// <summary>
        /// Mesage Type
        /// </summary>
        public eUIMsgType MsgType;
    }
}
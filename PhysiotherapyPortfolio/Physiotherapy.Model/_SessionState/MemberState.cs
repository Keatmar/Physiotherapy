using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

[assembly: InternalsVisibleTo("Physiotherapy.UnitTests"), InternalsVisibleTo("Physiotherapy")]

namespace Physiotherapy.Model
{
    [DataContract]
    public class MemberState
    {
        [DataMember]
        public string Culture { get; set; }

        /// <summary>
        /// the connected Member
        /// </summary>
        public MemberVO Member { get; set; } = new MemberVO();

        /// <summary>
        /// If Member State has Member
        /// </summary>
        public bool IsReady { get; set; }

        /// <summary>
        /// If Member State has initialized
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// if member login
        /// </summary>
        public bool IsLogin { get; set; }
    }
}
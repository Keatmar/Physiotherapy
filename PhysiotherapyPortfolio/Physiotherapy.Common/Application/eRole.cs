using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.Common.Application
{
    public sealed class eRole
    {
        public string Value { get; set; }
        private eRole(string value) { Value = value; }
        public static eRole SuperAdmin { get { return new eRole("SuperAdmin"); } }
        public static eRole Admin { get { return new eRole("Admin"); } }

    }
}

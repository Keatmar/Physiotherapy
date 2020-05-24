using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Physiotherapy.Model
{
    /// <summary>
    /// Item to create path for UI
    /// </summary>
    public class UIPath
    {
        /// <summary>
        /// Text for path
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Action to redirect on click path
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Controller to redirect on click path
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Sequence for path
        /// </summary>
        public int Sequence{ get; set; }
    }
}
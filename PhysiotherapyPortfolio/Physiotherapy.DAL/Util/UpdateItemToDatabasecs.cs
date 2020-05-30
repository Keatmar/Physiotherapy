using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public class UpdateItemToDatabasecs
    {
        public static bool Item(string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value))
                return true;
            else
                return false;
        }
        public static bool Item(DateTime value)
        {
            if (value != DateTime.MinValue)
                return true;
            else
                return false;
        }

        public static bool Item(DateTime? value)
        {
            if (value != DateTime.MinValue && value !=null)
                return true;
            else
                return false;
        }

        public static bool Item(int value)
        {
            if (value != 0)
                return true;
            else
                return false;
        }

        public static bool Item(Decimal value)
        {
            if (value != 0)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public static class FillItemForDatabase
    {
        public static string FillItem(string dbItem)
        {
            if (dbItem == null)
                return null;
            else if (dbItem.Equals(DBNull.Value))
                return null;
            else
                return dbItem;
        }
        public static int FillItem(int dbItem)
        {
            if (dbItem == null)
                return 0;
            else if (dbItem.Equals(DBNull.Value))
                return 0;
            else
                return dbItem;
        }
        public static Decimal FillItem(Decimal dbItem)
        {
            if (dbItem == null)
                return 0;
            else if (dbItem.Equals(DBNull.Value))
                return 0;
            else
                return dbItem;
        }

        public static Byte FillItem(Byte dbItem)
        {
            if (dbItem == null)
                return 0;
            else if (dbItem.Equals(DBNull.Value))
                return 0;
            else
                return dbItem;
        }
        public static Guid? FillItem(Guid? dbItem)
        {
            if (dbItem == null)
                return Guid.Empty;
            else if (dbItem.Equals(DBNull.Value))
                return Guid.Empty;
            else
                return dbItem;
        }

        public static DateTime FillItem(DateTime dbItem)
        {
            if (dbItem == null)
                return DateTime.MinValue;
            else if (dbItem.Equals(DBNull.Value))
                return DateTime.MinValue;
            else
                return dbItem;
        }
    }
}

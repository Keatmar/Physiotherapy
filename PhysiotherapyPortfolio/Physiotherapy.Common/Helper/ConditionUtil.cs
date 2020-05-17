using System;
using System.Collections.Generic;

namespace Physiotherapy.DAL.SQLServer
{
    public class ConditionUtil
    {
        public static string CriteriaCondition(string criteriaField, DateTime exactDateValue)
        {
            string sql = criteriaField + "=" + exactDateValue.ToString();
            return sql;
        }

        public static string CriteriaCondition(string criteriaField, int exactDateValue)
        {
            string sql = criteriaField + "=" + exactDateValue.ToString();
            return sql;
        }
    }

    public class ConditionUtil<T>
    {
        public string CriteriaCondition(T column, List<T> values)
        {
            string sql = "";
            foreach (T value in values)
                sql = sql + column.ToString() + "=" + value.ToString() + " AND ";
            sql = sql.Remove(sql.Length - 5, 5);
            return sql;
        }
    }
}
using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Physiotherapy.BLL.Test
{
    public class EducationBLTest
    {
        #region Save
        public void Save_NullOperations(EducationVO model)
        {

        }

        private static EducationVO GetEducation_CreatedDate_MinValue()
            => new EducationVO
            {
                CreatedDate = DateTime.MinValue
            };
        private static EducationVO GetEducation_CreatedDateMinValue()
           => new EducationVO
           {
               Degree = "Barcelors degree",
               Department = "DIT",
               School = "Καποδηστριακο",
               MemberId = 1,
               StartYear = "2010",
               GraduationYear = "2011",
               Grade = 2.23M,
               CreatedDate = DateTime.MinValue
           };
        private static EducationVO GetEducation_EmptyDeparture()
           => new EducationVO
           {
               Degree = "",
               Department = "",
               School = "",
               CreatedDate = DateTime.UtcNow,
               MemberId = 1,
               StartYear = "2010",
               GraduationYear = "2011",
               Grade = 2.23M
           };
        #endregion
    }
}

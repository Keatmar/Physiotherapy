using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.Model;
using System;
using Physiotherapy.Common._Resources;
using System.Collections.Generic;
using Physiotherapy.IDA;
using System.Threading.Tasks;

namespace Physiotherapy.BLL
{
    public class EducationBL : IEducationBL
    {

        public EducationVO Save(EducationVO model)
        {
            MemberState state = MemberStateBL.State;
            try
            {
                model.MemberId = state.Member.Id;
                int graduationYear,startYear;
                bool success = int.TryParse(model.GraduationYear, out graduationYear);
                success = int.TryParse(model.StartYear, out startYear);
                if (success)
                {
                    if (graduationYear < startYear)
                        throw new Exception(Resource.Er0009);
                }
                else
                    throw new Exception(Resource.ErSomethingWrong);
                if (model.Id == 0)
                {
                    model.CreatedDate = DateTime.UtcNow;
                    model.ModifiedBy = null;
                    using (var ctx = new EducationContext())
                    {
                        model = new EducationDA().Save(model,ctx);
                    }
                }
            }catch
            {
                throw;
            }
            return model;
        }

        /// <summary>
        /// Get Member's educations async
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<EducationVO> GetEducationsByMemberId(int memberId)
        {
            List<EducationVO> model = new List<EducationVO>();
            try
            {
                using (var ctx = new EducationContext())
                {
                    IEducationDA da = new EducationDA();
                    model=  da.FindEducationsByMemberId(memberId, ctx);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
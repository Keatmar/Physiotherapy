using Physiotherapy.Context;
using Physiotherapy.DAL;
using Physiotherapy.Model;
using System;
using Physiotherapy.Common._Resources;
using System.Collections.Generic;
using Physiotherapy.IDA;
using System.Threading.Tasks;
using System.Security.Authentication;

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
                bool success = int.TryParse(model.GraduationYear, out int graduationYear);
                success = int.TryParse(model.StartYear, out int startYear);
                if (success)
                {
                    if (graduationYear < startYear)
                        throw new Exception(Resource.Er0009);
                }
                else
                {
                    throw new Exception(Resource.ErSomethingWrong);
                }
                // Insert new Education
                if (model.Id == 0)
                {
                    model.CreatedDate = DateTime.UtcNow;
                    model.ModifiedDate = null;
                    using (var ctx = new EducationContext())
                    {
                        IEducationDA da = new EducationDA();
                        model = da.Insert(ctx, model);
                    }
                }
                // Update Education
                else
                {
                    model.ModifiedDate = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now);
                    using (var ctx = new EducationContext())
                    {
                        IEducationDA da = new EducationDA();
                        da.Update(ctx, model);
                    }
                }
            }
            catch
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
                    model = da.FindEducationsByMemberId(memberId, ctx);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public EducationVO GetEducationById(int id)
        {
            MemberState state = MemberStateBL.State;
            EducationVO model = new EducationVO();
            try
            {
                using (var ctx = new EducationContext())
                {
                    IEducationDA da = new EducationDA();
                    model = da.FindEducationById(id, ctx);
                    if (model.MemberId != state.Member.Id)
                        throw new AuthenticationException();
                }
            }
            catch
            {
                throw;
            }
            return model;
        }
    }
}
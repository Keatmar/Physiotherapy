using Physiotherapy.Context;
using Physiotherapy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Physiotherapy.IDA
{
    public interface IEducationDA
    {
        /// <summary>
        /// Save new education
        /// </summary>
        /// <param name="model">education</param>
        /// <param name="ctx0"></param>
        /// <returns></returns>
        EducationVO Save(EducationVO model, EducationContext ctx);

        /// <summary>
        /// Find educations' member
        /// </summary>
        /// <param name="memberId">id to search educations</param>
        /// <param name="ctx"></param>
        /// <returns>List of educations</returns>
        List<EducationVO> FindEducationsByMemberId(int memberId, EducationContext ctx);
    }
}
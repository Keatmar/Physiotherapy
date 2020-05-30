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
        EducationVO Insert(EducationContext ctx,EducationVO model);

        /// <summary>
        /// Update Education
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="model"></param>
        void Update(EducationContext ctx, EducationVO model);

        /// <summary>
        /// Find educations' member
        /// </summary>
        /// <param name="memberId">id to search educations</param>
        /// <param name="ctx"></param>
        /// <returns>List of educations</returns>
        List<EducationVO> FindEducationsByMemberId(int memberId, EducationContext ctx);

        /// <summary>
        /// Find education by id
        /// </summary>
        /// <param name="id">id to search education</param>
        /// <param name="ctx"></param>
        /// <returns>Education with this id </returns>
        EducationVO FindEducationById(int id, EducationContext ctx);
    }
}
using Physiotherapy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Physiotherapy.BLL
{
    public interface IEducationBL
    {
        /// <summary>
        /// Save or update education to the connected member
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        EducationVO Save(EducationVO model);

        /// <summary>
        /// Get member's educations async
        /// </summary>
        /// <param name="memberId">Connected member id</param>
        /// <returns></returns>
        List<EducationVO> GetEducationsByMemberId(int memberId);
    }
}
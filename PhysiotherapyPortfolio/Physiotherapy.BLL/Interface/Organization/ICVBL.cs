using Physiotherapy.Model;

namespace Physiotherapy.BLL.Interface
{
    public interface ICvBL
    {
        CvVO GetCvByMemberId(int memberId);
    }
}
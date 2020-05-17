using Physiotherapy.Context;
using Physiotherapy.Model;

namespace Physiotherapy.IDA
{
    public interface ICvDA
    {
        CvVO FindCvByMemberId(CvContext ctx, int memberId);
    }
}

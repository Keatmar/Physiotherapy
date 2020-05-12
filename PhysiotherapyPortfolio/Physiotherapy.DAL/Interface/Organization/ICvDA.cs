using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.IDA
{
    public interface ICvDA
    {
        CvVO FindCvByMemberId(PhysiotherapyContext ctx, int memberId);
    }
}

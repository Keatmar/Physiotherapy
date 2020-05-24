using Physiotherapy.Context;
using Physiotherapy.Model;
using System.Collections.Generic;

namespace Physiotherapy.IDA
{
    internal interface IPhoneDA
    {
        List<PhoneVO> FindPhonesByPersonId(PhoneContext ctx, int personId);
    }
}
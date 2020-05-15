using Physiotherapic.Context;
using Physiotherapy.Model;
using System.Collections.Generic;

namespace Physiotherapic.IDA
{ 
    interface IPhoneDA
    {
        List<PhoneVO> FindPhonesByPersonId(PhoneContext ctx, int personId);
    }
}
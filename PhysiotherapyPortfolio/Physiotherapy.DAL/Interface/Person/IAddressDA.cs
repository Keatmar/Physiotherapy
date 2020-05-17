using Physiotherapic.Context;
using Physiotherapy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Physiotherapy.IDA
{
    public interface IAddressDA
    {
        Task<List<AddressVO>> FindAddressesByPersonId(AddressContext ctx, int personId);
    }
}
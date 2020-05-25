using Physiotherapy.Context;
using Physiotherapy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Physiotherapy.IDA
{
    public interface IAddressDA
    {
        /// <summary>
        /// Find address for member async
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        Task<List<AddressVO>> FindAddressesByPersonId(AddressContext ctx, int personId);
    }
}
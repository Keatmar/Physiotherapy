using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DA
{
    public class AddressDA
    {
        public async Task<List<AddressVO>> FindAddressesByPersonId(PhysiotherapyContext ctx, int personId)
        {
            List<AddressVO> model = new List<AddressVO>();
            try
            {
                var query = await (from addr in ctx.Addresses
                                   where addr.PersonId == personId
                                   select new
                                   {
                                       addr.Id,
                                       addr.City,
                                       addr.Country,
                                       addr.Street,
                                       addr.Number,
                                       addr.PostCode
                                   }).ToListAsync();
                foreach(var addr in query)
                {
                    AddressVO address = new AddressVO();
                    address.City = addr.City.Equals(DBNull.Value) ? null : (string)addr.City;
                    address.Country = addr.Country.Equals(DBNull.Value) ? null : (string)addr.Country;
                    address.Number = addr.Number.Equals(DBNull.Value) ? null : (string)addr.Number;
                    address.Street = addr.Street.Equals(DBNull.Value) ? null : (string)addr.Street;
                    address.PostCode = addr.PostCode.Equals(DBNull.Value) ? null : (string)addr.PostCode;
                    address.PersonId = personId;
                    model.Add(address);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}

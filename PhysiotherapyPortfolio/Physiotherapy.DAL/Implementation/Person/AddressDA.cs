using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public class AddressDA : IAddressDA
    {
        public async Task<List<AddressVO>> FindAddressesByPersonId(CvContext ctx, int personId)
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
                foreach (var addr in query)
                {
                    AddressVO address = new AddressVO()
                    {
                        City = addr.City.Equals(DBNull.Value) ? null : (string)addr.City,
                        Country = addr.Country.Equals(DBNull.Value) ? null : (string)addr.Country,
                        Number = addr.Number.Equals(DBNull.Value) ? null : (string)addr.Number,
                        Street = addr.Street.Equals(DBNull.Value) ? null : (string)addr.Street,
                        PostCode = addr.PostCode.Equals(DBNull.Value) ? null : (string)addr.PostCode,
                        PersonId = personId
                    };
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

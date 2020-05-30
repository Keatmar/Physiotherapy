using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public class AddressDA : IAddressDA
    {
        public async Task<List<AddressVO>> FindAddressesByPersonId(AddressContext ctx, int personId)
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
                        City = FillItemForDatabase.FillItem(addr.City),
                        Country = FillItemForDatabase.FillItem(addr.Country),
                        Number = FillItemForDatabase.FillItem(addr.Number),
                        Street = FillItemForDatabase.FillItem(addr.Street),
                        PostCode = FillItemForDatabase.FillItem(addr.PostCode),
                        PersonId = FillItemForDatabase.FillItem(personId)
                    };
                    model.Add(address);
                }
            }
            catch
            {
                throw;
            }
            return model;
        }
    }
}
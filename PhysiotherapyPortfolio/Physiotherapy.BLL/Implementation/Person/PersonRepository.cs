using Physiotherapy.BLL.Interface;
using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Physiotherapy.BLL
{
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns></returns>
        public List<PersonVO> GetPersons()
        {
            using (var _ctx = new PhysiotherapyContext())
            {
                return _ctx.Persons.ToList();
            }
        }

        /// <summary>
        /// Add new admin person to table
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonVO AddPerson(PersonVO person)
        {
            try
            {
                using (var ctx = new PhysiotherapyContext())
                {
                    person.CreationDate = TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.UtcNow);
                    person.Emails.Add(person.Email);
                    person.Addresses.Add(person.Address);
                    person.Phones.Add(person.Phone);
                    person.Phones.Add(person.Mobile);
                    ctx.Persons.Add(person);
                    ctx.Addresses.Add(person.Address);
                    ctx.Emails.Add(person.Email);
                    ctx.SaveChanges();
                }
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
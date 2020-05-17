using Physiotherapy.Model;
using System.Collections.Generic;

namespace Physiotherapy.BLL.Interface
{
    public interface IPersonRepository
    {
        List<PersonVO> GetPersons();

        PersonVO AddPerson(PersonVO person);
    }
}
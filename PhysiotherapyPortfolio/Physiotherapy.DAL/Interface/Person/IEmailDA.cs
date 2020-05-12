using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.DataAccess.Interface.Person
{
    public interface IEmailDA
    {
        Task<List<EmailVO>> FindEmailsByPersonId(PhysiotherapyContext ctx, int personId);
    }
}

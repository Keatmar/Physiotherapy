using Physiotherapy.Context;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.IDA
{
    public interface IEmailDA
    {
        Task<List<EmailVO>> FindEmailsByPersonId(CvContext ctx, int personId);
    }
}

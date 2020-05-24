using Physiotherapy.Context;
using Physiotherapy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Physiotherapy.IDA
{
    public interface IEmailDA
    {
        Task<List<EmailVO>> FindEmailsByPersonId(EmailContext ctx, int personId);
    }
}
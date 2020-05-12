using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.BLL.Interface
{
    public interface ICvBL
    {
        CvVO GetCvByMemberId(int memberId);
    }
}

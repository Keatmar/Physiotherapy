using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Physiotherapy.BLL;

namespace Physiotherapy.BLL.Test
{
    public class RegisterControllerTest
    {
        #region Login Testing
        [Theory]
        [InlineData("","")]
        public void Login_NullOperation(string username, string password)
        {
            //Assert.Throws<Exception>(() => new MemberBL.LoginMember(username, password));
        }
        #endregion
    }
}

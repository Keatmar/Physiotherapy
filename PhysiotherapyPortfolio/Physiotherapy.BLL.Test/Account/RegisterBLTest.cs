using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Physiotherapy.BLL;
using System.Runtime.InteropServices;

namespace Physiotherapy.BLL.Test
{
    public class RegisterBLTest
    {
        #region Login Testing
        [Theory]
        [InlineData("","")]
        [InlineData("Dimitris","")]
        [InlineData("","a12345678A")]
        public void Login_NullOperation(string username, string password)
        {
           Assert.Throws<InvalidOperationException>(() => new MemberBL().LoginMember(username, password));
        }

        [Theory]
        [InlineData("D", "a12345678!")]
        [InlineData("Di", "a12345678!")]
        [InlineData("Dim", "a12345678!")]
        [InlineData("Dimi", "a12345678!")]
        [InlineData("Dimit", "a12345678!")]
        [InlineData("Dimitr", "a12345678!")]
        [InlineData("Dimitri", "a12345678!")]
        public void Login_UsernameLess8Char(string username, string password)
        {
            Assert.Throws<InvalidOperationException>(() => new MemberBL().LoginMember(username, password));
        }


        [Theory]
        [InlineData("Dimitris", "a1A")]
        [InlineData("Dimitris", "a1!")]
        [InlineData("Dimitris", "a12!")]
        [InlineData("Dimitris", "a12A")]
        [InlineData("Dimitris", "a123!")]
        [InlineData("Dimitris", "a123A")]
        [InlineData("Dimitris", "a1234!")]
        [InlineData("Dimitris", "a1234A")]
        [InlineData("Dimitris", "a12345!")]
        [InlineData("Dimitris", "a12345A")]
        public void Login_PasswordLess8Char(string username, string password)
        {
            Assert.Throws<InvalidOperationException>(() => new MemberBL().LoginMember(username, password));
        }

        /// <summary>
        /// Password rules: less length 8 character,
        /// 3 of 4 : one lower char, one upper char, one number or one of the above !@#$%^&*
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        [Theory]
        [InlineData("Dimitris", "a12345678")]
        [InlineData("Dimitris", "12345678!")]
        [InlineData("Dimitris", "aααααα!")]
        [InlineData("Dimitris", "aasdsds8")]
        [InlineData("Dimitris", "!!!!!!!!")]
        [InlineData("Dimitris", "#$%^&*A!")]
        [InlineData("Dimitris", "#$%^&*1!!")]
        [InlineData("Dimitris", "#$%^&*a!!")]
        [InlineData("Dimitris", "1~#$%^&*a!!")]
        [InlineData("Dimitris", "1`#$%^&*a!!")]
        [InlineData("Dimitris", "1@#$%^&*a!!")]
        public void Login_PasswordFollowRules(string username, string password)
        {
            Assert.Throws<InvalidOperationException>(() => new MemberBL().LoginMember(username, password));
        }
        #endregion
    }
}

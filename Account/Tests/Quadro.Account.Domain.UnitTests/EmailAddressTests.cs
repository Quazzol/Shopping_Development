using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Account.Domain.UnitTests
{
    public class EmailAddressTests
    {
        [Fact]
        public void From_InvalidEmailAddress_ThrowsFormatException()
        {
            var exception = Assert.Throws<FormatException>(() => EmailAddress.From("invalidEmailAddress"));
            Assert.Equal(exception.Message, "Invalid Mail Address");
        }

        [Fact]
        public void From_ValidEmailAddress_CreatesObject()
        {
            var mailAddress = EmailAddress.From("valid@valid.com");
            Assert.Equal(mailAddress.ToString(), "valid@valid.com");
        }
    }
}

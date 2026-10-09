using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommomTestUtilities.Cryptography;

public class PasswordEncripterBuilder
{
    public static IPasswordEncripter Build()
    {
        var mock = new Mock<IPasswordEncripter>();

        mock.Setup(passwordEncripter => passwordEncripter.Encrypt(It.IsAny<string>()))
            .Returns("mocked_encrypted_password");
  
        return mock.Object;
    }
}

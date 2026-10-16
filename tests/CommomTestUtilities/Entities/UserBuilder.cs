using Bogus;
using CashFlow.Domain.Entities;
using CommomTestUtilities.Cryptography;

namespace CommomTestUtilities.Entities;

public class UserBuilder
{
    public static User Build()
    {
        var passwordEcripter = PasswordEncripterBuilder.Build();

        var user = new Faker<User>()
         .RuleFor(u => u.Id, _ => 1)
         .RuleFor(u => u.Name, faker => faker.Person.FirstName)
         .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email(user.Name))
         .RuleFor(u => u.Password, (_, user) => passwordEcripter.Encrypt(user.Password))
         .RuleFor(u => u.UserIdentifer, _ => Guid.NewGuid());
      
        return user;
    }
}

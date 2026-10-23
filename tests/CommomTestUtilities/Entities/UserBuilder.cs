using Bogus;
using CashFlow.Domain.Entities;
using CommomTestUtilities.Cryptography;

namespace CommomTestUtilities.Entities;

public class UserBuilder
{
    public static User Build()
    {
        var passwordEcripter = new PasswordEncrypterBuilder().Build();

        var user = new Faker<User>()
        .RuleFor(u => u.Id, _ => 1)
        .RuleFor(u => u.Name, faker => faker.Person.FirstName)
        .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email(user.Name))
        .RuleFor(u => u.Password, faker => faker.Internet.Password(prefix: "!Aa1"))
        .RuleFor(u => u.UserIdentifer, _ => Guid.NewGuid());

        return user;
    }
}

using CashFlow.Application.UseCases.Expenses.Users;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Requests;
using CommonTestUtilities.Mapper;
using FluentAssertions;

namespace UserCases.Test.Users.Register;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase();

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
        result.Token.Should().NotBeNullOrWhiteSpace();
    }

    private RegisterUserUseCase CreateUseCase()
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var writeOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();

        return new RegisterUserUseCase(mapper, null, null, writeOnlyRepository, null, unitOfWork);
    }
}
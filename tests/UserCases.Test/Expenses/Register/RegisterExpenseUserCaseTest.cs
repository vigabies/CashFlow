using CashFlow.Application.UseCases.Expenses.Register;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories;

namespace UserCases.Test.Expenses.Register;

public class RegisterExpenseUserCaseTest
{
    [Fact]
    public async Task Sucess()
    {

    }

    [Fact]
    public async Task Error_Title_Empty()
    {

    }

    private RegisterExpenseUseCase CreateUseCase(CashFlow.Domain.Entities.User user)
    {
        var repository = ExpensesWriteOnlyRepositoryBuilder.Build();
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new RegisterExpenseUseCase(repository, unitOfWork, mapper, loggedUser);
    }

}

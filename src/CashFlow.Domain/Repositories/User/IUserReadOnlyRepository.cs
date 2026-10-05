namespace CashFlow.Application.UseCases.Expenses.Users;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
}

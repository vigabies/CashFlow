namespace CashFlow.Application.UseCases.Expenses.Users;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<Domain.Entities.User?> GetUserByEmail(string email);
}

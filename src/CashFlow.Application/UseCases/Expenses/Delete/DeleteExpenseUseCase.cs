using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Exception.Messages;

namespace CashFlow.Application.UseCases.Expenses.Delete;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpensesReadOnlyRepository _expensesReadOnly;
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;

    public DeleteExpenseUseCase(
        IExpensesWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser,
        IExpensesReadOnlyRepository expensesReadOnly)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
        _expensesReadOnly = expensesReadOnly;
    }

    public async Task Execute(long id)
    {
        var loggedUser = await _loggedUser.Get();

        var expense = await _expensesReadOnly.GetById(loggedUser, id);

        if (expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        var deleted = await _repository.Delete(id);

        if (deleted is false)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
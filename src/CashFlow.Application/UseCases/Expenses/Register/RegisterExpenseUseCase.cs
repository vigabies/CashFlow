using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using System.Data;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {

        Validate(request);

        return new ResponseRegisteredExpenseJson;
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty) {
            throw new ArgumentException("The title is required.");
        
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("The Amoumnt must be greater than zero.");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result < 0) {
            throw new ArgumentException("Expenses cannot be for the future");
        }


    }
}

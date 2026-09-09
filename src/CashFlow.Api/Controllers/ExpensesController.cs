using Microsoft.AspNetCore.Mvc;
using CashFlow.Communication.Requests;
using CashFlow.Application.UseCases.Expenses.Register;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{

    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        var useCase = new RegisterExpenseUseCase();

        var response = useCase.Execute(request);
        
        return Created(string.Empty, response);
    }
}

using Microsoft.AspNetCore.Mvc;
using CashFlow.Communication.Requests;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{

    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        return Created();
    }
}

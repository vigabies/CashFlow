using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Requests;

public class RequestRegisterExpenseJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; //opcional

    public DateTime Date {  get; set; } //não posso receber data do futuro

    public decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }


}

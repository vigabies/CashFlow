using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Extensions;

public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.CashFlow => "Dinheiro",
            PaymentType.CreditCard => "Cartão de Débito",
            PaymentType.DebitCard => "Cartão de Crédito",
            PaymentType.EletronicTransfer => "Transferência Bancária",
            _ => string.Empty
        };
    }
}

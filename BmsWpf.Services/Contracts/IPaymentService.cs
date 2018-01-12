namespace BmsWpf.Services.Contracts
{
    using System.Data;

    using BmsWpf.Services.DTOs;

    public interface IPaymentService
    {
        string CreatePayment(PaymentPostDto newPayment);

        string EditPayment(PaymentPostDto newPayment);

        DataTable GetPaymentsToTable(ProjectPostDto project);

        string Delete(int id);
    }
}

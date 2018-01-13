using System.Data;
using BmsWpf.Services.DTOs;

namespace BmsWpf.Services.Contracts
{
    public interface IPaymentService
    {
        string CreatePayment(PaymentPostDto newPayment);
        string Delete(int id);
        string EditPayment(PaymentPostDto newPayment);
        DataTable GetPaymentsExpencesAsDataTable(int projectId);
        DataTable GetPaymentsIncomeAsDataTable(int projectId);
        DataTable GetPaymentsToTable(ProjectPostDto project);
    }
}
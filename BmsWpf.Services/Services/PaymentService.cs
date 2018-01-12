namespace BmsWpf.Services.Services
{
    using System.Data;

    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;

    public class PaymentService : IPaymentService
    {
        private IBmsData bmsData;

        public PaymentService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public string CreatePayment(PaymentPostDto newPayment)
        {
            throw new System.NotImplementedException();
        }

        public string EditPayment(PaymentPostDto newPayment)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetPaymentsToTable()
        {
            throw new System.NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

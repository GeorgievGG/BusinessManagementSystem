namespace BmsWpf.Services.Services
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;

    using Microsoft.EntityFrameworkCore;

    using MoreLinq;

    public class PaymentService : IPaymentService
    {
        private IBmsData bmsData;

        public PaymentService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public string CreatePayment(PaymentPostDto newPayment)
        {
            var UserSrv = new UserService(this.bmsData);
            var payment = new Payment()
                              {
                                  SuplierId = newPayment.SupplierId,
                                  ClientId = newPayment.ClientId,
                                  ProjectId = newPayment.ProjectId,
                                  Date = newPayment.Date,
                                  Price = newPayment.Price,
                                  Vat = newPayment.Vat,
                                  Total = newPayment.Total
                              };

            this.bmsData.Payments.Add(payment);

            this.bmsData.SaveChanges();

            return $"Payment for {newPayment.Total} was added";
        }

        public string EditPayment(PaymentPostDto newPayment)
        {
            var paymentToUpdate = this.bmsData.Payments.Find(newPayment.Id);
            paymentToUpdate.SupplierId = newPayment.SupplierId;
            paymentToUpdate.ClientId = newPayment.ClientId;
            paymentToUpdate.ProjectId = newPayment.ProjectId;
            paymentToUpdate.Date = newPayment.Date;
            paymentToUpdate.Price = newPayment.Price;
            paymentToUpdate.Vat = newPayment.Vat;
            paymentToUpdate.Total = newPayment.Total;

            this.bmsData.Payments.Update(paymentToUpdate);
            this.bmsData.SaveChanges();

            return $"Payment was updated.";
        }

        public DataTable GetPaymentsToTable(ProjectPostDto project)
        {
            var paymentsToproject = this.bmsData.Payments.All().Where(x => x.ProjectId == project.Id);

            return paymentsToproject.ToDataTable();
        }

        public string Delete(int id)
        {
            var paymentToDelete = this.bmsData.Payments.Find(id);

            try
            {
                this.bmsData.Payments.Remove(paymentToDelete);
                this.bmsData.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                var innerException = dbEx.InnerException;
                if (innerException is SqlException)
                {
                    var sqlEx = (SqlException)innerException;
                    if (sqlEx.Errors.Count > 0 && sqlEx.Errors[0].Number == 547) // Foreign Key violation
                    {
                        throw new InvalidOperationException("You cannot delete payment that is a part of a project!");
                    }

                    throw dbEx;
                }
            }

            return $"You deleted payment {paymentToDelete.Id}successfully";
        }
    }
}

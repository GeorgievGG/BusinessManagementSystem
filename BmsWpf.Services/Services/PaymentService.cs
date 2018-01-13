namespace BmsWpf.Services.Services
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using BMS.DataBaseModels;
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

        private IQueryable<PaymentsForMainDto> GetPaymentsDto()
        {
            IQueryable<Payment> payments = GetAllPayments();
            var paymentsDataTable = payments.Select(
                p => new PaymentsForMainDto()
                         {
                             Id = p.Id,
                             Client =
                                 new ContragentListDto()
                                     {
                                         Id = p.Client.Id,
                                         NameAndIdentity = p.Client.Name
                                     },
                             Supplier =
                                 new ContragentListDto()
                                     {
                                         Id = p.Supplier.Id,
                                         NameAndIdentity = p.Supplier.Name
                                     },
                             Project =
                                 new ProjectListDto() { Id = p.Project.Id, Name = p.Project.Name },
                             Date = p.Date,
                             Price = p.Price,
                             VAT = p.Vat,
                             Total = p.Total
                         });
            return paymentsDataTable;
        }

        public DataTable GetPaymentsIncomeAsDataTable(int projectId)
        {
            var payments = this.GetPaymentsDto();
            var paymentsDataTable = payments.Where(x => x.Supplier.Id == 1 && x.Project.Id == projectId).ToDataTable();

            return paymentsDataTable;
        }

        public DataTable GetPaymentsExpencesAsDataTable(int projectId)
        {
            var paymentsExpencesDataTable = this.GetPaymentsDto()
                .Where(x => x.Client.Id == 1 && x.Project.Id == projectId).ToDataTable();

            return paymentsExpencesDataTable;
        }

        private IQueryable<Payment> GetAllPayments()
        {
            var payments = this.bmsData.Payments.All();
            return payments;
        }

        public string CreatePayment(PaymentPostDto newPayment)
        {
            var UserSrv = new UserService(this.bmsData);
            var payment = new Payment()
            {
                ClientId = newPayment.ClientId,
                SupplierId = newPayment.SupplierId,
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

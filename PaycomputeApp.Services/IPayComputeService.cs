using Microsoft.AspNetCore.Mvc.Rendering;
using PayComputeApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaycomputeApp.Services
{
  public   interface IPayComputeService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
 
        PaymentRecord GetById(int Id);

        IEnumerable<PaymentRecord> GetAll();

        IEnumerable<SelectListItem> GetAllTaxYear();

        decimal OvertimeHours(decimal HoursWorked, decimal contractualHours);

        decimal ContractualEarnings(decimal contractualHours, decimal HoursWorked, decimal HourlyRate);

        decimal OvertimeRate(decimal HourlyRate);

        decimal OverTimeEarnings(decimal OvertimeRate, decimal OvertimeHours);

        decimal TotalEarnings(decimal OvertimeEarnings, decimal ContractualEarnings);

        decimal TotalDeduction(decimal Tax, decimal Nic, decimal UnionFee, decimal StudentLoanRepayment);

        decimal NetPay(decimal TotalEarnings, decimal TotalDeduction);


    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using PayComputeApp.Entity;
using PayComputeApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycomputeApp.Services.Implementation
{
    public class PayComputeService : IPayComputeService
    {
        private decimal contractualEarnings;
        private decimal overtimeHours;
        private readonly ApplicationDbContext _context;

        public PayComputeService( ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal HoursWorked, decimal HourlyRate)
        {
            if(HoursWorked < contractualHours)
            {
                contractualEarnings = HoursWorked * HourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * HourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
         await   _context.PaymentRecord.AddAsync(paymentRecord);
          await  _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecord.OrderBy(p => p.EmployeeId);
        
        
        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxYears => new SelectListItem
            {
                Text = taxYears.YearOfTax,
                Value = taxYears.Id.ToString()
            }) ;
            return allTaxYear;
        }

        public PaymentRecord GetById(int Id)
        => _context.PaymentRecord.Where(pay => pay.id == Id).FirstOrDefault();


        public decimal NetPay(decimal TotalEarnings, decimal TotalDeduction)
        => TotalEarnings - TotalDeduction;

        public decimal OverTimeEarnings(decimal OvertimeRate, decimal OvertimeHours)
        => OvertimeHours * OvertimeRate;

        public decimal OvertimeHours(decimal HoursWorked, decimal contractualHours)
        {
            if(HoursWorked <= contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else 
            {
                overtimeHours = HoursWorked - contractualHours;
            }
            return overtimeHours;
        }

        public decimal OvertimeRate(decimal HourlyRate)
       => HourlyRate * 1.5m;

        public decimal TotalDeduction(decimal Tax, decimal Nic, decimal UnionFee, decimal StudentLoanRepayment)
        => Tax + Nic + UnionFee + StudentLoanRepayment;

        public decimal TotalEarnings(decimal OvertimeEarnings, decimal ContractualEarnings)
        => OvertimeEarnings + ContractualEarnings;
    }
}

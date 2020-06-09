using PayComputeApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaycomputeApp.Services
{
   public interface IEmployeeService
    {
        Task CreateAsync(Employee employee);

        Employee GetById(int employeeId);

        Task UpdateAsync(Employee employee);

        Task UpdateAsync(int Id);

        Task Delete(int employeeId);

        decimal UnionFee(int id);

        decimal StudentLoanRepaymentAmount(int id, decimal totalAmount);

        IEnumerable<Employee> GetAll();






    }
}

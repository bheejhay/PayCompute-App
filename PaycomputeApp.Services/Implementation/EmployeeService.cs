﻿using PayComputeApp.Entity;
using PayComputeApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycomputeApp.Services.Implementation
{
    public class EmployeeService : IEmployeeService 
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee newEmployee)
        { 
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }
        public Employee GetById(int employeeId) =>
            _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task Delete(int employeeId)
        {
            var employees = GetById(employeeId);
           _context.Remove(employees);
            await _context.SaveChangesAsync();
                }

        public IEnumerable<Employee> GetAll => 
            _context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(int Id)
        {
            var employees = GetById(Id);
            _context.Update(employees);
           await _context.SaveChangesAsync();

        }

         public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFee(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IEmployeeService.GetAll() => _context.Employees;


    }
}

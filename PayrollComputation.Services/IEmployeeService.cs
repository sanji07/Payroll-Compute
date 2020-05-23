using System;
using System.Collections.Generic;
using PayrollComputation.Entity;
using System.Text;
using System.Threading.Tasks;

namespace PayrollComputation.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeDet newEmployee);
        EmployeeDet GetById(int employeeId);
        Task UpdateAsync(EmployeeDet employeeDet);
        Task UpdateAsync(int id);
        Task Delete(int employeeId);
        decimal StudentLoanRepaymentAmount(int id, decimal totalAmount);
        IEnumerable<EmployeeDet> GetAll();

    }
}

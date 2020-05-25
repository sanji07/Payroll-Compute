using PayrollComputation.Entity;
using PayrollComputation.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollComputation.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(EmployeeDet newEmployee)
        {
          await _context.EmployeeDets.AddAsync(newEmployee);
          await _context.SaveChangesAsync();         
        }
        public EmployeeDet GetById(int employeeId) =>
            _context.EmployeeDets.Where(e => e.Id == employeeId).FirstOrDefault();


        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
           await _context.SaveChangesAsync();
        }

        public IEnumerable<EmployeeDet> GetAll() =>
            _context.EmployeeDets;

        public async Task UpdateAsync(EmployeeDet employeeDet)
        {
            _context.Update(employeeDet);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
           await _context.SaveChangesAsync();
        }
        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

       
    }
}

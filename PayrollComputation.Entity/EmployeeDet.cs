using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollComputation.Entity
{
    public class EmployeeDet
    {
        public int Id { get; set; }
        [Required]
        public string EmpId { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        [Required, MaxLength(10)]
        public int TFN { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public StudentLoan studentLoan { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(3)]
        public string City { get; set; }
        [Required, MaxLength(4)]
        public string POcode { get; set; }
        public List<PaymentRecord> PaymentRecords { get; set; }


    }
}

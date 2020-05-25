using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollComputation.Services
{
    public interface ITaxService
    {
        decimal TaxAmount(decimal totalAmount);
    }
}

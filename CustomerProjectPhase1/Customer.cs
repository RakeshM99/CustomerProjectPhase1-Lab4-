using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace MiddleLayer
{
   
    public class Customer : CustomerBase
    {
        public Customer()
        {
            CustomerType = "Customer";
        }
        public Customer(IValidation<ICustomer> obj) : base(obj)
        {
            CustomerType = "Customer";
        }
        
    }
    public class Lead : CustomerBase
    {
        public Lead()
        {
            CustomerType = "Lead";
        }
        public Lead(IValidation<ICustomer> obj): base(obj)
        {
            CustomerType = "Lead";
        }
    }
}

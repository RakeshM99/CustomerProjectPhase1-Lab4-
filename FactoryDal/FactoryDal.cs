using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using InterfaceCustomer;
using AdoDotnetDAL;
using CommonDAL;
using InterfaceDal;
using EfDal;
namespace FactoryDal
{
    public static class FactoryDalLayer<AnyType> // Design pattern :- Simple factory pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;


        public static AnyType Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();
               
                ObjectsofOurProjects.RegisterType<IDal<CustomerBase>,
                    CustomerDAL>("ADODal");
                ObjectsofOurProjects.RegisterType<IDal<CustomerBase>,
                    EfCustomerDal>("EFDal");
            }
            //Design pattern :-  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>(Type,
                                new ResolverOverride[]
                                {
                                       new ParameterOverride("_ConnectionString", 
                                        @"Data Source=localhost\SQL2014;Initial Catalog=CustomerDB(DesignPattern);Integrated Security=True")
                                }); ;
        }
    }
}

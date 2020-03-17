using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiddleLayer;
using Microsoft.Practices.Unity;
using InterfaceCustomer;
using ValidationAlgorithms;
using InterfaceDal;
namespace FactoryCustomer
{
    public static class Factory<AnyType> // Design pattern :- Simple factory pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;
            
        
        public static AnyType Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();
                ObjectsofOurProjects.RegisterType<CustomerBase, Customer>
                                ("Customer", 
                                new InjectionConstructor(
                                    new CustomerValidationAll()));
                ObjectsofOurProjects.RegisterType<CustomerBase, Lead>
                                    ("Lead"
                                    , new InjectionConstructor(
                                        new LeadValidation()));
               
            }
            //Design pattern :-  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>(Type); 
        }
    }
}

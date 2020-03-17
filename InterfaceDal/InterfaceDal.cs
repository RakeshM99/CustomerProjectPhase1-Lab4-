using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDal
{
    // Design pattern :- Generic Repository pattern
    public interface IDal<AnyType>
    {
        void Add(AnyType obj); // Inmemory addition
        void Update(AnyType obj);  // Inmemory updation
        List<AnyType> Search();
        void Save(); // Physical committ
    }
}

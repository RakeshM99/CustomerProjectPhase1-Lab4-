using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDal;
namespace CommonDAL
{
    public abstract class AbstractDal<AnyType> : IDal<AnyType>
    {
        protected string ConnectionString = "";
        public AbstractDal(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
       protected List<AnyType> AnyTypes = new List<AnyType>();
        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }
    }
}

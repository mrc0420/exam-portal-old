using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Factory.Abstract
{
 public   interface IFactoryProvider
    {
        T Create<T>();
    }
}

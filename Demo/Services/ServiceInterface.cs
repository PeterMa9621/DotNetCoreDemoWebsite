using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    interface ServiceInterface<T> where T : class
    {
        public void Insert(T model);

        public void Get();
    }
}

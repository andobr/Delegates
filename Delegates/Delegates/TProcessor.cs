using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class TProcessor
    {
        public T Process<T, TRequest>(TRequest request, Func<TRequest, bool> check, Func<TRequest, T> register, Action<T> save)
        {
            if (!check(request))
                throw new ArgumentException();
            var result = register(request); 
            save(result);
            return result; 
        }
    }

    public class TransactionRequest
    {
    }

    public class Transaction
    {
    }

    public class OrderRequest
    {
    }

    public class Order
    {
    }
}

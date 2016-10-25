using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Processor<T, TRequest>
    {
        Func<TRequest, bool> check;

        Func<TRequest, T> register;

        Action<T> save;

        public Processor(Func<TRequest, bool> check, Func<TRequest, T> register, Action<T> save)
        {
            this.check = check;
            this.register = register;
            this.save = save;
        }

        public T Process(TRequest request)
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

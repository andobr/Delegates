using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactionProcessor = new Processor<Transaction, TransactionRequest>(x => true, y => new Transaction(), x => Console.WriteLine(x.GetType()));
            var orderProcessor = new Processor<Order, OrderRequest>(x => true, y => new Order(), x => Console.WriteLine(x.GetType()));

            transactionProcessor.Process(new TransactionRequest());
            orderProcessor.Process(new OrderRequest());
        }
    }
}

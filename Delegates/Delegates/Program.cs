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
            new TProcessor().Process(new TransactionRequest(), x => true, y => new Transaction(), x => Console.WriteLine(x.GetType()));
            new TProcessor().Process(new OrderRequest(), x => true, y => new Order(), x => Console.WriteLine(x.GetType()));
            Console.Read();
        }
    }
}

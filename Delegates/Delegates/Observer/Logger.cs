using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Logger : IObserver
    {
        IObservable obsObject;

        public Logger(IObservable obs)
        {
            obsObject = obs;
            obsObject.RegisterObserver(this);
        }

        public void Update(object ob)
        {

        }
    }
}

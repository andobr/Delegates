using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Renderer : IObserver
    {
        IObservable obsObject;

        public Renderer(IObservable obs)
        {
            obsObject = obs;
            obs.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            
        }
    }
}

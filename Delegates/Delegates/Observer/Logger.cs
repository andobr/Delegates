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

        List<string> log;

        public Logger(IObservable obs)
        {
            obsObject = obs;
            obsObject.RegisterObserver(this);
            log = new List<string>();
        }

        public void Update(UpdatedInfo ob)
        {
            string message = ob.newRow == null ? ob.newColumn == null ? ob.updatedValue == null ? null :
                $"{DateTime.Now} The value of a cell [{ob.updatedRowIndex}, {ob.updatedColumnIndex}] has been updated to {ob.updatedValue}.\n" :
                $"{DateTime.Now} A new column has been added to the index {ob.newColumn}.\n" :
                $"{DateTime.Now} A new row has been added to the index {ob.newRow}.\n";

            log.Add(message);
        }
    }
}

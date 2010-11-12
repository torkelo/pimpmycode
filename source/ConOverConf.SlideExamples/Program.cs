using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Core;

namespace ConOverConf.SlideExamples
{
    class Program
    {
        private static ILog _logger = LoggerManager.GetLogger(typeof (Program));

        public int TransferCount { get; private set; }


        public int GetTransferPriority<T>(T transfer) where T : Transfer
        {
            try
            {
                IDictionary<string, T> rules = new Dictionary<string, T>();

                // some important businesslogic
                if (transfer.HasPriority && TransferCount > 0)
                {
                    //...
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void DoSomeLogging()
        {
            throw new NotImplementedException();
        }

        protected decimal Limit
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException();
            TransferCount=1}
        }

        private void HandleException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }

    public class Transfer
    {
        public bool HasPriority { get; set; }   
    }

    
}

using System;
using System.Collections.Generic;

namespace ConOverConf.SlideExamples
{
    class Program
    {
        //private static ILog _logger = LoggerManager.GetLogger(typeof (Program));

        public int TransferCount { get; private set; }

        public static void Main()
        {}


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

            return 0;
        }

        private void DoSomeLogging()
        {
            throw new NotImplementedException();
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

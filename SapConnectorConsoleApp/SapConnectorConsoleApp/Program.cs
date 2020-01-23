using SAP.Middleware.Connector;
using System;

namespace SapConnectorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SAPSystemConnect sapCfg = new SAPSystemConnect();
                RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
                RfcDestination destination = RfcDestinationManager.GetDestination("ECQ");
                RfcRepository repository = destination.Repository;
                IRfcFunction function = repository.CreateFunction("Z_SSRT_SUM");
                function.SetValue("i_num1", 2);
                function.SetValue("i_num2", 4);
                function.Invoke(destination);
                int result = function.GetInt("e_result");

                destination.Ping();
                var rfcRepository = destination.Repository;
                var rfcFunction = rfcRepository.CreateFunction("RFC_CUSTOMER_DATA");
                rfcFunction.SetValue("COUNTRY", "india");
                rfcFunction.Invoke(destination);
                var table = rfcFunction.GetTable(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}

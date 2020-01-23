using SAP.Middleware.Connector;
using System;
using System.Configuration;

namespace SapConnectorConsoleApp
{
    public class SAPSystemConnect : IDestinationConfiguration
    {
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
        public bool ChangeEventsSupported()
        {
            return false;
        }
        public RfcConfigParameters GetParameters(string destinationName)
        {
            string serverHost = ConfigurationManager.AppSettings["ServerHost"].ToString();
            string systemNumber = ConfigurationManager.AppSettings["SystemNumber"].ToString();
            string user = ConfigurationManager.AppSettings["User"].ToString();
            string password = ConfigurationManager.AppSettings["Password"].ToString();
            string client = ConfigurationManager.AppSettings["Client"].ToString();
            string language = ConfigurationManager.AppSettings["Language"].ToString();
            string poolSize = ConfigurationManager.AppSettings["PoolSize"].ToString();
            string peakConnectionsLimit = ConfigurationManager.AppSettings["PeakConnectionsLimit"].ToString();
            string idleTimeout = ConfigurationManager.AppSettings["IdleTimeout"].ToString();
            RfcConfigParameters rfcConfigParameters = new RfcConfigParameters();
            try
            {
                rfcConfigParameters.Add("ASHOST", serverHost);
                rfcConfigParameters.Add("SYSNR", systemNumber);
                rfcConfigParameters.Add("USER", user);
                rfcConfigParameters.Add("PASSWD", password);
                rfcConfigParameters.Add("CLIENT", client);
                rfcConfigParameters.Add("LANG", language);
                rfcConfigParameters.Add("POOL_SIZE", poolSize);
                rfcConfigParameters.Add("MAX_POOL_SIZE", peakConnectionsLimit);
                rfcConfigParameters.Add("IDLE_TIMEOUT", idleTimeout);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return rfcConfigParameters;
        }
    }
}

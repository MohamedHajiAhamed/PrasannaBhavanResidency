using Org.BouncyCastle.Crypto.Tls;
using System.Configuration;
using System.Drawing;
using Twilio.Base;

namespace Prasanna_Bhavan_Residency
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Prasanna_Bhavan_Residency"].ConnectionString;
        }
    }
}

using System.Configuration;

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

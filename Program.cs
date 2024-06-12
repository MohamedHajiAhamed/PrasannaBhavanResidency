using System;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Progress_page());
        }
    }
}

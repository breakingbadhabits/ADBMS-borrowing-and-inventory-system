using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherSample
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

            SqlConnection connection = DatabaseConnection.Instance.Connection;

            //Application.Run(new LoginF1());

            // use for debug only, comment it to stop debugging, replace the view that you want to open on app start
            Application.Run(new StocksAdmin());
        }
    }

}

using System;
using System.Collections.Generic;
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

            var dbConnection = DatabaseConnection.Instance;

            //Application.Run(new LoginF1());

            // use for debug only, comment it to stop debugging
            Application.Run(new BorrowerView());
            //end debug

            dbConnection.CloseConnection();
        }
    }

}

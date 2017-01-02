using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnboardingTables
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TableOnboarding());
            try
            {
                Application.Run(new TableOnboarding());
            }
            catch (SystemException e)//just as an example 
            {
                //log or handle the error here. 
                MessageBox.Show("Error encountered while processing. Please try again!");
            }
        }
    }
}

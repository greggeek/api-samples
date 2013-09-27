using System;
using System.Configuration;
using System.Windows.Forms;
using HttpRequestClient;

namespace ItinerarySampleApp
{
    static class MainEntry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string username = ConfigurationManager.AppSettings["userName"];
            //Make sure user adds credential information
            if (String.Equals(username, "your username"))
            {
                MessageBox.Show("Please enter your credential information in the app.config file.", "Enter Credential Information");
                Application.Exit();
            }
            else
            {
                //Credential information entered - start program
                Application.Run(new MainForm());
            }
        }
    }
}

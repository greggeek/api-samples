using System;
using System.Configuration;
using System.Windows.Forms;

namespace QuickExpenseSample
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

			//Make sure user adds credential information
			string username = ConfigurationManager.AppSettings["userName"];
			if (String.Equals(username, "your username"))
			{
				MessageBox.Show("Please enter your credential information into the App.config files.\n\nPlease refer to the README file.", "Enter Credential Information");
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

using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuickExpenseSample
{
	public partial class AboutForm : Form
	{
		/// <summary>
		/// Creates a new about form
		/// </summary>
		public AboutForm()
		{
			InitializeComponent();
			TitleLabel.Text = ConfigurationManager.AppSettings["title"];
		}

		/// <summary>
		/// Opens a web browser and goes to the clicked link
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(LinkLabel.Text);
		}
	}
}

using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace ItinerarySampleApp
{
    public partial class About : Form
    {
        /// <summary>
        /// Creates a new about form 
        /// </summary>
        public About()
        {
            InitializeComponent();
            TitleLabel.Text = ConfigurationManager.AppSettings["title"];
        }

        /// <summary>
        /// Opens a new browser and goes to the link clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Process.Start(LinkLabel.Text);
        }
    }
}

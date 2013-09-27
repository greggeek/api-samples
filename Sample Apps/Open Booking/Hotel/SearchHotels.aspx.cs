using System;
using System.Web.UI;

namespace WebPrototype
{
	public partial class SearchHotels : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Settings settings = new Settings();
			settings.SetToken();

			if (Session["Token"] != null)
			{
				//Token exists, hide label and button
				ConnectLabel.Text = "Welcome, " + (string)(Session["UserName"]);
				ConnectButton.Visible = false;
			}	
		}

		/// <summary>
		/// Populate session variables depending on hotel chosen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectButton1_Click(object sender, EventArgs e)
		{
			Session["Hotel"] = "Ameer Suites";
			Session["Street"] = "1234 W Century Boulevard";
			Session["CityState"] = "Inglewood,  CA,  90304";
			Session["Phone"] = "Phone: 123-456-7891";
			Session["DailyRate"] = "129.99";

			Server.Transfer("ConfirmHotel.aspx");
		}
		protected void SelectButton2_Click(object sender, EventArgs e)
		{
			Session["Hotel"] = "Hotel Paulo";
			Session["Street"] = "1717 4th Street";
			Session["CityState"] = "Santa Monica, CA 90401";
			Session["Phone"] = "Phone: 123-456-7891";
			Session["DailyRate"] = "79.99";

			Server.Transfer("ConfirmHotel.aspx");
		}
		protected void SelectButton3_Click(object sender, EventArgs e)
		{
			Session["Hotel"] = "Dan Inn";
			Session["Street"] = "987 Sunset Boulevard";
			Session["CityState"] = "Los Angeles, CA, 90069";
			Session["Phone"] = "Phone: 123-456-7891";
			Session["DailyRate"] = "149.99";

			Server.Transfer("ConfirmHotel.aspx");
		}

		/// <summary>
		/// Connect to Concur when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Hotel/SearchHotels.aspx");
		}
	}
}
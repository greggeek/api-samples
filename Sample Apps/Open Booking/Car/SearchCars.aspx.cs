using System;
using System.Web.UI;

namespace WebPrototype
{
	public partial class SearchCars : System.Web.UI.Page
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
		/// Populate session variables depending on the vehicle the user chooses
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectButton1_Click(object sender, EventArgs e)
		{
			Session["DailyRate"] = "79.99";
			Session["Class"] = "Economy";
			Session["Vehicle"] = "2010 Toyota Corolla";

			Server.Transfer("ConfirmCar.aspx");
		}
		protected void SelectButton2_Click(object sender, EventArgs e)
		{
			Session["DailyRate"] = "149.99";
			Session["Class"] = "Truck";
			Session["Vehicle"] = "2010 Ford F-150";

			Server.Transfer("ConfirmCar.aspx");
		}	
		protected void SelectButton3_Click(object sender, EventArgs e)
		{
			Session["DailyRate"] = "139.99";
			Session["Class"] = "Cargo Van";
			Session["Vehicle"] = "2010 Ford Econoline";

			Server.Transfer("ConfirmCar.aspx");
		}

		/// <summary>
		/// Connect to Concur when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Car/SearchCars.aspx");
		}		
	}
}
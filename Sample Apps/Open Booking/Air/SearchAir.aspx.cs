using System;
using System.Web.UI;

namespace WebPrototype
{
	public partial class Flights : System.Web.UI.Page
	{
		/// <summary>
		/// Populate labels depending on user input
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

			//Populate departure and destination places
			LeavingFromLabel1.Text = (string)Session["From"];
			LeavingFromLabel2.Text = (string)Session["From"];
			GoingToLabel1.Text = (string)Session["To"];
			GoingToLabel2.Text = (string)Session["To"];

			//Populate time labels
			DateTime time = Convert.ToDateTime((string)Session["DepartDate"]);
			DepartTimeLabel1.Text = time.ToString("D") + " 12:20PM";
			ArriveTimeLabel1.Text = time.ToString("D") + "  02:49PM";
			DepartTimeLabel2.Text = time.ToString("D") + "  02:20PM";
			ArriveTimeLabel2.Text = time.ToString("D") + "  04:59PM"; 
		}

		/// <summary>
		/// Set session variables depending on the flight user chooses
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectButton1_Click(object sender, EventArgs e)
		{
			string departDate = (string)Session["DepartDate"];
			string departTime = "T12:20:00";
			Session["DepartDate"] = departDate + departTime;

			
			string arriveTime = "T14:49:00";
			Session["ArriveDate"] = departDate + arriveTime;
			Session["Flight"] = "339";

			Server.Transfer("ConfirmAir.aspx");
		}
		protected void SelectButton2_Click(object sender, EventArgs e)
		{
			string departDate = (string)Session["DepartDate"];
			string departTime = "T14:20:00";
			Session["DepartDate"] = departDate + departTime;


			string arriveTime = "T16:59:00";
			Session["ArriveDate"] = departDate + arriveTime;
			Session["Flight"] = "419";

			Server.Transfer("ConfirmAir.aspx");
		}

		/// <summary>
		/// Connect to Concur when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Air/SearchAir.aspx");
		}
	}
}
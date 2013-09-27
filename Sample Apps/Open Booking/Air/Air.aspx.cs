using System;

namespace WebPrototype
{
	public partial class Air : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Display credential message to user if credentials doesn't exist
			if (String.Equals(Settings.ConsumerKey, "your consumer key") || String.Equals(Settings.ConsumerSecret, "your consumer secret"))
			{
				CredentialLabel.Text = "Please enter your credential information before using this sample application.";
				CredentialLabel.Visible = true;
			}

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
		/// Populate date textbox with selected date and set sessions
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DepartCalendar_SelectionChanged(object sender, EventArgs e)
		{
			DateTime depart = Convert.ToDateTime(DepartCalendar.SelectedDate.ToString("yyyy-MM-dd"));
			Session["DepartDate"] = DepartCalendar.SelectedDate.ToString("yyyy-MM-dd");
			DepartTextBox.Text = DepartCalendar.SelectedDate.ToString("D");
		}
		protected void ReturnCalendar_SelectionChanged(object sender, EventArgs e)
		{
			DateTime returnDate = Convert.ToDateTime(ReturnCalendar.SelectedDate.ToString("s"));
			Session["ReturnDate"] = ReturnCalendar.SelectedDate.ToString("s");
			ReturnTextBox.Text = ReturnCalendar.SelectedDate.ToString("D");
		}

		/// <summary>
		/// When clicked, go to page with search results for flights
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SearchFlightButton_Click(object sender, EventArgs e)
		{
			//Display proper error messages. Validation
			if (String.IsNullOrEmpty(DepartTextBox.Text) || String.IsNullOrEmpty(ReturnTextBox.Text))
			{
				ValidationLabel.Text = "ERROR - Please select a date.";
				ValidationLabel.Visible = true;
			} else if(String.Equals(FromDropDownList.SelectedItem.Value, GoingDropDownList.SelectedItem.Value))
			{
				ValidationLabel.Text = "ERROR - Cities cannot be the same.";
				ValidationLabel.Visible = true;
			}
			else if (DateTime.Compare(DepartCalendar.SelectedDate, ReturnCalendar.SelectedDate) > 0)
			{
				ValidationLabel.Text = "ERROR - Depart date is after return date.";
				ValidationLabel.Visible = true;
			}
			else
			{
				//No errors, proceed to search page and set sessions
				Session["From"] = FromDropDownList.SelectedItem.Value;
				Session["To"] = GoingDropDownList.SelectedItem.Value;

				Server.Transfer("SearchAir.aspx");
			}			
		}

		/// <summary>
		/// Connect to Concur when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click1(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Air/Air.aspx");
		}
	}
}
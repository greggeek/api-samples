using System;

namespace WebPrototype
{
	public partial class Car : System.Web.UI.Page
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
		/// Populate date text box with selected date
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void PickUpCalendar_SelectionChanged(object sender, EventArgs e)
		{
			PickUpTextBox.Text = PickUpCalendar.SelectedDate.ToString("D");
		}
		protected void ReturnCalendar_SelectionChanged(object sender, EventArgs e)
		{
			ReturnTextBox.Text = ReturnCalendar.SelectedDate.ToString("D");
		}

		/// <summary>
		/// When clicked, go to page to select vehicle
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SearchButton_Click(object sender, EventArgs e)
		{
			//Display proper error messages. Validation
			if (String.IsNullOrEmpty(PickUpTextBox.Text) || String.IsNullOrEmpty(ReturnTextBox.Text))
			{
				ValidationLabel.Text = "ERROR - Please select a date.";
				ValidationLabel.Visible = true;
			}
			else if (DateTime.Compare(PickUpCalendar.SelectedDate, ReturnCalendar.SelectedDate) > 0)
			{
				ValidationLabel.Text = "ERROR - Depart date is after return date.";
				ValidationLabel.Visible = true;
			}
			else
			{
				//No errors, proceed to search page and set sessions
				Session["Location"] = LocationDropDownList.SelectedItem.Value;
				Session["PickUpCar"] = PickUpTextBox.Text;
				Session["ReturnCar"] = ReturnTextBox.Text;
				
				Server.Transfer("SearchCars.aspx");
			}			
		}

		/// <summary>
		/// Connect to Concur when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Car/Car.aspx");
		}
	}
}
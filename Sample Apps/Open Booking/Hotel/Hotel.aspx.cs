using System;
using System.Web.UI;

namespace WebPrototype
{
	public partial class Hotel : System.Web.UI.Page
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
		protected void CheckInCalendar_SelectionChanged(object sender, EventArgs e)
		{
			CheckInTextBox.Text = CheckInCalendar.SelectedDate.ToString("D");
		}
		protected void CheckOutCalendar_SelectionChanged(object sender, EventArgs e)
		{
			CheckOutTextBox.Text = CheckOutCalendar.SelectedDate.ToString("D");
		}

		/// <summary>
		/// Populate session variables with user input and redirect to search hotels page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SearchHotelButton_Click(object sender, EventArgs e)
		{
			//Display proper error messages. Validation
			if (String.IsNullOrEmpty(CheckInTextBox.Text) || String.IsNullOrEmpty(CheckOutTextBox.Text))
			{
				ValidationLabel.Text = "ERROR - Please select a date.";
				ValidationLabel.Visible = true;
			}
			else if (DateTime.Compare(CheckInCalendar.SelectedDate, CheckOutCalendar.SelectedDate) > 0)
			{
				ValidationLabel.Text = "ERROR - Check in date is after check out date.";
				ValidationLabel.Visible = true;
			}
			else
			{
				//Valid inputs. Proceed to search page and set sessions
				Session["CheckIn"] = CheckInTextBox.Text;
				Session["CheckOut"] = CheckOutTextBox.Text;
				Session["Rooms"] = RoomDropDownList.SelectedItem.Value;

				Server.Transfer("SearchHotels.aspx");
			}			
		}

		/// <summary>
		/// Connect to Concur when Clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Hotel/Hotel.aspx");
		}
	}
}
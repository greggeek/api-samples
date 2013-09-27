using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Xml;

using HttpRequestClient;

namespace WebPrototype
{
	public partial class ConfirmHotel : System.Web.UI.Page
	{
		/// <summary>
		/// Populate fields from variable sessions
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

			//Populate fields with sessions and set date and time sessions to valid format
			DateTime checkIn = Convert.ToDateTime((string)Session["CheckIn"]);
			CheckInLabel.Text = checkIn.ToString("D") + " @ 12:00PM";			
			Session["CheckIn"] = checkIn.ToString("s");

			DateTime checkOut = Convert.ToDateTime((string)Session["CheckOut"]);
			CheckOutLabel.Text = checkOut.ToString("D") + " @ 12:00PM";			
			Session["CheckOut"] = checkOut.ToString("s");

			HotelLabel.Text = (string)Session["Hotel"];
			AddressLabel.Text = (string)Session["Street"];
			CityStateLabel.Text = (string)Session["CityState"];
			PhoneLabel.Text = (string)Session["Phone"];
			DailyRateLabel.Text = "$" + (string)Session["DailyRate"];
		}

		/// <summary>
		/// Send post request when user confirms
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SubmitButton_Click(object sender, EventArgs e)
		{
			if (Session["Token"] == null)
			{
				//Display failure message
				SuccessLabel.Text = "You do not have an access token. Hotel not booked.";
				SuccessLabel.Visible = true;
			}
			else
			{
				//Display success message
				SuccessLabel.Text = "You have successfully booked a hotel.";
				SuccessLabel.Visible = true;

				//Build XML for request
				StringWriter xmlContent = new StringWriter();
				XmlTextWriter writer = new XmlTextWriter(xmlContent);
				writer.Formatting = Formatting.Indented;
				writer.WriteStartElement("Booking");
				{
					writer.WriteStartElement("Segments");
					{
						writer.WriteStartElement("Hotel");
						{
							writer.WriteElementString("StartDateLocal", (string)Session["CheckIn"]);
							writer.WriteElementString("EndDateLocal", (string)Session["CheckOut"]);
							writer.WriteElementString("Name", (string)Session["Hotel"]);
							writer.WriteElementString("CheckinTime", "12:00 PM");
							writer.WriteElementString("CheckoutTime", "12:00PM");
							writer.WriteElementString("NumRooms", (string)Session["Rooms"]);
						}
						writer.WriteEndElement(); 
					}
					writer.WriteEndElement(); 
					writer.WriteElementString("RecordLocator", "AmeerSuites");
					writer.WriteElementString("BookingSource", "AmeerSuites.com");
					writer.WriteElementString("ItinSourceName", "hotels");
				}
				writer.WriteEndElement(); 

				//Set uri
				UriBuilder uri = new UriBuilder(Settings.HostName);
				uri.Path = Settings.BookingApiUrl;
				string bookingApiUrl = uri.ToString();

				//Set headers
				Dictionary<string, string> headers = new Dictionary<string, string>();
				string oauth = String.Format("OAuth {0}", (string)Session["Token"]);
				headers.Add("Authorization", oauth);

				//Send post request
				HttpClient.Post(bookingApiUrl, headers, xmlContent.ToString());
			}			
		}

		/// <summary>
		/// Connect to Concur when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Hotel/ConfirmHotel.aspx");
		}
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Xml;

using HttpRequestClient;

namespace WebPrototype
{
	public partial class ConfirmCar : System.Web.UI.Page
	{
		/// <summary>
		/// Populate fields from session variables
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

			//Populate fields with sessions
			//Set date and time sessions for pick-up/return time
			DateTime pickUp = Convert.ToDateTime((string)Session["PickUpCar"]);
			PickUpLabel.Text = pickUp.ToString("D") + " @ 12:00PM";
			Session["PickUpCar"] = pickUp.ToString("yyyy-MM-dd") + "T12:00:00";

			DateTime returnTime = Convert.ToDateTime((string)Session["ReturnCar"]);
			ReturnLabel.Text = returnTime.ToString("D") + " @ 12:00PM";
			Session["ReturnCar"] = returnTime.ToString("yyyy-MM-dd") + "T12:00:00";

			VehicleLabel.Text = (string)Session["Vehicle"];			
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
				SuccessLabel.Text = "You do not have an access token. Vehicle not booked.";
				SuccessLabel.Visible = true;
			}
			else
			{
				//Display success message
				SuccessLabel.Text = "You have successfully booked a vehicle. Thank you for choosing Ahmad Autos.";
				SuccessLabel.Visible = true;

				//Build XML for request
				StringWriter xmlContent = new StringWriter();
				XmlTextWriter writer = new XmlTextWriter(xmlContent);
				writer.Formatting = Formatting.Indented;
				writer.WriteStartElement("Booking");
				{
					writer.WriteStartElement("Segments");
					{
						writer.WriteStartElement("Car");
						{
							writer.WriteElementString("StartDateLocal", (string)Session["PickUpCar"]);
							writer.WriteElementString("EndDateLocal", (string)Session["ReturnCar"]);
							writer.WriteElementString("StartCityCode", (string)Session["Location"]);
							writer.WriteElementString("EndCityCode", (string)Session["Location"]);
							writer.WriteElementString("DailyRate", (string)Session["DailyRate"]);
							writer.WriteElementString("Currency", "USD");
							writer.WriteElementString("Vendor", "Ahmad Autos");
						}
						writer.WriteEndElement(); 
					}
					writer.WriteEndElement(); 
					writer.WriteElementString("RecordLocator", "AhmadAutos");
					writer.WriteElementString("BookingSource", "AhmadAutos.com");
					writer.WriteElementString("ItinSourceName", "Autos");
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
				HttpWebResponse response = HttpClient.Post(bookingApiUrl, headers, xmlContent.ToString());
			}			
		}

		/// <summary>
		/// Connect to Concur when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ConnectButton_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Car/ConfirmCar.aspx");
		}
	}
}
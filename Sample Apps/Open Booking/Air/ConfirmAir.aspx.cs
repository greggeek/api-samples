using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

using HttpRequestClient;

namespace WebPrototype
{
	public partial class ConfirmAir : System.Web.UI.Page
	{
		/// <summary>
		/// Populate fields from session variables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			//Check if the user connects to Concur and goes through web flow process. If so, set token.
			Settings settings = new Settings();
			settings.SetToken();

			if (Session["Token"] != null)
			{
				//Token exists, hide label and button
				ConnectLabel.Text = "Welcome, " + (string)(Session["UserName"]);
				ConnectButton.Visible = false;
			}	

			//Populate fields with sessions
			FlightLabel.Text = (string)Session["Flight"];
			FromLabel.Text = (string)Session["From"];
			ToLabel.Text = (string)Session["To"];

			DateTime depart = Convert.ToDateTime((string)Session["DepartDate"]);
			DepartLabel.Text = depart.ToString("D");

			DateTime returnDate = Convert.ToDateTime((string)Session["ReturnDate"]);
			ReturnLabel.Text = returnDate.ToString("D");
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
				SuccessLabel.Text = "You do not have an access token. Flight not booked.";
				SuccessLabel.Visible = true;
			}
			else
			{
				//Display success message
				SuccessLabel.Text = "You have successfully booked a flight. Thank you for choosing Steve Air.";
				SuccessLabel.Visible = true;

				//Create xml and post
				StringWriter xmlContent = new StringWriter();
				XmlTextWriter writer = new XmlTextWriter(xmlContent);
				writer.Formatting = Formatting.Indented;
				writer.WriteStartElement("Booking");
				{
					writer.WriteStartElement("Segments");
					{
						writer.WriteStartElement("Air");
						{
							writer.WriteElementString("StartDateLocal", (string)Session["DepartDate"]);
							writer.WriteElementString("EndDateLocal", (string)Session["ArriveDate"]);
							writer.WriteElementString("StartCityCode", (string)Session["From"]);
							writer.WriteElementString("EndCityCode", (string)Session["To"]);
							writer.WriteElementString("FlightNumber", (string)Session["Flight"]);						
							writer.WriteElementString("Vendor", "SteveAir");
							writer.WriteElementString("PerDiemLocation", "");
						}
						writer.WriteEndElement(); 
					}
					writer.WriteEndElement(); 
					writer.WriteElementString("BookingSource", "SteveAir.com");
					writer.WriteElementString("RecordLocator", "SteveAir");
					writer.WriteElementString("ItinSourceName", "Air");
				}
				writer.WriteEndElement(); 

				//Set Uri
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
		protected void ConnectButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(Settings.OauthWebRedirect + "/Air/ConfirmAir.aspx");
		}
	}
}
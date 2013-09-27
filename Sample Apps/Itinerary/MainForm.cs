using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;
using HttpRequestClient;

// Note:
// This sample uses the Microsoft Outlook .NET interop libraries.  These will be present if your system has Outlook installed
// and the .NET development tools were included when installing Microsoft Office.  

namespace ItinerarySampleApp
{
	public partial class MainForm : Form
	{
		#region Global Variables

		private string Token;
		private const string TokenFile = "token.txt";

		#endregion		

		/// <summary>
		/// Initializes the Main Form and gets the Token
		/// </summary>
		public MainForm()
		{
			try
			{
				InitializeComponent();
			  
				Token = SetToken();
			   
				//Get trips and load list view
				LoadListView();                
			}
			catch (Exception ex)
			{
				//Check to see if token is expired of invalid. If so, delete file and create new token
				if (ex.Message.Contains("403"))
				{
					//Delete current token, create new token, and load the list view using the new token
					File.Delete(TokenFile);
					Token = SetToken();
					LoadListView();
					MessageBox.Show(ex.Message + "\n\nInvalid or expired token. Creating a new token.", "Invalid Token");
				}
				else
				{
					MessageBox.Show(ex.Message);
				}                
			}            
		}

		#region Calendar Integration Methods

		/// <summary>
		/// Gets itineraries and post them to Outlook Calendar
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PostCalendarButton_Click(object sender, EventArgs e)
		{
			try
			{
				//Get list of itineraries and checked list and create a new Outlook Calendar
				List<Itinerary> itinList = ItineraryService.GetItineraryList(Token);
				ListView.CheckedListViewItemCollection checkedTrips = TripListView.CheckedItems;
				OutlookCalendar outlook = new OutlookCalendar();

				//Get appointments that are currently posted to calendar
				List<string> apptList = outlook.GetOofAppointmentSubjects();

				//If nothing is checked, post all itineraries, else post checked itineraries
				if (checkedTrips.Count == 0)
				{
					//Post itinerary to calendar only if it is not on the calendar yet
					foreach (Itinerary itin in itinList)
					{
						if (!apptList.Contains(itin.TripName))
						{
							outlook.PostToCalendar(itin);
						}
					}
				}
				else
				{
					foreach (ListViewItem trip in checkedTrips)
					{
						//Iterate through list of itineraries and check the trips that have been checked and post to calendar
						foreach (Itinerary itin in itinList)
						{
							if (itin.TripId.Equals(trip.Name))
							{
								//Post itinerary to calendar only if it is not on the calendar yet
								if (!apptList.Contains(itin.TripName))
								{
									outlook.PostToCalendar(itin);
								}
							}
						}
					}
				}

				MessageBox.Show("Your itineraries have been posted to your calendar.", "Posted to Calendar");
				StatusLabel.Text = "You have posted your itineraries to your calendar.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred when posting itineraries to your calendar: \n" + ex.Message, "Error");
			}
		}

		/// <summary>
		/// Post itineraries from calendar.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PostItinFromCalendarButton_Click(object sender, EventArgs e)
		{
			try
			{
				//Create a new OutlookCalendar and get OOF appointments from the calendar
				OutlookCalendar outlookCalendar = new OutlookCalendar();
				List<Itinerary> itins = outlookCalendar.PostOofAppointments(Token);

				foreach (Itinerary i in itins)
				{
					AddListView(i);
				}

				MessageBox.Show("You have created itineraries from your calendar.", "Create Itineraries");
				StatusLabel.Text = "You have created new itineraries from your calendar.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred when posting itineraries to your calendar: \n" + ex.Message, "Error");
			}
		}

		#endregion

		#region Concur Itinerary Methods

		/// <summary>
		/// Creates a new itinerary trip. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateItinButton_Click(object sender, EventArgs e)
		{
			DateTime start = StartDateTimePicker.Value;
			DateTime end   = EndDateTimePicker.Value;

			if (string.IsNullOrEmpty(TripNameTextBox.Text))
			{
				MessageBox.Show("Please enter a valid trip name.", "Invalid Trip Name");
			}
			else if (start.CompareTo(end) > 0)
			{
				MessageBox.Show("The end date must be after the start date.", "Invalid Date");
			}
			else
			{
				try
				{
					//Set the end time to 11:59PM and send a post request to create itinerary
					end = end.AddHours(23).AddMinutes(59);
					Itinerary createdItin = ItineraryService.PostItinerary(Token, TripNameTextBox.Text, start, end);

					//Add new itinerary to list view
					AddListView(createdItin);

					MessageBox.Show("You have created a new itinerary.", "Created New Itinerary");
					StatusLabel.Text = "You have created a new itinerary.";
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		#endregion

		#region List View Methods

		/// <summary>
		/// This method gets all itineraries and loads the list view
		/// </summary>
		private void LoadListView()
		{
			//Get trips and load list view
			List<Itinerary> trips = ItineraryService.GetItineraryList(Token);
			for (int i = 0; i < trips.Count; i++)
			{
				TripListView.Items.Add(trips[i].TripName, 0);
				TripListView.Items[i].Name = trips[i].TripId; 
				TripListView.Items[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			}
		}

		/// <summary>
		/// This method adds the itinerary to the list view
		/// </summary>
		/// <param name="itin"></param>
		private void AddListView(Itinerary itin)
		{
			TripListView.Items.Add(itin.TripName, 0);
			int tripCount = TripListView.Items.Count;
			TripListView.Items[tripCount - 1].Name = itin.TripId;
			TripListView.Items[tripCount - 1].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		}

		#endregion

		#region UI Event Methods

		/// <summary>
		/// Show about form when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About about = new About();
			about.Show();
		}

		/// <summary>
		/// Close application when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region Settings Methods

		/// <summary>
		/// Sets the token for the user
		/// </summary>
		/// <param name="settings"></param>
		private static string SetToken()
		{
			//Fetch credential information in order to get token
			const string accessTokenUrl = "https://www.concursolutions.com/net2/oauth2/accesstoken.ashx";
			string username = ConfigurationManager.AppSettings["userName"]; 
			string password = ConfigurationManager.AppSettings["password"];
			string consumerKey = ConfigurationManager.AppSettings["consumerKey"];

			string token = String.Empty;

			//Check to see if token already exists and that the token is a valid oauth token
			if (File.Exists(TokenFile))
			{
				token = File.ReadAllText(TokenFile);
			}
			else
			{
				//Since no token existed, create a new token and save to a file				
				Dictionary<string, string> headers = new Dictionary<string, string>();
				string authorization = string.Format("{0}:{1}", username, password);
				authorization = "Basic " + System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authorization));
				headers.Add("Authorization", authorization);
				headers.Add("X-ConsumerKey", consumerKey);

				HttpWebResponse response = HttpClient.Get(accessTokenUrl, headers);
				string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());
				token = HttpClient.GetElementValue("Token", responseString);

				//Write token to file
				using (StreamWriter sw = File.CreateText(TokenFile))
				{
					sw.WriteLine(token);
				}				
			}

			return token;
		}

		#endregion
	}
}

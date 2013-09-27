using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;

namespace ItinerarySampleApp
{
	public class OutlookCalendar 
	{
		private Application outlookApp = new Application();

		#region Post Calendar Methods

		/// <summary>
		/// Post selected itineraries onto Microsoft Outlook Calendar.
		/// </summary>
		/// <param name="itin">Itinerary object to post to calendar</param>
		public void PostToCalendar(Itinerary itin)
		{
			//Create outlook appointment       
			AppointmentItem appointment = (AppointmentItem)outlookApp.CreateItem(OlItemType.olAppointmentItem);

			//Set appointment information
			appointment.Subject = itin.TripName;
			appointment.Start = Convert.ToDateTime(itin.StartDateLocal);
			appointment.End = Convert.ToDateTime(itin.EndDateLocal);
			appointment.Body = String.Format("I will be out of the office from {0} until {1}.", appointment.Start.ToString("D"), appointment.End.ToString("D"));
			appointment.BusyStatus = OlBusyStatus.olOutOfOffice;
			appointment.AllDayEvent = true;

			//Save appointment and post to outlook calendar              
			appointment.Save();
		}

		/// <summary>
		/// This method will post a new itinerary from the Outlook appointment and returns a list of responses for each 
		/// itinerary created
		/// </summary>
		/// <returns>List of created itineraries</returns>
		public List<Itinerary> PostOofAppointments(string token)
		{
			List<Itinerary> itins = new List<Itinerary>();

			//Get outlook folder and appointment items within folder            
			Items appointments = GetAppointmentItems();            

			//Get only OOF appointments and create itinerary for the OOF appointment
			foreach (AppointmentItem item in appointments)
			{
				if (item.BusyStatus == OlBusyStatus.olOutOfOffice)
				{                    
					Itinerary itin = ItineraryService.PostItinerary(token, item.Subject, item.Start, item.End);
					itins.Add(itin);                   
				}
			}

			return itins;
		}

		#endregion

		#region Get Appointment Methods		

		/// <summary>
		/// This method will return the OOF appointments that are currently posted on Outlook
		/// </summary>
		/// <returns></returns>
		public List<string> GetOofAppointmentSubjects()
		{            
			//Get outlook folder and appointment items within folder
			Items appointments = GetAppointmentItems();

			List<string> appointmentNames = new List<string>();

			//Get only OOF appointments and create itinerary for the OOF appointment
			foreach (AppointmentItem item in appointments)
			{
				if (item.BusyStatus == OlBusyStatus.olOutOfOffice)
				{
					appointmentNames.Add(item.Subject);
				}                
			}

			return appointmentNames;
		}

		/// <summary>
		/// This method will get all the appointment items and return a list of items
		/// </summary>
		/// <returns></returns>
		private Items GetAppointmentItems()
		{
			//Get outlook folder and appointment items within folder
			Folder outlookFolder = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar) as Folder;
			Items appointments = outlookFolder.Items;
			appointments.IncludeRecurrences = false;

			return appointments;
		}

		#endregion
	}
}

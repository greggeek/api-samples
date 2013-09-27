using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using HttpRequestClient;

namespace ItinerarySampleApp
{
	public class ItineraryService
	{
		private const string URL = "https://www.concursolutions.com/api/travel/trip/v1.1/";
		private const string TOKEN_ERROR = "You must provide an access token.";

		#region Get Itinerary Methods

		/// <summary>
		/// Makes a request to the itinerary API and gets all the itineraries for the user.
		/// </summary>
		/// <param name="token">Token for request</param>
		/// <returns>List of itinerary objects</returns>
		static public List<Itinerary> GetItineraryList(string token)
		{
			//Handle exceptions
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			List<Itinerary> itineraryList = new List<Itinerary>();

			//Get itineraries
			HttpWebResponse response = HttpClient.Get(URL, token);
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());

			//Load XML response to create itinerary objects
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(responseString);
			XmlNodeList itineraries = xmlDoc.GetElementsByTagName("ItineraryInfo");

			if (itineraries == null)
			{
				throw new Exception("Unable to get list of itineraries. Node list of itineraries is null.");
			}

			//Create itinerary objects
			foreach (XmlNode node in itineraries)
			{
				Itinerary itin = ConvertXmlToItinerary(node.OuterXml);
				itineraryList.Add(itin);
			}

			return itineraryList;
		}

		#endregion

		#region Post Itinerary Methods

		/// <summary>
		/// Create a new trip itinerary for the user on the specified dates
		/// </summary>
		/// <param name="token">Token for request</param>
		/// <param name="tripName">Name of the trip</param>
		/// <param name="start">Start date of the trip</param>
		/// <param name="end">End date of the trip</param>
		/// <returns>Created Itinerary</returns>
		static public Itinerary PostItinerary(string token, string tripName, DateTime start, DateTime end)
		{
			//Handle exceptions            
			if(String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}
			else if (String.IsNullOrEmpty(tripName))
			{
				throw new ArgumentException("You must provide a trip name.", "tripName");
			}
			else if (start.CompareTo(end) > 0)
			{
				throw new ArgumentException("Start date must be before the end date.", "start");
			}
			
			//Set the OAuth header
			Dictionary<string, string> headers = new Dictionary<string, string>();
			string oauth = String.Format("OAuth {0}", token);
			headers.Add("Authorization", oauth);

			//Build the XML request body
			StringWriter xmlContent = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(xmlContent);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartElement("Itinerary", "http://www.concursolutions.com/api/travel/trip/2010/06");
			{
				writer.WriteElementString("TripName", tripName);
				writer.WriteElementString("StartDateLocal", start.ToString("s"));
				writer.WriteElementString("EndDateLocal", end.ToString("s"));
			}
			writer.WriteEndElement();

			//Post the itinerary
			HttpWebResponse response = HttpClient.Post(URL, headers, xmlContent.ToString());
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());

			//Create the itinerary from the response XML
			return ConvertXmlToItinerary(responseString);
		}

		#endregion

		private static Itinerary ConvertXmlToItinerary(string xml)
		{
			Itinerary itin = new Itinerary();

			//Handle exceptions
			const string unable = "Unable to create an itinerary object. ";
			if (String.IsNullOrEmpty(xml))
			{
				throw new Exception(unable + "Invalid XML");
			}

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);

			//Get the trip Id
			XmlNode tripIdNode = xmlDoc.SelectSingleNode("//*[local-name()='TripId']");
			if (tripIdNode == null)
			{
				throw new Exception(unable + "Trip Id node is null..");
			}
			itin.TripId = tripIdNode.InnerText;

			//Get the trip name 
			XmlNode tripNameNode = xmlDoc.SelectSingleNode("//*[local-name()='TripName']");
			if (tripNameNode == null)
			{
				throw new Exception(unable + "Trip name node is null.");
			}
			itin.TripName = tripNameNode.InnerText;

			//Get the trip status 
			XmlNode tripStatusNode = xmlDoc.SelectSingleNode("//*[local-name()='TripStatus']");
			if (tripStatusNode != null)
			{
				itin.TripStatus = tripStatusNode.InnerText;
			}

			//Get the start date
			XmlNode startNode = xmlDoc.SelectSingleNode("//*[local-name()='StartDateLocal']");
			if (startNode == null)
			{
				throw new Exception(unable + "Start date node is null.");
			}
			DateTime startDate = Convert.ToDateTime(startNode.InnerText);
			itin.StartDateLocal = startDate;

			//Get the end date
			XmlNode endNode = xmlDoc.SelectSingleNode("//*[local-name()='EndDateLocal']");
			if (endNode == null)
			{
				throw new Exception(unable + "End date node is null.");
			}
			DateTime endDate = Convert.ToDateTime(endNode.InnerText);
			itin.EndDateLocal = endDate;

			//Get the user login ID
			XmlNode userLoginNode = xmlDoc.SelectSingleNode("//*[local-name()='UserLoginId']");
			if (userLoginNode != null)
			{
				itin.UserLoginId = userLoginNode.InnerText;
			}

			//Get the date modified UTC
			XmlNode dateModifiedNode = xmlDoc.SelectSingleNode("//*[local-name()='DateModifiedUtc']");
			if (dateModifiedNode == null)
			{
				throw new Exception(unable + "Date modified node is null.");
			}
			DateTime dateModified = Convert.ToDateTime(dateModifiedNode.InnerText);
			itin.DateModifiedUtc = dateModified;

			//Get the id
			XmlNode idNode = xmlDoc.SelectSingleNode("//*[local-name()='id']");
			if (idNode == null)
			{
				throw new Exception(unable + "ID node is null.");
			}
			itin.id = idNode.InnerText;

			return itin;
		}
	}
}

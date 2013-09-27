using System;

namespace ItinerarySampleApp
{
	public class Itinerary
	{
		public string TripId { get; set; }
		public string TripName { get; set; }
		public string TripStatus { get; set; }
		public DateTime StartDateLocal { get; set; }
		public DateTime EndDateLocal { get; set; }
		public string UserLoginId { get; set; }
		public DateTime DateModifiedUtc { get; set; }
		public string id { get; set; }	
	}
}

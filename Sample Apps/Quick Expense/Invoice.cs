using System.Collections.Generic;

namespace QuickExpenseSample
{
	/// <summary>
	/// This class is an abstract class that represents a general invoice
	/// and used to capture information from the invoice to post a new quick expense
	/// </summary>
	public abstract class Invoice
	{       
		//List of the items ordered and their prices within a particular invoice
		public List<string> ListItem { get; set; }
		public List<string> ListItemPrice { get; set; }

		public string OrderDate { get; set; }
		public string OrderNumber { get; set; }
		public string OrderTotal { get; set; }

		//Shipping price for the entire order
		public List<string> ShippingPrice { get; set; }

		public abstract string Vendor { get; }
	}
}

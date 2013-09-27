using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using HtmlAgilityPack;

namespace QuickExpenseSample
{
	/// <summary>
	/// This class is a representation of a particular Amazon invoice
	/// </summary>
	public class AmazonInvoice : Invoice
	{
		#region CONSTANTS

		private const int SUMMARY_TABLE = 1;
		private const int ITEMS_TABLE = 7;
		private const int SHIPPING_TABLE = 15;

		private const int SHIPPING_ROW = 1;
		private const int THIRD_SUM_ROW = 2;
		private const int FOURTH_SUM_ROW = 3;

		private const int ORDER_DATE = 0;
		private const int ORDER_NUMBER = 1;

		#endregion		

		//Amazon invoice additional properties 
		public HtmlNodeCollection ListItemCollection;
		public HtmlNodeCollection ListItemPriceCollection;
		public HtmlNodeCollection ShippingPriceCollection;

		/// <summary>
		/// Creates an Amazon invoice object from the HtmlDocument passed
		/// </summary>
		/// <param name="htmlDoc"></param>
		public AmazonInvoice(HtmlAgilityPack.HtmlDocument htmlDoc)
		{
			try
			{
				//Get all table elements
				HtmlNodeCollection tables = htmlDoc.DocumentNode.SelectNodes("//table"); 
				HtmlNode summaryTable = tables[SUMMARY_TABLE]; 
				HtmlAgilityPack.HtmlDocument summaryDoc = new HtmlAgilityPack.HtmlDocument();
				summaryDoc.LoadHtml(summaryTable.OuterHtml);
				
				//Get the rows with order date, order number, and order price
				HtmlNodeCollection sumRows = summaryDoc.DocumentNode.SelectNodes("//tr"); 

				//Get information from the summary rows
				OrderDate = GetOrderDate(sumRows[ORDER_DATE].InnerText); 
				OrderNumber = GetOrderNumber(sumRows[ORDER_NUMBER].InnerText); 
				OrderTotal = GetOrderTotal(sumRows); 
				
				//Gets the shipping information
				ShippingPriceCollection = GetShippingPrice(tables); //pass in tables

				//Get item price and item name
				HtmlNode itemsTable = tables[ITEMS_TABLE]; //Get the table that has the rows of the items ordered
				HtmlAgilityPack.HtmlDocument itemsDoc = new HtmlAgilityPack.HtmlDocument();
				itemsDoc.LoadHtml(itemsTable.OuterHtml);
				ListItemCollection = itemsDoc.DocumentNode.SelectNodes("//tr/td/i"); //List of items
				ListItemPriceCollection = itemsDoc.DocumentNode.SelectNodes("//tr/td[2]"); //List of items' prices
				ListItemPriceCollection.RemoveAt(0); //Remove price label
			}
			catch 
			{
				throw new System.Exception("Unable to create invoice.");
			}
		}

		#region Private Methods

		/// <summary>
		/// Get the order number
		/// </summary>
		/// <returns></returns>
		private string GetOrderNumber(string sumOrderNum)
		{
			string orderNum = String.Empty;
			try
			{
				orderNum = sumOrderNum;
				orderNum = RemoveWhiteSpace(orderNum);
				orderNum = orderNum.Substring(26);
			}
			catch 
			{
				throw new System.Exception("Unable to get the order number for invoice.");
			}
			
			return orderNum;
		}

		/// <summary>
		/// Get the order date
		/// </summary>
		/// <returns></returns>
		private string GetOrderDate(string sumOrderDate)
		{
			const int MONTH = 3;
			const int DAY = 4;
			const int YEAR = 5;
			string orderDate = String.Empty;
			
			try
			{
				orderDate = sumOrderDate; 
				orderDate = RemoveWhiteSpace(orderDate);
 
				//Dictionary to convert from string month format to digit format
				Dictionary<string, string> month = new Dictionary<string, string>()
				{
					{"January","01"}, {"February","02"}, {"March","03"}, {"April","04"}, {"May","05"}, {"June","06"}, {"July","07"},
					{"August","08"}, {"September","09"}, {"October","10"}, {"November","11"}, {"December","12"}
				};
				string[] date = orderDate.Split(' ');

				//Get the month from the date string
				int moInt = Convert.ToInt32(month[date[MONTH]]);
				string mo = moInt.ToString("D2"); //two digit month

				//Get the day from the date string and check to see if day is a single or double digit and remove comma
				int dayInt;
				if (String.Equals(date[DAY].Substring(1), ","))
				{
					dayInt = Convert.ToInt32(date[DAY].Substring(0, 1));
				}
				else
				{
					dayInt = Convert.ToInt32(date[DAY].Substring(0, 2));
				}
				string day = dayInt.ToString("D2");

				//Get the year from the date string
				string year = date[YEAR];
				orderDate = String.Format("{0}-{1}-{2}", year, mo, day);
			}
			catch 
			{
				throw new System.Exception("Unable to capture order date for invoice.");
			}

			return orderDate;
		}

		/// <summary>
		/// Get the order total
		/// </summary>
		/// <returns></returns>
		private string GetOrderTotal(HtmlNodeCollection sumRows)
		{
			string orderTotal = String.Empty;
			try
			{   //Check to see if there is a seller's order number row in summary table
				if (sumRows[THIRD_SUM_ROW].InnerText.Contains("Seller's order number:")) 
				{
					orderTotal = sumRows[FOURTH_SUM_ROW].InnerText;
				}
				else
				{
					orderTotal = sumRows[THIRD_SUM_ROW].InnerText;
				}
				orderTotal = RemoveWhiteSpace(orderTotal);
				orderTotal = orderTotal.Substring(15);
			}
			catch 
			{
				throw new System.Exception("Unable to get order detail for invoice");
			}
			
			return orderTotal;
		}

		/// <summary>
		/// Get the shipping price
		/// </summary>
		/// <returns></returns>
		private HtmlNodeCollection GetShippingPrice(HtmlNodeCollection tables)
		{
			HtmlNodeCollection shippingPriceNodes = null;
			try
			{
				//Table with shipping information
				HtmlNode shippingTable = tables[SHIPPING_TABLE]; 
				HtmlAgilityPack.HtmlDocument shippingDoc = new HtmlAgilityPack.HtmlDocument();
				shippingDoc.LoadHtml(shippingTable.OuterHtml);

				//Row with total information
				HtmlNodeCollection totalInfo = shippingDoc.DocumentNode.SelectNodes("//tr"); 
				HtmlNode shipping = totalInfo[SHIPPING_ROW];
				HtmlAgilityPack.HtmlDocument shipPriceDoc = new HtmlAgilityPack.HtmlDocument();
				shipPriceDoc.LoadHtml(shipping.OuterHtml);
				shippingPriceNodes = shipPriceDoc.DocumentNode.SelectNodes("//td");
			}
			catch 
			{
				throw new System.Exception("Unable to capture shipping price for invoice.");
			}
			
			return shippingPriceNodes;
		}

		/// <summary>
		/// Helper method to remove white spaces 
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		private string RemoveWhiteSpace(string word)
		{
			word = Regex.Replace(word, @"\t|\n|\r", "");
			word = Regex.Replace(word, @"\s+", " ");
			return word;
		}

		#endregion

		#region Override Methods

		/// <summary>
		/// Override property and set to Amazon.com
		/// </summary>
		public override string Vendor
		{
			get { return "Amazon.com"; }
		}

		#endregion
	}
}

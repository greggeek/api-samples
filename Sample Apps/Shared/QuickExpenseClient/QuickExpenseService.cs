using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

using HttpRequestClient;

namespace QuickExpenseClient
{
	/// <summary>
	/// This class is responsible for making requests to the Quick Expense API
	/// </summary>
	public class QuickExpenseService
	{
		private const string URL = "https://www.concursolutions.com/api/v3.0/expense/QuickExpenses/";
		private const string TOKEN_ERROR = "You must provide an access token.";
		private const string ID_ERROR = "You must provide a resource ID.";

		#region Public Methods

		#region Delete Quick Expense

		/// <summary>
		/// DELETE the particular quick expense related to the ID passed.
		/// </summary>
		/// <param name="token">Token for the request</param>
		/// <param name="id">ID of the quick expense</param>
		static public void Delete(string token, string id)
		{
			//Handle exception 
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			if (String.IsNullOrEmpty(id))
			{
				throw new ArgumentException(ID_ERROR, "id");
			}

			string quickExpenseUrl = URL + id;

			HttpClient.Delete(quickExpenseUrl, token);
		}

		#endregion		

		#region Get Quick Expense

		/// <summary>
		/// GET a quick expense with the specified ID.
		/// </summary>
		/// <param name="token">Token for the request</param>
		/// <param name="id">ID of quick expense</param>
		/// <returns>Quick expense object</returns>
		static public QuickExpenseGet Get(string token, string id)
		{
			//Handle exceptions
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			if (String.IsNullOrEmpty(id))
			{
				throw new ArgumentException(ID_ERROR, "id");
			}

			string quickExpenseUrl = URL + id;

			//Add headers to dictionary
			Dictionary<string, string> headers = new Dictionary<string, string>();
			string oauth = string.Format("OAuth {0}", token);
			headers.Add("Authorization", oauth);
			headers.Add("Accept", "application/xml");

			HttpWebResponse response = HttpClient.Get(quickExpenseUrl, headers);
			string xml = HttpClient.GetStringFromStream(response.GetResponseStream());

			QuickExpenseGet qe = ConvertXmlResponseToQuickExpense(xml);

			return qe;
		}

		/// <summary>
		/// GET a list of quick expenses.
		/// </summary>
		/// <param name="token">Token for the request</param>
		/// <returns></returns>
		static public List<QuickExpenseGet> Get(string token)
		{
			//Handle exceptions
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			string quickExpenseUrl = URL;

			//Add headers to dictionary
			Dictionary<string, string> headers = new Dictionary<string, string>();
			string oauth = string.Format("OAuth {0}", token);
			headers.Add("Authorization", oauth);
			headers.Add("Accept", "application/xml");

			HttpWebResponse response = HttpClient.Get(quickExpenseUrl, headers);
			string xml = HttpClient.GetStringFromStream(response.GetResponseStream());			

			//Create quick expense object from quick expense xml node and add to the list
			List<QuickExpenseGet> quickExpenseList = new List<QuickExpenseGet>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);
			XmlNodeList xmlList = xmlDoc.GetElementsByTagName("QuickExpense");

			//Iterate through xml list to create quick expense objects and add it to the list
			foreach (XmlNode node in xmlList)
			{
				QuickExpenseGet qe = ConvertXmlResponseToQuickExpense(node.OuterXml);
				quickExpenseList.Add(qe);
			}

			return quickExpenseList;
		}

		#endregion

		#region Post Quick Expense

		/// <summary>
		/// POST a quick expense object.
		/// </summary>
		/// <param name="token">Token for the request</param>
		/// <param name="qe">Quick expense object to POST</param>
		/// <returns>ID of the created quick expense</returns>
		static public string Post(string token, QuickExpensePost qe)
		{
			//Handle exception for parameters
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			if (qe == null)
			{
				throw new ArgumentException("You must provide a quick expense object.", "qe");
			}
			
			//Add headers to dictionary
			Dictionary<string, string> headers = new Dictionary<string, string>();
			string oauth = string.Format("OAuth {0}", token);
			headers.Add("Authorization", oauth);
			headers.Add("ContentType", "application/xml");
			headers.Add("Accept", "application/xml");

			//Build the XML content request body
			StringWriter xmlContent = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(xmlContent);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartElement("QuickExpense");
			{
				writer.WriteElementString("Comment", qe.Comment);
				writer.WriteElementString("CurrencyCode", qe.CurrencyCode);
				writer.WriteElementString("ExpenseTypeCode", qe.ExpenseTypeCode);
				writer.WriteElementString("LocationCity", qe.LocationCity);
				writer.WriteElementString("LocationCountry", qe.LocationCountry);
				writer.WriteElementString("LocationSubdivision", qe.LocationSubdivision);
				writer.WriteElementString("PaymentTypeCode", qe.PaymentTypeCode);
				writer.WriteElementString("ReceiptImageID", qe.ReceiptImageID);
				writer.WriteElementString("SpendCategoryCode", qe.SpendCategoryCode);
				writer.WriteElementString("TransactionAmount", qe.TransactionAmount.ToString());
				writer.WriteElementString("TransactionDate", qe.TransactionDate.ToString("s"));
				writer.WriteElementString("VendorDescription", qe.VendorDescription);				
			}
			writer.WriteEndElement();

			//Call the service and get the ID for the quick expense
			HttpWebResponse response = HttpClient.Post(URL, headers, xmlContent.ToString());
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());
			string id = HttpClient.GetElementValue("ID", responseString);

			return id;
		}

		#endregion

		#region Put Quick Expense

		/// <summary>
		/// UPDATE a quick expense related to the ID passed.
		/// </summary>
		/// <param name="token">Token for request</param>
		/// <param name="qe">Quick expense object to update</param>
		/// <param name="id">ID of the quick expense</param>
		static public void Put(string token, QuickExpensePut qe, string id)
		{
			//Handle exception 
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			if (qe == null)
			{
				throw new ArgumentException("You must provide a quick expense object.", "qe");
			}

			if (String.IsNullOrEmpty(id))
			{
				throw new ArgumentException(ID_ERROR, "id");
			}

			string quickExpenseUrl = URL + id;

			//Add headers to dictionary
			Dictionary<string, string> headers = new Dictionary<string, string>();
			string oauth = string.Format("OAuth {0}", token);
			headers.Add("Authorization", oauth);
			headers.Add("ContentType", "application/xml");

			//Build the XML content request body
			StringWriter xmlContent = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(xmlContent);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartElement("QuickExpense");
			{
				if (qe.Comment != null) writer.WriteElementString("Comment", qe.Comment);
				if (qe.CurrencyCode != null) writer.WriteElementString("CurrencyCode", qe.CurrencyCode);
				if (qe.ExpenseTypeCode != null) writer.WriteElementString("ExpenseTypeCode", qe.ExpenseTypeCode);
				if (qe.LocationCity != null) writer.WriteElementString("LocationCity", qe.LocationCity);
				if (qe.LocationCountry != null) writer.WriteElementString("LocationCountry", qe.LocationCountry);
				if (qe.LocationSubdivision != null) writer.WriteElementString("LocationSubdivision", qe.LocationSubdivision);
				if (qe.PaymentTypeCode != null) writer.WriteElementString("PaymentTypeCode", qe.PaymentTypeCode);
				if (qe.ReceiptImageID != null) writer.WriteElementString("ReceiptImageID", qe.ReceiptImageID);
				if (qe.SpendCategoryCode != null) writer.WriteElementString("SpendCategoryCode", qe.SpendCategoryCode);
				if (qe.TransactionAmount != null) writer.WriteElementString("TransactionAmount", qe.TransactionAmount.ToString());
				if (qe.TransactionDate != null) writer.WriteElementString("TransactionDate", qe.TransactionDate.Value.ToString("s"));
				if (qe.VendorDescription != null) writer.WriteElementString("VendorDescription", qe.VendorDescription);
			}
			writer.WriteEndElement();

			//Call the service and update the quick expense
			HttpClient.Put(quickExpenseUrl, headers, xmlContent.ToString());
		}

		#endregion

		#endregion

		#region Private Methods

		/// <summary>
		/// This method converts the XML response to a quick expense object
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		private static QuickExpenseGet ConvertXmlResponseToQuickExpense(string xml)
		{
			QuickExpenseGet qe = new QuickExpenseGet();

			const string unable = "Unable to create quick expense object. ";
			if (string.IsNullOrEmpty(xml))
			{
				throw new ArgumentException(unable + "Invalid XML.","xml");
			}

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);

			//Get comment
			XmlNode commentNode = xmlDoc.SelectSingleNode("//*[local-name()='Comment']");
			if (commentNode == null)
			{
				throw new Exception(unable + "Comment node is null.");
			}
			qe.Comment = commentNode.InnerText;

			//Get currency code
			XmlNode currencyNode = xmlDoc.SelectSingleNode("//*[local-name()='CurrencyCode']");
			if (currencyNode == null)
			{
				throw new Exception(unable + "Currency node is null.");
			}
			qe.CurrencyCode = currencyNode.InnerText;

			//Get expense type code
			XmlNode expenseTypeCodeNode = xmlDoc.SelectSingleNode("//*[local-name()='ExpenseTypeCode']");
			if (expenseTypeCodeNode == null)
			{
				throw new Exception(unable + "ExpenseTypeCode node is null.");
			}
			qe.ExpenseTypeCode = expenseTypeCodeNode.InnerText;

			//Get expense type name
			XmlNode expenseTypeNameNode = xmlDoc.SelectSingleNode("//*[local-name()='ExpenseTypeName']");
			if (expenseTypeNameNode == null)
			{
				throw new Exception(unable + "Expense name node is null.");
			}
			qe.ExpenseTypeName = expenseTypeNameNode.InnerText;

			//Get location 
			XmlNode locationNode = xmlDoc.SelectSingleNode("//*[local-name()='LocationName']");
			if (locationNode == null)
			{
				throw new Exception(unable + "Location node is null.");
			}
			qe.LocationName = locationNode.InnerText;

			//Get owner login
			XmlNode ownerLoginNode = xmlDoc.SelectSingleNode("//*[local-name()='OwnerLoginID']");
			if (ownerLoginNode == null)
			{
				throw new Exception(unable + "Owner login node is null.");
			}
			qe.OwnerLoginID = ownerLoginNode.InnerText;

			//Get owner name
			XmlNode ownerNameNode = xmlDoc.SelectSingleNode("//*[local-name()='OwnerName']");
			if (ownerNameNode == null)
			{
				throw new Exception(unable + "Owner name node is null.");
			}
			qe.OwnerName = ownerNameNode.InnerText;

			//Get payment type code
			XmlNode paymentNode = xmlDoc.SelectSingleNode("//*[local-name()='PaymentTypeCode']");
			if (paymentNode == null)
			{
				throw new Exception(unable + "Payment type code node is null.");
			}
			qe.PaymentTypeCode = paymentNode.InnerText;

			//Get quick expense ID
			XmlNode quickExpenseIdNode = xmlDoc.SelectSingleNode("//*[local-name()='ID']");
			if (quickExpenseIdNode == null)
			{
				throw new Exception(unable + "Quick expense ID node is null.");
			}
			qe.ID = quickExpenseIdNode.InnerText;

			//Get receiptID
			XmlNode receiptNode = xmlDoc.SelectSingleNode("//*[local-name()='ReceiptImageID']");
			if (receiptNode == null)
			{
				throw new Exception(unable + "Receipt node is null.");
			}
			qe.ReceiptImageID = receiptNode.InnerText;

			//Get transaction amount
			XmlNode transAmountNode = xmlDoc.SelectSingleNode("//*[local-name()='TransactionAmount']");
			if (transAmountNode == null)
			{
				throw new Exception(unable + "Transaction amount node is null.");
			}
			qe.TransactionAmount = Convert.ToDecimal(transAmountNode.InnerText);

			//Get transaction date
			XmlNode transDateNode = xmlDoc.SelectSingleNode("//*[local-name()='TransactionDate']");
			if (transDateNode == null)
			{
				throw new Exception(unable + "Transaction date node is null.");
			}
			qe.TransactionDate = Convert.ToDateTime(transDateNode.InnerText);

			//Get URI
			XmlNode uriNode = xmlDoc.SelectSingleNode("//*[local-name()='URI']");
			if (uriNode == null)
			{
				throw new Exception(unable + "URI node is null.");
			}
			qe.URI = uriNode.InnerText;

			//Get vendor description
			XmlNode vendorNode = xmlDoc.SelectSingleNode("//*[local-name()='VendorDescription']");
			if (vendorNode == null)
			{
				throw new Exception(unable + "Vendor description node is null.");
			}
			qe.VendorDescription = vendorNode.InnerText;

			return qe;
		}

		#endregion
	}
}

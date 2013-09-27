using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

using HttpRequestClient;

namespace ImageClient
{
	public class ImageService
	{
		private const string URL = "https://www.concursolutions.com/api/v3.0/expense/receiptimages/";
		private const string TOKEN_ERROR = "You must provide an access token.";
		private const string ID_ERROR = "You must provide a resource ID.";

		#region Public Methods

		#region Delete Receipt Image

		/// <summary>
		/// DELETE the particular receipt image related to the ID passed.
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

			string receiptImageUrl = URL + id;

			HttpClient.Delete(receiptImageUrl, token);
		}

		#endregion

		#region Get Receipt Image

		/// <summary>
		/// GET a list of receipt image objects.
		/// </summary>
		/// <param name="token">Token for the request</param>
		/// <returns>List of receipt image objects</returns>
		static public List<ReceiptImage> Get(string token)
		{
			//Handle exceptions
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			//Make GET request and get the response
			HttpWebResponse response = HttpClient.Get(URL, token);
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());

			//Create list of strings to store receipt IDs
			List<ReceiptImage> receiptImageList = new List<ReceiptImage>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(responseString);
			XmlNodeList xmlList = xmlDoc.GetElementsByTagName("ReceiptImage");

			//Iterate through XML list to fetch the ID for each receipt and add it to the list
			foreach (XmlNode node in xmlList)
			{
				ReceiptImage receipt = ConvertXmlToReceiptImage(node.OuterXml);
				receiptImageList.Add(receipt);
			}

			return receiptImageList;
		}

		/// <summary>
		/// GET a particular receipt image object specified by the ID.
		/// </summary>
		/// <param name="token">Token for the request</param>
		/// <param name="receiptId">ID of the receipt image</param>
		/// <returns>Receipt image object</returns>
		static public ReceiptImage Get(string token, string receiptId)
		{
			//Handle exceptions
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			if (String.IsNullOrEmpty(receiptId))
			{
				throw new ArgumentException(ID_ERROR, "receiptId");
			}

			string imageUrlApi = URL+ receiptId;

			//Make request to get the image URL			
			HttpWebResponse response = HttpClient.Get(imageUrlApi, token);
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());

			ReceiptImage receipt = ConvertXmlToReceiptImage(responseString);

			return receipt;
		}

		#endregion

		#region Post Receipt Image

		/// <summary>
		/// POST a new image to the receipt store and returns a receipt image object
		/// </summary>
		/// <param name="token">Token for the request</param>
		/// <param name="file">File of the image</param>
		/// <returns>Receipt image object</returns>
		static public ReceiptImage Post(string token, string file)
		{
			//Handle exception for parameters
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			if (String.IsNullOrEmpty(file) || !File.Exists(file))
			{
				throw new ArgumentException("Invalid file name or file not found.", "file");
			}

			HttpWebResponse response = ExecutePostPut("POST", URL, token, file);
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());

			ReceiptImage receipt = ConvertXmlToReceiptImage(responseString);

			return receipt;
		}

		#endregion	

		#region Put Receipt Image

		/// <summary>
		/// APPEND a receipt image to an existing image in the receipt store.
		/// </summary>
		/// <param name="token">Token for request</param>
		/// <param name="file">Image file</param>
		/// <param name="id">Receipt ID to update</param>
		static public void Put(string token, string file, string id)
		{
			//Handle exception for parameters
			if (String.IsNullOrEmpty(token))
			{
				throw new ArgumentException(TOKEN_ERROR, "token");
			}

			if (String.IsNullOrEmpty(file) || !File.Exists(file))
			{
				throw new ArgumentException("Invalid file name or file not found.", "file");
			}

			if (String.IsNullOrEmpty(id))
			{
				throw new ArgumentException(ID_ERROR, "id");
			}

			string imagingApiUrl = URL + id;

			ExecutePostPut("PUT", imagingApiUrl, token, file);
		}

		#endregion

		#endregion

		#region Private Methods

		/// <summary>
		/// Execute a POST or PUT request depending on the method passed
		/// </summary>
		/// <param name="method">Type of request to make</param>
		/// <param name="url">URL of the request</param>
		/// <param name="token">Token for the request</param>
		/// <param name="file">Image file to POST or PUT</param>
		/// <returns>Response from service</returns>
		private static HttpWebResponse ExecutePostPut(string method, string url, string token, string file)
		{
			//Set request			
			Dictionary<string, string> headers = new Dictionary<string, string>();
			string oauth = string.Format("OAuth {0}", token);
			headers.Add("Authorization", oauth);

			//Check the extension for the file, set the correct content type, and add it to headers
			string extension = Path.GetExtension(file);
			if (String.IsNullOrEmpty(extension))
			{
				throw new Exception("Cannot determine file type because no extension exists.");
			}

			if (String.Compare(extension, ".pdf", true) == 0) headers.Add("ContentType", "application/pdf");
			else if (String.Compare(extension, ".jpg", true) == 0) headers.Add("ContentType", "image/jpg");
			else if (String.Compare(extension, ".jpeg", true) == 0) headers.Add("ContentType", "image/jpeg");
			else if (String.Compare(extension, ".png", true) == 0) headers.Add("ContentType", "image/png");
			else throw new Exception("Unsupported image type.");

			//Adds the image bytes to the request
			byte[] image;
			using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					image = br.ReadBytes((int)fs.Length);
				}
			}

			//Check to see if it is a POST or PUT and send correct request
			HttpWebResponse response = null;
			if (string.Equals(method, "POST"))
			{
				response = HttpClient.Post(url, headers, image);
			}
			else
			{
				response = HttpClient.Put(url, headers, image);
			}

			return response;
		}

		/// <summary>
		/// Converts the XML response to a receipt image object.
		/// </summary>
		/// <param name="xml">XML response</param>
		/// <returns>Receipt image object</returns>
		private static ReceiptImage ConvertXmlToReceiptImage(string xml)
		{
			ReceiptImage receipt = new ReceiptImage();

			//Load XML document
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);

			//Get ID
			XmlNode idNode = xmlDoc.SelectSingleNode("//*[local-name()='ID']");
			if (idNode == null)
			{
				throw new Exception("Unable to create receipt object. ID node is null.");
			}
			receipt.ID = idNode.InnerText;

			//Get ID
			XmlNode uriNode = xmlDoc.SelectSingleNode("//*[local-name()='URI']");
			if (uriNode == null)
			{
				throw new Exception("Unable to create receipt object. URI node is null.");
			}
			receipt.URI = uriNode.InnerText;

			return receipt;
		}

		#endregion
	}
}

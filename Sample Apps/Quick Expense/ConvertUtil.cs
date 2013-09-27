using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using QuickExpenseClient;

using HtmlAgilityPack;

namespace QuickExpenseSample
{
	class ConvertUtil
	{
		#region Convert HTML to PDF

		/// <summary>
		/// Converts an HtmlDocument to PDF image
		/// </summary>
		/// <param name="htmlDoc">HtmlDocument to convert from</param>
		/// <param name="fileName">Filename of the PDF image</param>
		static public void ConvertHtmlToPdf(HtmlDocument htmlDoc, string fileName)
		{
			//Handle exceptions
			const string unable = "Unable to get encoded image string. ";
			if (htmlDoc == null)
			{
				throw new Exception(unable + "HtmlDocument object is null.");
			}

			if (String.IsNullOrEmpty(fileName))
			{
				throw new Exception(unable + "Invalid file name");
			}

			//Create new PDF document
			try
			{
				iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
				iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, new FileStream(Path.GetFullPath(fileName), FileMode.Create));
				pdfDoc.Open();

				//Reload the HTML document with just the <body> tag of the HTML file
				HtmlNode htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
				htmlDoc.LoadHtml(htmlBody.OuterHtml);

				//Remove tags that we don't need to generate into PDF
				foreach (HtmlNode node in htmlDoc.DocumentNode.Descendants())
				{
					//Delete image tags whose source is not a URL, as well as script and style tags
					if ((node.Name.Equals("img") && !node.OuterHtml.Contains("http")) || node.Name.Equals("script") || node.Name.Equals("style"))
					{
						node.RemoveAll();
					}
				}

				//String of HTML 
				string html = htmlDoc.DocumentNode.OuterHtml;

				//Get all of the elements and add them to the PDF documents
				List<iTextSharp.text.IElement> list = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(html), null);
				foreach (iTextSharp.text.IElement elm in list)
				{
					pdfDoc.Add(elm);
				}

				//Close document
				pdfDoc.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + "\nUnable to generate PDF.");
			}
		}

		#endregion		

		#region Amazon Invoice to Quick Expense

		/// <summary>
		/// Converts an Amazon invoice to a quick expense object.
		/// </summary>
		static public QuickExpensePost ConvertAmazonInvoiceToQuickExpense(AmazonInvoice invoice)
		{			
			if (invoice == null)
			{
				throw new System.Exception("Could not create quick expense object. Invoice is null.");
			}

			QuickExpensePost qe = new QuickExpensePost("USD", Convert.ToDateTime(invoice.OrderDate), Convert.ToDecimal(invoice.OrderTotal));

			qe.Comment = GetCommentFromInvoice(invoice);
			qe.VendorDescription = invoice.Vendor;
			qe.ExpenseTypeCode = "OFCSP"; 

			return qe;
		}

		/// <summary>
		/// Creates the comment from the invoice. Comment will include order number, the items ordered,
		/// as well as the shipping information. Each portion of the comment will be seperated by a delimiter to
		/// access each piece of information
		/// </summary>
		/// <param name="invoice"></param>
		/// <returns></returns>
		private static string GetCommentFromInvoice(AmazonInvoice invoice)
		{
			//const int SHIPPING_LABEL = 0;
			const int SHIPPING_PRICE = 1;
			string localComment = invoice.OrderNumber;

			//Comment will include order number, items ordered, and shipping
			for (int i = 0; i < invoice.ListItemCollection.Count; i++)
			{
				string price = invoice.ListItemPriceCollection[i].InnerText;
				price = Regex.Replace(price, @"\t|\n|\r|\s+", "");
				localComment += "|" + invoice.ListItemCollection[i].InnerText + price;
			}

			//Add shipping information to comment
			localComment += "|" + "Shipping & Handling: " + invoice.ShippingPriceCollection[SHIPPING_PRICE].InnerText;

			return localComment;
		}

		#endregion		
	}
}

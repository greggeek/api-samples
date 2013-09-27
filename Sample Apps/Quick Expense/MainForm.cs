using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

using HttpRequestClient;
using ImageClient;
using QuickExpenseClient;

namespace QuickExpenseSample
{
	
	public partial class MainForm : Form
	{
		#region Global Variables
		
		private string ReceiptUrl;				
		private int TotalExpenses;
		private const string TokenFile = "token.txt";
		private string Token;

		#endregion

		/// <summary>
		/// Initializes all components and get the access token to be able to send requests
		/// </summary>
		public MainForm()
		{
			try
			{
				InitializeComponent();

				//Check to see if token already exists and that the token is valid
				Token = SetToken();
				
				LoadTreeView();
			}
			catch (Exception ex)
			{
				//Check to see if token is expired of invalid. If so, delete token and create new token
				if (ex.Message.Contains("403"))
				{
					//Delete current token, create new token, and load the list view with new token
					File.Delete(TokenFile);
					Token = SetToken();
					LoadTreeView();
					MessageBox.Show(ex.Message + "\n\nInvalid or expired token. Creating a new token.", "Invalid Token");
				}
				else
				{
					MessageBox.Show(ex.Message, "Error!");
				}      
			}           
		}

		/// <summary>
		/// Create a new quick expense.
		/// </summary>
		private void CreateQuickExpense(string invoiceFile)
		{
			Cursor.Current = Cursors.WaitCursor; //Show waiting pointer

			try
			{
				//Request the HTML of the invoice given
				HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
				htmlDoc.Load(invoiceFile);

				//Create invoice object
				AmazonInvoice amazonInvoice = new AmazonInvoice(htmlDoc);

				//Check for duplicate expenses - If there is a duplicate, quick expense will not be posted
				if (!CheckDuplicates(amazonInvoice)) 
				{
					//Convert the HTML invoice to a PDF
					string pdfFileName = "Amazon Invoice - " + amazonInvoice.OrderNumber + ".pdf";
					ConvertUtil.ConvertHtmlToPdf(htmlDoc, pdfFileName); //Generate PDF

					//Post image to the receipt store and return the receipt ID
					ReceiptImage receipt = ImageService.Post(Token, pdfFileName);

					//Convert Amazon invoice to quick expense object to be able to POST quick expense
					QuickExpensePost qe = ConvertUtil.ConvertAmazonInvoiceToQuickExpense(amazonInvoice);
					qe.ReceiptImageID = receipt.ID;

					//Post new quick expense and add it to the tree view
					QuickExpenseService.Post(Token, qe);

					AddTreeView(amazonInvoice);
				}
				else
				{
					MessageBox.Show("An expense has already been created for this Amazon order.", "Expense Already Created");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK ,MessageBoxIcon.Error);
			}		
		}

		#region Tree View Methods

		/// <summary>
		/// Load the tree view with expenses that have been created.
		/// </summary>
		private void LoadTreeView()
		{
			//Populate tree view with expenses
			List<QuickExpenseGet> list = QuickExpenseService.Get(Token);

			TotalExpenses = 0; //Counter for amazon expense node

			foreach (QuickExpenseGet qe in list)
			{
				TreeNode node = new TreeNode();

				//Capture the order number for the amazon invoice
				string[] commentList = qe.Comment.Split('|');
				node.Text = "Amazon Order #: " + commentList[0];
				node.ImageIndex = 0;
				TreeView.Nodes.Add(node);

				//Add items as child nodes for each amazon expense
				for (int i = 1; i < commentList.Length; i++)
				{
					TreeNode item = new TreeNode();
					item.Text = commentList[i];
					item.ImageIndex = 1;
					item.SelectedImageIndex = 1;
					TreeView.Nodes[TotalExpenses].Nodes.Add(item);
				}
				TotalExpenses++;
			}
			StatusLabel.Text = "Total Expenses: " + TotalExpenses;
		}

		/// <summary>
		/// Adds a newly created quick expense to the tree view.
		/// </summary>
		/// <param name="amazonInvoice"></param>
		private void AddTreeView(AmazonInvoice amazonInvoice)
		{
			//Iterate over all quick expenses to check for recently created
			List<QuickExpenseGet> list = QuickExpenseService.Get(Token);
			int expenseCount = 0; //Counter for the expense nodes
			foreach (QuickExpenseGet qe in list)
			{
				if (qe.Comment.Contains(amazonInvoice.OrderNumber))
				{
					//Create an expense node
					TreeNode node = new TreeNode();
					string[] commentList = qe.Comment.Split('|');
					node.Text = "Amazon Order #: " + commentList[0];
					node.ImageIndex = 0;
					TreeView.Nodes.Add(node);

					//Add items as child nodes for the newly added expense
					for (int i = 1; i < commentList.Length; i++)
					{
						TreeNode item = new TreeNode();
						item.Text = commentList[i];
						item.ImageIndex = 1;
						item.SelectedImageIndex = 1;
						TreeView.Nodes[expenseCount].Nodes.Add(item);
					}
				}
				else
				{
					expenseCount++;
				}
			}
			TotalExpenses++;
			StatusLabel.Text = "Amazon Expense Created - Total Expenses: " + TotalExpenses;
			CreatedLabel.Text = "Created Expense!";
		}

		/// <summary>
		/// Update the text fields with the expense that is selected.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor; //Show waiting pointer

			List<QuickExpenseGet> list = QuickExpenseService.Get(Token);

			TreeNode selectNode = TreeView.SelectedNode;
			string selected = TreeView.SelectedNode.Text.Substring(16);
			if (selectNode.Parent == null)
			{
				foreach (QuickExpenseGet qe in list)
				{
					//Populate the fields with information regarding the selected Amazon expense
					if (qe.Comment.Contains(selected))
					{
						DatePlace.Text = qe.TransactionDate.ToString("D");
						double price = Convert.ToDouble(qe.TransactionAmount);
						AmountPlace.Text = String.Format("{0:C}", price);
						string[] words = qe.Comment.Split('|');
						OrderNumberPlace.Text = words[0];
						string items = Convert.ToString(selectNode.Nodes.Count);
						ItemsPlace.Text = items;

						//Get image URL
						string receiptId = qe.ReceiptImageID;
						try
						{
							ReceiptImage receipt = ImageService.Get(Token, receiptId);
							ReceiptUrl = receipt.URI;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Unable to get receipt URL.");
						}
					}
				}
			}
		}

		#endregion		

		#region User Event Methods

		/// <summary>
		/// Browse for invoice and create a quick expense for it
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Browse for invoice file
			OpenFileDialog openFile = new OpenFileDialog();
	
			if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string invoiceFile = openFile.FileName;
				CreateQuickExpense(invoiceFile);
			}			
		}

		/// <summary>
		/// View the receipt when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ViewReceiptLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(ReceiptUrl);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Shows the about form when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm about = new AboutForm();
			about.Show();
		}

		/// <summary>
		/// Exits program when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion		

		#region Set Token Method
		
		/// <summary>
		/// Sets the token for the user
		/// </summary>
		/// <returns></returns>
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
	
		#region Private Methods

		/// <summary>
		/// Checks to see if there are duplicate expenses that have already been created.
		/// </summary>
		/// <param name="QuickExpenseUri"></param>
		/// <param name="tables"></param>
		/// <returns></returns>
		private bool CheckDuplicates(AmazonInvoice invoice)
		{
			//Iterate over all quick expenses to check if there are duplicates
			List<QuickExpenseGet> list = QuickExpenseService.Get(Token);
			foreach (QuickExpenseGet qe in list)
			{
				if (qe.Comment.Contains(invoice.OrderNumber))
				{
					return true;
				}
			}
			return false;
		}

		#endregion
	}
}

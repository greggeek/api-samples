using System;
using System.Xml;

namespace QuickExpenseClient 
{
	/// <summary>
	/// Quick expense object for GET.
	/// </summary>
	public class QuickExpenseGet
	{
		public string Comment { get; set; }
		public string CurrencyCode { get; set; }
		public string ExpenseTypeCode { get; set; }
		public string ExpenseTypeName { get; set; }
		public string ID { get; set; }
		public string LocationName { get; set; }
		public string OwnerLoginID { get; set; }
		public string OwnerName { get; set; }
		public string PaymentTypeCode { get; set; }		
		public string ReceiptImageID { get; set; }
		public Decimal TransactionAmount { get; set; }
		public DateTime TransactionDate { get; set; }
		public string URI { get; set; }	
		public string VendorDescription { get; set; }	
	}

	/// <summary>
	/// Quick expense object for POST.
	/// </summary>
	public class QuickExpensePost
	{
		public string Comment { get; set; }
		public string CurrencyCode { get; private set; }
		public string ExpenseTypeCode { get; set; }
		public string LocationCity { get; set; }
		public string LocationCountry { get; set; }
		public string LocationSubdivision { get; set; }
		public string PaymentTypeCode { get; set; }
		public string ReceiptImageID { get; set; }
		public string SpendCategoryCode { get; set; }
		public Decimal TransactionAmount { get; private set; }
		public DateTime TransactionDate { get; private set; }
		public string VendorDescription { get; set; }

		public QuickExpensePost(string currencyCode, DateTime transactionDate, Decimal transactionAmount)
		{
			this.CurrencyCode = currencyCode;
			this.TransactionAmount = transactionAmount;
			this.TransactionDate = transactionDate;
		}
	}

	/// <summary>
	/// Quick expense object for PUT.
	/// </summary>
	public class QuickExpensePut
	{
		public string Comment { get; set; }
		public string CurrencyCode { get; set; }
		public string ExpenseTypeCode { get; set; }
		public string LocationCity { get; set; }
		public string LocationCountry { get; set; }
		public string LocationSubdivision { get; set; }
		public string PaymentTypeCode { get; set; }
		public string ReceiptImageID { get; set; }
		public string SpendCategoryCode { get; set; }
		public Decimal? TransactionAmount { get; set; }
		public DateTime? TransactionDate { get; set; }
		public string VendorDescription { get; set; }		
	}
}

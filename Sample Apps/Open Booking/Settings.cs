using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;

using HttpRequestClient;

namespace WebPrototype
{
	/// <summary>
	/// This class will help us get credential information from app.config
	/// </summary>
	public class Settings : System.Web.UI.Page
	{
		/// <summary>
		/// Gets the access token for the specified user
		/// </summary>
		static public string GetToken(string code)
		{
			//Build uri
			UriBuilder uri = new UriBuilder(Settings.HostName);
			uri.Path = Settings.AccessTokenApiUrl;
			string accessTokenUrl = uri.ToString() + "?code=" + code + "&client_id=" + Settings.ConsumerKey + "&client_secret=" + Settings.ConsumerSecret;

			HttpWebResponse response = HttpClient.Get(accessTokenUrl);
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());
			string token = HttpClient.GetElementValue("Token", responseString);

			return token;
		}

		/// <summary>
		/// Gets the code passed from the OAuth web flow
		/// </summary>
		/// <returns></returns>
		static public string GetCode()
		{
			//Once user enters in credentials, capture the code that is passed back
			string url = HttpContext.Current.Request.Url.AbsoluteUri;
			Uri uri = new Uri(url);
			string code = HttpUtility.ParseQueryString(uri.Query).Get("code");

			return code;
		}

		/// <summary>
		/// Gets the user name from the token received
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		static public string GetUserName(string token)
		{
			//Build uri
			UriBuilder uri = new UriBuilder(Settings.HostName);
			uri.Path = Settings.UserApiUrl;
			string userUrl = uri.ToString();

			//Set headers
			Dictionary<string, string> headers = new Dictionary<string, string>();
			string oauth = String.Format("OAuth {0}", token);
			headers.Add("Authorization", oauth);

			HttpWebResponse response = HttpClient.Get(userUrl, headers);
			string responseString = HttpClient.GetStringFromStream(response.GetResponseStream());
			string name = HttpClient.GetElementValue("FirstName", responseString);

			return name;
		}

		/// <summary>
		/// Sets the token into a session
		/// </summary>
		public void SetToken()
		{
			//Once user enters in credentials, capture the code that is passed back
			string code = Settings.GetCode();

			//Set token session
			if (Session["Token"] == null && !String.IsNullOrEmpty(code))
			{
				Session["Token"] = Settings.GetToken(code);
				string token = (string)Session["Token"];

				//Get the user name for specified token
				Session["UserName"] = Settings.GetUserName(token);
			}
		}

		/// <summary>
		/// Gets the host name from web.config
		/// </summary>
		static public string HostName
		{
			get { return ("https://www.concursolutions.com"); }
		}

		/// <summary>
		/// Gets the consumer key from web.config
		/// </summary>
		static public string ConsumerKey
		{
			get { return ConfigurationManager.AppSettings["consumerKey"]; }
		}

		/// <summary>
		/// Gets the consumer secret from web.config
		/// </summary>
		static public string ConsumerSecret
		{
			get { return ConfigurationManager.AppSettings["consumerSecret"]; }
		}

		/// <summary>
		/// Gets the access token API from web.config
		/// </summary>
		static public string AccessTokenApiUrl
		{
			get { return "net2/oauth2/GetAccessToken.ashx"; }
		}

		/// <summary>
		/// Gets the booking API from web.confg
		/// </summary>
		static public string BookingApiUrl
		{
			get { return "api/travel/booking/v1.1/"; }
		}

		/// <summary>
		/// Gets the redirect URL for the OAuth web flow. Need to attach redirect URL after authorizing
		/// </summary>
		static public string OauthWebRedirect
		{
			get { return "https://www.concursolutions.com/net2/oauth2/Login.aspx?client_id=" + ConfigurationManager.AppSettings["consumerKey"] + "&scope=ITINER&scope=USER&redirect_uri=" + ConfigurationManager.AppSettings["OAuthWebRedirect"]; }
		}

		/// <summary>
		/// Gets the user API from web.confg
		/// </summary>
		static public string UserApiUrl
		{
			get { return "/api/user/v1.0/User"; }
		}
	}
}

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Air.aspx.cs" Inherits="WebPrototype.Air" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>	
	<link href="../style.css" rel="stylesheet" />
	<script src="../script.js"></script>
</head>
<body>

	<form id="airform" runat="server">
	<nav>
		<ul>
			<li><img class="logo" src="../Images/steve-air.png" /></li>
			<li class="links"><a href="Air.aspx">Air</a></li>
			<li class="links"><a href="../Hotel/Hotel.aspx">Hotel</a></li>
			<li class="links"><a href="../Car/Car.aspx">Car</a></li>
			<li class="links"><asp:Label ID="ConnectLabel" runat="server" Text="Connect to"></asp:Label><asp:ImageButton ID="ConnectButton" runat="server" Height="18px" ImageUrl="../Images/concur.png" onclick="ConnectButton_Click1"/></li>
		</ul>
	</nav>	

	<h4 class="credential"><asp:Label ID="CredentialLabel" runat="server" Text="" Visible="False"></asp:Label></h4>	

	<div class="form-container">
		<h2>Search Flights!</h2>		

		<p><asp:RadioButton ID="OneWayRadioButton" runat="server" />One-Way Flight</p>	

		<h3>Leaving From: </h3>
		<div class="inputs"><asp:DropDownList ID="FromDropDownList" runat="server" Width="150px">
			<asp:ListItem Value="ANC">Anchorage, AK - Ted Stevens Anchorage International Airport (ANC)</asp:ListItem>
			<asp:ListItem Value="HNL">Honolulu, Hawaii - Honolulu International Airport (HNL)</asp:ListItem>
			<asp:ListItem Value="LAX">Los Angeles, CA – Los Angeles International Airport (LAX)</asp:ListItem>
			<asp:ListItem Value="PDX">Portland, OR – Portland International Airport (PDX)</asp:ListItem>
			<asp:ListItem Value="SAN">San Diego, CA – San Diego International Airport (SAN)</asp:ListItem>
			<asp:ListItem Value="SFO">San Francisco, CA – San Francisco International Airport (SFO)</asp:ListItem>
			<asp:ListItem Value="SEA">Seattle, WA - Seattle Tacoma International Airport (SEA)</asp:ListItem>
			</asp:DropDownList></div>
		<div>
			<h3>Depart Date: </h3>
			<div class="inputs"><asp:TextBox ID="DepartTextBox" onclick="popupCalendar('departDateField')" runat="server" Width="150px"></asp:TextBox></div>		
			<div id="departDateField" style="display:none; position:absolute;">			
				<asp:Calendar ID="DepartCalendar" OnSelectionChanged="DepartCalendar_SelectionChanged" runat="server" BackColor="Silver" BorderColor="Black"></asp:Calendar>				
			</div>
		</div>	
				
		<h3>Going To: </h3>
		<div class="inputs"><asp:DropDownList ID="GoingDropDownList" runat="server" Width="150px">
			<asp:ListItem Value="ANC">Anchorage, AK - Ted Stevens Anchorage International Airport (ANC)</asp:ListItem>
			<asp:ListItem Value="HNL">Honolulu, Hawaii - Honolulu International Airport (HNL)</asp:ListItem>
			<asp:ListItem Value="LAX">Los Angeles, CA – Los Angeles International Airport (LAX)</asp:ListItem>
			<asp:ListItem Value="PDX">Portland, OR – Portland International Airport (PDX)</asp:ListItem>
			<asp:ListItem Value="SAN">San Diego, CA – San Diego International Airport (SAN)</asp:ListItem>
			<asp:ListItem Value="SFO">San Francisco, CA – San Francisco International Airport (SFO)</asp:ListItem>
			<asp:ListItem Value="SEA">Seattle, WA - Seattle Tacoma International Airport (SEA)</asp:ListItem>
			</asp:DropDownList></div>

		<div>
			<h3>Return Date: </h3>
			<div class="inputs"><asp:TextBox ID="ReturnTextBox" onclick="popupCalendar('returnDateField')" runat="server" Width="150px"></asp:TextBox></div>		
			<div id="returnDateField" style="display:none; position:absolute;">			
				<asp:Calendar ID="ReturnCalendar" OnSelectionChanged="ReturnCalendar_SelectionChanged" runat="server" BackColor="Silver" BorderColor="Black"></asp:Calendar>				
			</div>
		</div>

		<p><asp:Button ID="SearchFlightButton" runat="server" onclick="SearchFlightButton_Click" Text="Search For Flights"/></p>

		<h4 class="error"><asp:Label ID="ValidationLabel" runat="server" Text="" Visible="False"></asp:Label></h4>
	</div>

	<footer>
		<div class="footer-container">
			<h6>&copy; 2013. Concur, all rights reserved. Concur is a registered trademark of Concur Technologies Inc.</h6>
		</div>
	</footer>

	</form>
	
	

</body>
</html>

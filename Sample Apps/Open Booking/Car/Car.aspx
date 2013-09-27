<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="WebPrototype.Car" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link rel="stylesheet" type="text/css" href="../style.css"/>
	<script src="../script.js"></script>
</head>
<body>
	
	<form id="carform" runat="server">
		<nav>
			<ul>
				<li><img class="logo" src="../Images/ahmad-autos.png" /></li>
				<li class="links"><a href="../Air/Air.aspx">Air</a></li>
				<li class="links"><a href="../Hotel/Hotel.aspx">Hotel</a></li>
				<li class="links"><a href="Car.aspx">Car</a></li>
				<li class="links"><asp:Label ID="ConnectLabel" runat="server" Text="Connect to"></asp:Label><asp:ImageButton ID="ConnectButton" runat="server" Height="18px" ImageUrl="../Images/concur.png" OnClick="ConnectButton_Click"/></li>
			</ul>
		</nav>			

		<div class="form-container">
			<h2>Search Vehicles!</h2>

			<h3>Pick Up Location:</h3> 
			<div class="inputs">
				<asp:DropDownList ID="LocationDropDownList" runat="server" Width="150px">
				<asp:ListItem Value="ANC">Anchorage, AK - Ted Stevens Anchorage International Airport (ANC)</asp:ListItem>
				<asp:ListItem Value="HNL">Honolulu, Hawaii - Honolulu International Airport (HNL)</asp:ListItem>
				<asp:ListItem Value="LAX">Los Angeles, CA – Los Angeles International Airport (LAX)</asp:ListItem>
				<asp:ListItem Value="PDX">Portland, OR – Portland International Airport (PDX)</asp:ListItem>
				<asp:ListItem Value="SAN">San Diego, CA – San Diego International Airport (SAN)</asp:ListItem>
				<asp:ListItem Value="SFO">San Francisco, CA – San Francisco International Airport (SFO)</asp:ListItem>
				<asp:ListItem Value="SEA">Seattle, WA - Seattle Tacoma International Airport (SEA)</asp:ListItem>
				</asp:DropDownList>
			</div>
			<div>
				<h3>Pick Up Date:</h3>	
				<div class="inputs"><asp:TextBox ID="PickUpTextBox" onclick="popupCalendar('pickUpDateField')" runat="server" Width="150px"></asp:TextBox></div>
				<div id="pickUpDateField" style="display:none; position:absolute;">			
					<asp:Calendar ID="PickUpCalendar" OnSelectionChanged="PickUpCalendar_SelectionChanged" runat="server" BackColor="Silver" BorderColor="Black"></asp:Calendar>				
				</div>
			</div>
	
			<div>
				<h3>Return Date:</h3>
				<div class="inputs"><asp:TextBox ID="ReturnTextBox" onclick="popupCalendar('returnDateField')" runat="server" Width="150px"></asp:TextBox></div>
				<div id="returnDateField" style="display:none; position:absolute;">			
					<asp:Calendar ID="ReturnCalendar" OnSelectionChanged="ReturnCalendar_SelectionChanged" runat="server" BackColor="Silver" BorderColor="Black"></asp:Calendar>				
				</div>
			</div>
			<h3>Vehicle Type:</h3>
			<div class="inputs"><asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
				<asp:ListItem>Economy</asp:ListItem>
				<asp:ListItem>Compact</asp:ListItem>
				<asp:ListItem>SUV</asp:ListItem>
				<asp:ListItem>Luxury</asp:ListItem>
				<asp:ListItem>Truck</asp:ListItem>
				<asp:ListItem>Cargo Van</asp:ListItem>
				<asp:ListItem>Van</asp:ListItem>
				</asp:DropDownList></div>

			<p><asp:button ID="SearchButton" OnClick="SearchButton_Click" runat="server" text="Search For Cars" /></p>

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

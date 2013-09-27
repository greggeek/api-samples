<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel.aspx.cs" Inherits="WebPrototype.Hotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link rel="stylesheet" type="text/css" href="../style.css"/>
	<script src="../script.js"></script>
</head>
<body>	
	
	<form id="hotelform" runat="server">
		<nav>
			<ul>
				<li><img class="logo" src="../Images/ameer-suites.png" /></li>
				<li class="links"><a href="../Air/Air.aspx">Air</a></li>
				<li class="links"><a href="Hotel.aspx">Hotel</a></li>
				<li class="links"><a href="../Car/Car.aspx">Car</a></li>
				<li class="links"><asp:Label ID="ConnectLabel" runat="server" Text="Connect to"></asp:Label><asp:ImageButton ID="ConnectButton" runat="server" Height="18px" ImageUrl="../Images/concur.png" OnClick="ConnectButton_Click" /></li>
			</ul>
		</nav>
		<div class="form-container">
			<h2>Search Hotels!</h2>			

			<div>
				<h3>Check In Date:</h3>
				<div class="inputs"><asp:TextBox ID="CheckInTextBox" onclick="popupCalendar('checkInDateField')" runat="server" Width="150px"></asp:TextBox></div>		
				<div id="checkInDateField" style="display:none; position:absolute;">			
					<asp:Calendar ID="CheckInCalendar" OnSelectionChanged="CheckInCalendar_SelectionChanged" runat="server" BackColor="Silver" BorderColor="Black"></asp:Calendar>				
				</div>
			</div>
	
			<div>
				<h3>Check Out Date:</h3>
				<div class="inputs"><asp:TextBox ID="CheckOutTextBox" onclick="popupCalendar('checkOutDateField')" runat="server" Width="150px"></asp:TextBox></div>
				<div id="checkOutDateField" style="display:none; position:absolute;">			
					<asp:Calendar ID="CheckOutCalendar" OnSelectionChanged="CheckOutCalendar_SelectionChanged" runat="server" BackColor="Silver" BorderColor="Black"></asp:Calendar>				
				</div>
			</div>

			<h3>Number of Room(s):</h3>
			<div class="inputs">
				<asp:DropDownList ID="RoomDropDownList" runat="server" Width="150px">
					<asp:ListItem>1</asp:ListItem>
					<asp:ListItem>2</asp:ListItem>
					<asp:ListItem>3</asp:ListItem>
					<asp:ListItem>4</asp:ListItem>
					<asp:ListItem>5</asp:ListItem>
					<asp:ListItem>6</asp:ListItem>
					<asp:ListItem>7</asp:ListItem>
					<asp:ListItem>8</asp:ListItem>
					<asp:ListItem>9</asp:ListItem>
					<asp:ListItem>10</asp:ListItem>
				</asp:DropDownList>
			</div>
			
			<p><asp:Button ID="SearchHotelButton" runat="server" onclick="SearchHotelButton_Click" Text="Search Hotels!" /></p>

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

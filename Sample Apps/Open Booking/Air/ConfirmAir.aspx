<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmAir.aspx.cs" Inherits="WebPrototype.ConfirmAir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link rel="stylesheet" type="text/css" href="../style.css"/>
</head>
<body>
	<form id="form1" runat="server">
		<nav>
			<ul>
				<li><img class="logo" src="../Images/steve-air.png" /></li>
				<li class="links"><a href="Air.aspx">Air</a></li>
				<li class="links"><a href="../Hotel/Hotel.aspx">Hotel</a></li>
				<li class="links"><a href="../Car/Car.aspx">Car</a></li>
				<li class="links"><asp:Label ID="ConnectLabel" runat="server" Text="Connect to"></asp:Label><asp:ImageButton ID="ConnectButton" runat="server" Height="18px" ImageUrl="../Images/concur.png" OnClick="ConnectButton_Click" /></li>
			</ul>
		</nav>

		<div class="confirm-container">
			
			<h2>Confirm Flight</h2>

			<ul>
				<li>Flight Number: 
					<div class="inputs"><asp:Label ID="FlightLabel" runat="server"></asp:Label></div>
				</li>
				<li>Leaving From: 
					<div class="inputs"><asp:Label ID="FromLabel" runat="server"></asp:Label></div>
				</li>
				<li>Going To: 
					<div class="inputs"><asp:Label ID="ToLabel" runat="server"></asp:Label></div>
				</li>
				<li>Depart Date: 
					<div class="inputs"><asp:Label ID="DepartLabel" runat="server"></asp:Label></div>
				</li>
				<li>Return Date: 
					<div class="inputs"><asp:Label ID="ReturnLabel" runat="server"></asp:Label></div>
				</li>
				<asp:Button ID="SubmitButton" OnClick="SubmitButton_Click" runat="server" Text="Confirm" />

			</ul>

			<h4 class="error"><asp:Label ID="SuccessLabel" runat="server" Text="" Visible="False"></asp:Label></h4>
		</div>	

		<footer>
			<div class="footer-container">
				<h6>&copy; 2013. Concur, all rights reserved. Concur is a registered trademark of Concur Technologies Inc.</h6>
			</div>
		</footer>

	</form>
</body>
</html>

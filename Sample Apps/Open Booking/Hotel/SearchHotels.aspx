<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchHotels.aspx.cs" Inherits="WebPrototype.SearchHotels" %>

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
				<li><img class="logo" src="../Images/ameer-suites.png" /></li>
				<li class="links"><a href="../Air/Air.aspx">Air</a></li>
				<li class="links"><a href="Hotel.aspx">Hotel</a></li>
				<li class="links"><a href="../Car/Car.aspx">Car</a></li>
				<li class="links"><asp:Label ID="ConnectLabel" runat="server" Text="Connect to"></asp:Label><asp:ImageButton ID="ConnectButton" runat="server" Height="18px" ImageUrl="../Images/concur.png" OnClick="ConnectButton_Click" /></li>
			</ul>
		</nav>

		<div class="hotels">
			<div class="hotel-container">
				<div class="hotel-img">
					<h2 class="hotel-price">$129.99</h2>
					<img src="../Images/hotel1.jpg" />
				</div>
				<div class="hotel-address">
					<h4>Ameer Suites</h4>
					<h5>1234 W Century Boulevard</h5>
					<h5>Inglewood,  CA,  90304</h5>
					<h5>Phone: 123-456-7891</h5>
				</div>				
				<div class="hotel-button">
					<asp:Button ID="SelectButton1" OnClick="SelectButton1_Click" runat="server" Text="Select" />
				</div>
			</div>
		</div>

		<div class="hotels">
			<div class="hotel-container">
				<div class="hotel-img">
					<h2 class="hotel-price">$79.99</h2>
					<img src="../Images/hotel2.jpg" />
				</div>
				<div class="hotel-address">
					<h4>Hotel Paulo</h4>
					<h5>1717 4th Street</h5>
					<h5>Santa Monica, CA 90401 </h5>
					<h5>Phone: 123-456-7891</h5>
				</div>
				<div class="hotel-button">
				<asp:Button ID="SelectButton2" OnClick="SelectButton2_Click" runat="server" Text="Select" />
				</div>
			</div>
		</div>

		<div class="hotels">
			<div class="hotel-container">
				<div class="hotel-img">
				<h2 class="hotel-price">$149.99</h2>
					<img src="../Images/hotel3.jpg" />
				</div>
				<div class="hotel-address">
					<h4>Dan Inn</h4>
					<h5>987 Sample Boulevard</h5>
					<h5>Los Angeles,  CA,  90069</h5>
					<h5>Phone: 123-456-7891</h5>
				</div>
				<div class="hotel-button">
					<asp:Button ID="SelectButton3" OnClick="SelectButton3_Click" runat="server" Text="Select" />
				</div>
			</div>
		</div>

		<footer>
			<div class="footer-container">
				<h6>&copy; 2013. Concur, all rights reserved. Concur is a registered trademark of Concur Technologies Inc.</h6>
			</div>
		</footer>

	</form>
</body>
</html>

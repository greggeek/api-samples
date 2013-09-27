<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCars.aspx.cs" Inherits="WebPrototype.SearchCars" %>

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
				<li><img class="logo" src="../Images/ahmad-autos.png" /></li>
				<li class="links"><a href="../Air/Air.aspx">Air</a></li>
				<li class="links"><a href="../Hotel/Hotel.aspx">Hotel</a></li>
				<li class="links"><a href="Car.aspx">Car</a></li>
				<li class="links"><asp:Label ID="ConnectLabel" runat="server" Text="Connect to"></asp:Label><asp:ImageButton ID="ConnectButton" runat="server" Height="18px" ImageUrl="../Images/concur.png" OnClick="ConnectButton_Click"/></li>
			</ul>
		</nav>	

		<div class="cars">
			<div class="car-container">
				<div class="car-image-container">					
					<img src="../Images/car.png" />
				</div>
				<div class="car-info">
					<h3>$79.99</h3>
					<h5>Economy</h5>
					<h5>2010 Toyota Corolla</h5>
				</div>
				<div class="car-button">
					<asp:Button ID="SelectButton1" OnClick="SelectButton1_Click" runat="server" Text="Select" />
				</div>
			</div>		
		</div>

		<div class="cars">
			<div class="car-container">
				<div class="car-image-container">
					<img src="../Images/truck.jpg" />
				</div>
				<div class="car-info">
					<h3>$149.99</h3>
					<h5>Truck</h5>
					<h5>2010 Ford F-150</h5>
				</div>
				<div class="car-button">
					<asp:Button ID="SelectButton2" OnClick="SelectButton2_Click" runat="server" Text="Select" />
				</div>
			</div>
		</div>

		<div class="cars">
			<div class="car-container">
				<div class="car-image-container">
					<img src="../Images/cargo.jpg" />
				</div>
				<div class="car-info">
					<h3>$139.99</h3>
					<h5>Cargo Van</h5>
					<h5>2010 Ford Econoline</h5>					
				</div>
				<div class="car-button">
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAir.aspx.cs" Inherits="WebPrototype.Flights" %>

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
				<li class="links"><asp:Label ID="ConnectLabel" runat="server" Text="Connect to"></asp:Label><asp:ImageButton ID="ConnectButton" runat="server" Height="18px" ImageUrl="../Images/concur.png" OnClick="ConnectButton_Click"/></li>
			</ul>
		</nav>

		<div class="flights">
			<div class="from">
				<div>
					<h3>From</h3>
					<h5><asp:Label ID="DepartTimeLabel1" runat="server" Text="August 23rd, 2013 12:20PM"></asp:Label></h5>
					<h4><asp:Label ID="LeavingFromLabel1" runat="server"></asp:Label></h4>
				</div>			
			</div>
			<div class="plane">
				<h3 class="flight-number"><asp:Label ID="FlightLabel1" runat="server" Text="Flight 339"></asp:Label></h3>
				<img class="plane-img" src="../Images/plane.png" />				
			</div>			
			<div class="to">
				<div>
					<h3>To</h3>
					<h5><asp:Label ID="ArriveTimeLabel1" runat="server" Text="August 23rd, 2013 02:49PM"></asp:Label></h5>
					<h4><asp:Label ID="GoingToLabel1" runat="server"></asp:Label></h4>
				</div>
			</div>			
			<div class="select-button"><asp:Button ID="SelectButton1" OnClick="SelectButton1_Click" runat="server" Text="Select" /></div>
		</div>

		<div class="flights">
			<div class="from">
				<div>
					<h3>From</h3>
					<h5><asp:Label ID="DepartTimeLabel2" runat="server" Text="August 23rd, 2013 02:20PM"></asp:Label></h5>
					<h4><asp:Label ID="LeavingFromLabel2" runat="server" Text=""></asp:Label></h4>
				</div>			
			</div>

			<div class="plane">
				<h3><asp:Label ID="FlightLabel2" runat="server" Text="Flight 419"></asp:Label></h3>
				<img class="plane-img" src="../Images/plane.png" />				
			</div>

			<div class="to">
				<div>
					<h3>To</h3>
					<h5><asp:Label ID="ArriveTimeLabel2" runat="server" Text="August 23rd, 2013 03:59PM"></asp:Label></h5>
					<h4><asp:Label ID="GoingToLabel2" runat="server" Text=""></asp:Label></h4>
				</div>
			</div>			
			<div class="select-button"><asp:Button ID="SelectButton2" OnClick="SelectButton2_Click" runat="server" Text="Select" /></div>
		</div>
	</form>

	<footer>
		<div class="footer-container">
			<h6>&copy; 2013. Concur, all rights reserved. Concur is a registered trademark of Concur Technologies Inc.</h6>
		</div>
	</footer>

</body>
</html>

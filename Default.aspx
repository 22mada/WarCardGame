<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WarMegaChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <h1 class="auto-style1">&nbsp;<asp:Image ID="Image2" runat="server" Height="108px" ImageUrl="~/cards.png" Width="86px" />
            War<br />
        </h1>
        <div class="auto-style1">
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Play " />
        <br />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
    
        </div>
    
    </div>
    </form>
</body>
</html>

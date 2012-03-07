<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comeformaspx.aspx.cs" Inherits="WebApplication2.Comeformaspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <asp:TextBox ID="LoginText" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="PasswordText" runat="server"></asp:TextBox>
        <br />
        
        <asp:Button ID="ComeButton" runat="server" onclick="ComeButton_Click" Text="Войти" 
            Width="124px" />
        
        <br />
        
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>

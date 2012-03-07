<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regform.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 220px;
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
        <br />
        
        <asp:Button ID="RegButton" runat="server" onclick="Button1_Click" Text="Зарегистрироваться" 
            Width="124px" />
        
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        
    </div>
    </form>
</body>
</html>

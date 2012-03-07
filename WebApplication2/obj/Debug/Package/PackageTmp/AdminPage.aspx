<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebApplication2.AdminPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Администраторы<br>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        Добавить нового администратора
        <br />
        логин&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        пароль<br />
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="+" 
            Width="38px" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
    <div>
        Пользователи<br>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames = "login" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
                <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [id], [login], [pass], [status] FROM [netusers]"
            UpdateCommand="UPDATE netusers SET status = @status WHERE login = @login AND  ( @status Like 'Open' or @status Like 'Locked')" >
            <UpdateParameters>
               <asp:Parameter Name="status" Type ="String"/>
               <asp:Parameter Name="login" Type ="String"/>       
            </UpdateParameters>
        </asp:SqlDataSource>

       

        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Выход" 
            Width="157px" />
    </div>
    
    </form>
</body>
</html>

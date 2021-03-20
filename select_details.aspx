<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select_details.aspx.cs" Inherits="Crud_Application_Using_Ajax_GridView.select_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            select School Name:<asp:DropDownList ID="DropDownList" runat="server">
                <asp:ListItem Value="0">--Select School</asp:ListItem>
                <asp:ListItem>Public School & College</asp:ListItem>
                <asp:ListItem>Jnanankur School & College</asp:ListItem>
                <asp:ListItem>Moneria School & College</asp:ListItem>
                               </asp:DropDownList>

            <p>
                
                <asp:Button  ID="but1" runat="server" Text="Insert Record"/>
            </p>
            <asp:Literal ID="lit1" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>

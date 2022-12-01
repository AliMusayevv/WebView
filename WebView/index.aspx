<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebView.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> WebView</title>
    <link href="Css/style.css" rel="stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
        <div class="textbox">
            <asp:Label ID="Label1" runat="server" Text="Category Name:" class="LblCatName"></asp:Label><asp:TextBox ID="TxtSearch" runat="server" class="TxtSearch" OnTextChanged="TxtSearch_TextChanged"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BtnSearch" runat="server" class="button"  Text="Search" OnClick="BtnSearch_Click" />

        </div>
         <div>
            <asp:Label ID="LblResult" runat="server" Text="" class="LblResult"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GrdResult" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="GrdResult_PageIndexChanging" PageSize="6">
            </asp:GridView>
        </div>
        
    </form>
</body>
</html>

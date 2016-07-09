<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leTest.aspx.cs" Inherits="Le_Banc.leTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:PlaceHolder ID="PlaceHolderQuestions" runat="server">


        </asp:PlaceHolder>

        <asp:Button ID="ButtonLamnaIn" runat="server" Text="Lämna in" OnClick="ButtonLamnaIn_Click" />
    </div>
    </form>
</body>
</html>

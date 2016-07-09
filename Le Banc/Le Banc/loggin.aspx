<%@ Page Title="" Language="C#" MasterPageFile="~/LeBanc.Master" AutoEventWireup="true" CodeBehind="loggin.aspx.cs" Inherits="Le_Banc.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/CSS/index.css" />
     <link rel="stylesheet" type="text/css" href="/CSS/responsiv.css" media="screen and (max-width: 900px)" />
     <style type="text/css">
         #Reset1 {
             width: 92px;
         }
         #btnRensa {
             width: 160px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="logginSida">
        
    <asp:Label ID="lblInfo" runat="server" Text="
    &lt;h2&gt;Logga in&lt;/h2&gt;
    För att logga in vänligen ange ditt användarnamn samt lösenord.
    " ForeColor="#FF6600"></asp:Label>
    <br/>
    <br/> 
    <asp:Label ID="lblId" runat="server" Text="Användarnamn" ForeColor="#666666"></asp:Label>  
        <br/>
    <asp:TextBox ID="txbId" runat="server" Text="" ForeColor="#999999"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vänligen ange användarnamn" ForeColor="Silver" ControlToValidate="txbId"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Silver" ControlToValidate="txbId" ErrorMessage="Vänligen ange en korrekt emailadress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <br/>
    <asp:Label ID="lblPassword" runat="server" Text="Lösenord" ForeColor="#666666"></asp:Label>
        <br/>
    <asp:TextBox ID="txbPassword" runat="server" Text="Lösenord" ForeColor="#999999" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vänligen ange lösenord" ForeColor="Silver" ControlToValidate="txbPassword"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Button ID="btnLoggin" runat="server" Text="Logga in" OnClick="btnLoggin_Click" ForeColor="#FF6600" Width="162px" Height="27px" />
    <br/>
    <br/>
        <input id="btnRensa" type="reset" value="Rensa"/><br/>
    </section>
</asp:Content>

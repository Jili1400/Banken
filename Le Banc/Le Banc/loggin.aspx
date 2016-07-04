<%@ Page Title="" Language="C#" MasterPageFile="~/LeBanc.Master" AutoEventWireup="true" CodeBehind="loggin.aspx.cs" Inherits="Le_Banc.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/CSS/index.css" />
     <link rel="stylesheet" type="text/css" href="/CSS/responsiv.css" media="screen and (max-width: 900px)" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="logginSida">
    <asp:Label ID="lblInfo" runat="server" Text="Logga in">
    <h2>Logga in</h2>
    För att logga in vänligen ange ditt användarnamn samt lösenord.
    </asp:Label>
    <br/>
    <br/>   
    <asp:TextBox ID="txbId" runat="server" Text="Användarnamn"></asp:TextBox>
    <br/>
    <br/>
    <asp:TextBox ID="txbPassword" runat="server" Text="Lösenord"></asp:TextBox>
    <br/>
    <br/>
    <asp:Button ID="btnLoggin" runat="server" Text="Logga in" OnClick="btnLoggin_Click" />
    <br/>
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    <br/>
    <br/>
    </section>
</asp:Content>

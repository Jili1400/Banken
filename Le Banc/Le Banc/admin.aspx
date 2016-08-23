<%@ Page Title="" Language="C#" MasterPageFile="~/LeBanc.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Le_Banc.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/index.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/responsiv.css" media="screen and (max-width: 900px)" />
      <style type="text/css">
        #Select1 {
            width: 177px;
        }
    </style>
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbSearch").autocomplete({
                source: personnel,
                focus: function (event, ui) {
                    $("#ContentPlaceHolder1_tbSearch").val(ui.item.label);
                    return false;
                },
                select: function (event, ui) {
                    $("#ContentPlaceHolder1_txbSearch").val(ui.item.label);
                    $("#ContentPlaceHolder1_hfSearchPersonnel").val(ui.item.value);
                    __doPostBack();
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="adminsida">
    <br/>
        <asp:Label ID="lblSearchPersonnel" runat="server" Text="Sök medarbetare" Font-Bold="True" Font-Size="Medium" ForeColor="#FF6600"></asp:Label>
    <br/>
        <asp:TextBox ID="txbSearchPersonnel" runat="server"></asp:TextBox>
        <asp:HiddenField ID="hfSearchPersonnel" runat="server" OnValueChanged="hfSearchPersonnel_ValueChanged" />
        <br />
            <br />
            <script>
                function ListBoxFilter() {
                    var input = $("#ContentPlaceHolder1_txbSearchPersonnel").val();
                    var regex = new RegExp(input, "i");
                    var antalPoster = $("#ContentPlaceHolder1_lblPersonnel").children().length;
                    for (i = 0; i < antalPoster; i++) {
                        var namn = $("#ContentPlaceHolder1_lblPersonnel").children()[i].innerHTML;
                        if (!namn.match(regex)) {
                            $("#ContentPlaceHolder1_lblPersonnel option:eq(" + i + ")").hide();
                        }
                        else {
                            $("#ContentPlaceHolder1_lblPersonnel option:eq(" + i + ")").show();
                        }
                    }
                }
            </script>
    <br/>
    <br/>    
        <asp:Label ID="lblPersonal" runat="server" Text="Välj medarbetare nedan" Font-Bold="True" Font-Size="Medium" ForeColor="#FF6600"></asp:Label>
    <br/>
        <asp:DropDownList ID="ddlPersonal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonal_SelectedIndexChanged">
        </asp:DropDownList>
    <br/>
    <br/>
        <asp:GridView ID="grvPersonal" runat="server" AutoGenerateColumns="false">
            <Columns>
                    <asp:BoundField DataField="licenstest" HeaderText="Licenstest" />
                    <asp:BoundField DataField="aku" HeaderText="ÅKU" />
                    <asp:BoundField DataField="date" HeaderText="Datum" />
                    <asp:BoundField DataField="result" HeaderText="Resultat" />
                    <asp:BoundField DataField="pass" HeaderText="Godkänd" />                
            </Columns>
        </asp:GridView>
    <br/>
    <br/>

</section>
    
    

</asp:Content>

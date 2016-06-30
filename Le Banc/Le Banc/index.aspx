<%@ Page Title="" Language="C#" MasterPageFile="~/LeBanc.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Le_Banc.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/index.css" />
            <link rel="stylesheet" type="text/css" href="/CSS/responsiv.css" media="screen and (max-width: 900px)" />
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
<div class="body">
     <div class="sektioner clearfix">

          <div class="sektion sektion-ett mobil">
             <img src="/Images/MelkerochEbbabadar.jpg" alt="2 barn badar" width="100%" height="auto" /> 
              <h2>Om Le Banc Fiffle</h2>
                   <p>
                   Le Banc Fiffle är Skandinaviens största bankkoncern. 
                   <br />Vi förvaltar 10,7 miljoner kunders privata tillgångar och 
                   <br />är finansiell rådgivare till 455 000 företag.  
                   <br />Vi finns i alla länder i Skandinavien. Vi är 22 356 anställda 
                   <br />fördelat på 7 200 anställda i Norge, 9875 i Sverige och 5281 i Danmark.  
                   
                   </p>
           </div>


           <div class="sektion sektion-andra mobil">
             <img src="/Images/EbbaochMelkerakernorg.jpg" alt="Ebba och Melker på åkern" width="100%" height="auto" />
               <h2>Vi ger tillbaka till naturen</h2>
                   <p>
                   Le Banc Fiffle är en stor bank som naturligtvis vill ge tillbaka  
                   <br />till vår moder natur. Vi skänker årligen mer än 10% av  
                   <br /> vår vinst till energifrämjande projekt. 
                   <br />
                   <br />  
                   </p>
             </div>


            <div class="sektion sektion-tre mobil">
             <img src="/Images/Ebbaiappletree.jpg" alt="en bild på en hund" width="100%" height="auto" />
               <h2>Spara för framtiden</h2>
                   <p title="Spara för framtiden">
                   På Le Banc Fiffle tänker vi på sparandet för den kommande generationen.<br />
                   Vi har därför satt samman olika sparpaket för att göra det enkelt och säkert att spara till våra guldklimpar.
                   </p>
             </div>

        </div>
     
     <div class="aside clear">
     
       <%-- <div class="aside aside-1">
        <h2>Aktuella boräntor</h2>
        <p title="Aktuella Boräntor">
        <li>Rörlig 0,75%</li>
        <li>3 mån  0,92%</li>
        <li>5 mån  0,99%</li>
        <li>1 år   1,15%</li>
        <li>3 år   1,75%</li>
        <li>5 år   2,10%</li>
        </p>

        </div>--%>
     </div>
   </div>
</asp:Content>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.Security;

namespace Le_Banc
{
    public partial class LeBanc : System.Web.UI.MasterPage
    {
        public personnel s_newPersonnel = new personnel(); //instans av klass som för session genomgående - satt session till 40 min. 
        int s_Access; //hur kollar jag om de har access??

        protected void Page_Load(object sender, EventArgs e)
        {
            s_newPersonnel.idPersonnel = Convert.ToInt32(Session["idPersonnel"]); // kan inte kolla vad vi kallar den i databasen ev. måste detta ändras
            int s_access = Convert.ToInt32(Session["access"]); //får köra access i databas för istället för staff true/false

            if (s_access > 0)
            {
                loggin.Visible = false;
                loggout.Visible = true;
            }
            else
            {
                loggin.Visible = true;
                loggout.Visible = false;
            }

            if (!IsPostBack)
            {
                s_newPersonnel.idPersonnel = Convert.ToInt32(Session["idPersonnel"]); // kan inte kolla vad vi kallar den i databasen ev. måste detta ändras
                s_Access = Convert.ToInt32(Session["access"]); // check av access visar knappar efter det. Måste lägga till access i databas!!


            }
        } 
        
   

        protected void loggin_Click(object sender, EventArgs e)
        {
            loggin.Visible = false;
            loggout.Visible = true;
            FormsAuthentication.RedirectFromLoginPage(s_Access.ToString(), false);
            Response.Redirect("loggin.aspx");
        }

        protected void loggout_Click(object sender, EventArgs e)
        {
            loggin.Visible = true;
            loggout.Visible = false;
            FormsAuthentication.SignOut();
            Session.Abandon();
            FormsAuthentication.RedirectFromLoginPage(s_Access.ToString(), false);
            Response.Redirect("index.aspx");
        }
    }
}
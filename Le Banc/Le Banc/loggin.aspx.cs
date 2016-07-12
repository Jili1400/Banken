using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;

namespace Le_Banc
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoggin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string userPassword = txbPassword.Text;
            //if (methods.checkUserExist(userName, userPassword) == true)
            //{
            //    User newUser = new User();

            //    // get all user info by name and password
            //    newUser = methods.getUserByName(userName, userPassword);
            //    Session["id_users"] = newUser.userID;

            //    if (staff == false)
            //    {
            //        FormsAuthentication.RedirectFromLoginPage(accessId.ToString(), false);
            //        Response.Redirect("personal.aspx");
            //    }
            //    else if (staff == true)
            //    {
            //        FormsAuthentication.RedirectFromLoginPage(accessId.ToString(), false);
            //        Response.Redirect("admin.aspx");
            //    }
            //    else
            //    {
            //        lblErrorMessage.Text = "Användare saknar behörighet";
            //    }
            //}
            //else
            //{
            //    lblErrorMessage.Text = "Fel användarnamn eller lösenord. Försök igen.";
            //}
            
            
            //Session["Id"] = //Id från inloggad från databasen
            ////om staff bool redirect till admin else till komp.port
            //if ()
            //{
            //  Response.Redirect("~/admin.aspx");
            //}
            //else
            //{
            //  Response.Redirect("~/kompetensportalen.aspx");
            //}


        }
    }
}
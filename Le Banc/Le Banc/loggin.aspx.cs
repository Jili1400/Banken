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
            if (!IsPostBack)
            {
                List<personnel> personnelList = new List<personnel>();
                personnelList = methods.getPersonnelList();
            }

        }

        protected void btnLoggin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string userPassword = txbPassword.Text;
            int idPersonnel = Convert.ToInt32(Session["idPersonnel"]);

            if (methods.checkPersonnelExist(idPersonnel, userName, userPassword) == true)
            {
                personnel newPersonnel = new personnel();

                // get all user info by name and password
                //newPersonnel = methods.getPersonnelByName(userName, userPassword);

                Session["idPersonnel"] = newPersonnel.idPersonnel;

                if (newPersonnel.access == 1)
                {
                    //FormsAuthentication.RedirectFromLoginPage(access.ToString(), false);
                    Response.Redirect("personal.aspx");
                }
                else if (newPersonnel.access == 2)
                {
                    //FormsAuthentication.RedirectFromLoginPage(accessId.ToString(), false);
                    Response.Redirect("admin.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "Användare saknar behörighet";
                }
            }
            else
            {
                lblErrorMessage.Text = "Fel användarnamn eller lösenord. Försök igen.";
            }
            
            
            //Session["Id"] = //Id från inloggad från databasen
            ////om staff bool redirect till admin else till komp.port
            //if ()
            //{
            //  Response.Redirect("~/admin.aspx");
            //}
            //else
            //{
            //  Response.Redirect("~/kompetensportalen.aspx");
            }
    }
            
}
        
    

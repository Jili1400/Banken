using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Le_Banc
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoggin_Click(object sender, EventArgs e)
        {
            if (txbId.Text == string.Empty)
            {
                lblErrorMessage.Text = "Du måste ange Användarnamn";
                return;
            }
            if (txbPassword.Text == string.Empty)
            {
                lblErrorMessage.Text = "Du måste ange Lösenord";
                return;
            }
        }
    }
}
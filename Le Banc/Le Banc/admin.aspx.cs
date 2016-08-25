using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Le_Banc
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
             {

                 List<personnel> personnelList = new List<personnel>();
                 personnelList = methods.getPersonnelList();
                 //string namn = "firstName" + " " + "lastName";

                 ddlPersonal.DataValueField = "idPersonnel";
                 ddlPersonal.DataTextField = "firstName";
                 ddlPersonal.DataSource = personnelList;
                 ddlPersonal.DataBind();

                 int idPersonnel = Convert.ToInt32(ddlPersonal.SelectedValue); 
                                  
             }
        
        }

        protected void ddlPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPersonnel = Convert.ToInt32(ddlPersonal.SelectedValue);
            DataTable dt = methods.getResultsForPersonnel(Convert.ToInt32(idPersonnel));
            grvPersonal.DataSource = dt;
            grvPersonal.DataBind();



        }


        protected void hfSearchPersonnel_ValueChanged(object sender, EventArgs e)
        {
            HiddenField hf = (HiddenField)sender;
            int idPersonnel = Convert.ToInt32(hf.Value);
            DataTable dt = methods.getResultsForPersonnel(idPersonnel);
            grvPersonal.DataSource = dt;
            grvPersonal.DataBind();

        }
    }
}
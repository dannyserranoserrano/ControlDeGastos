using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlDeGastos
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && this.Page.User.Identity.IsAuthenticated)
            {
                lblWelcome.Text = Page.User.Identity.Name;
                btnLogIn.Visible = false;
                btnSignUp.Visible = false;
                btnLogout.Visible = true;
            }
            else if (!IsPostBack && !this.Page.User.Identity.IsAuthenticated)

            {
                lblWelcome.Text = "Usuario. No estás logueado";
                btnLogIn.Visible = true;
                btnSignUp.Visible = true;
                btnLogout.Visible = false;
            }

        }
        protected void btnGoToSignUp_Click(object sender, EventArgs e)
        {
            // Redirecciona a Login
            Response.Redirect("/Auth/SignUp.aspx");
        }

        protected void btnGoToLoginUp_Click(object sender, EventArgs e)
        {
            // Redirecciona a Login
            Response.Redirect("/Auth/Login.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Auth/Login.aspx");
        }
    }
}
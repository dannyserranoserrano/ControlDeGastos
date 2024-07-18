using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;
using System.Web.Security;

namespace ControlDeGastos
{
    public partial class buttons : Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FinanceDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

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
            Response.Redirect("Login.aspx");
        }
    }
}
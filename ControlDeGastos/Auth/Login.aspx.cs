using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;


namespace ControlDeGastos
{
    public partial class Login : Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FinanceDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password", con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        FormsAuthentication.RedirectFromLoginPage(username, false);
                    }
                    else
                    {
                        lblErrorMessage.Text = "Usuario o contraseña incorrectos.";
                        lblErrorMessage.Visible = true;
                    }
                }

            }
        }
        protected void btnGoToSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Auth/SignUp.aspx");
        }

    }
}
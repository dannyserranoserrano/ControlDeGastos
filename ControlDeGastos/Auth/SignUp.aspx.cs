using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlDeGastos
{
    public partial class SignUp : Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FinanceDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Verificar si el usuario ya existe

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username", con))
                {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        con.Open();
                        int userCount = (int)checkCmd.ExecuteScalar();
                        con.Close();

                        if (userCount > 0)
                        {
                            // El usuario ya existe, mostrar mensaje de error
                            lblErrorMessage.Text = "El nombre de usuario ya existe. Por favor, elige otro.";
                            lblErrorMessage.Visible = true;
                            return;
                        }
                }
            }


            // Insertar nuevo usuario si no existe
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @Password)", con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            // Marcar al usuario como logueado y guardar el nombre de usuario en la sesión
            Session["IsLoggedIn"] = true;
            Session["Username"] = username;

            // Redirecciona a Login
            Response.Redirect("/Auth/Login.aspx");
        }
    }
}
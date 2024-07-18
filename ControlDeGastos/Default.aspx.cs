using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;

namespace ControlDeGastos
{
    public partial class _Default : Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FinanceDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                LoadExpenses();
                LoadMonthlyExpensesSummary();
            }
        }

        protected void LoadExpenses()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Expenses", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd)) 
                    { 
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridViewExpenses.DataSource = dt;
                        GridViewExpenses.DataBind();
                    }         
                }
            }
        }

        protected void LoadMonthlyExpensesSummary()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT FORMAT(Date, 'MM-yyyy') AS Month, SUM(Amount) AS TotalAmount FROM Expenses GROUP BY FORMAT(Date, 'MM-yyyy') ORDER BY Month", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridViewMonthlySummary.DataSource = dt;
                            GridViewMonthlySummary.DataBind();
                        }

                    }

                }

            }
        }

        protected void btnAddExpense_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            try
            {
                string description = txtDescription.Text;
                decimal amount = Convert.ToDecimal(txtAmount.Text);
                DateTime date = Convert.ToDateTime(txtDate.Text);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Expenses (Description, Amount, Date) VALUES (@Description, @Amount, @Date)", con))
                    {
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Date", date);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }               
                }
            }
            catch
            {
                lblErrorMessage.Text = "Datos mal introducidos";
                lblErrorMessage.Visible = true;
            }
            

            

            // Limpiar los campos
            txtDescription.Text = "";
            txtAmount.Text = "";
            txtDate.Text = "";

            // Recargar la Tabla
            LoadExpenses();
            LoadMonthlyExpensesSummary();
        }

        protected void GridViewExpenses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewExpenses.EditIndex = e.NewEditIndex;
            LoadExpenses();
            LoadMonthlyExpensesSummary();
        }
        protected void GridViewExpenses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewExpenses.EditIndex = -1;
            LoadExpenses();
            LoadMonthlyExpensesSummary();
        }
        protected void GridViewExpenses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblErrorMessage.Visible = false;
            try
            {
                int expenseId = Convert.ToInt32(GridViewExpenses.DataKeys[e.RowIndex].Value.ToString());
                string description = ((TextBox)GridViewExpenses.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                decimal amount = Convert.ToDecimal(((TextBox)GridViewExpenses.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
                DateTime date = Convert.ToDateTime(((TextBox)GridViewExpenses.Rows[e.RowIndex].Cells[3].Controls[0]).Text);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Expenses SET Description=@Description, Amount=@Amount, Date=@Date WHERE ExpenseId=@ExpenseId", con))
                    {
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@ExpenseId", expenseId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                GridViewExpenses.EditIndex = -1;
                LoadExpenses();
                LoadMonthlyExpensesSummary();
            }
            catch
            {
                lblErrorMessage.Text = "Datos mal introducidos";
                lblErrorMessage.Visible = true;
            }
        }
        protected void GridViewExpenses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int expenseId = Convert.ToInt32(GridViewExpenses.DataKeys[e.RowIndex].Value.ToString());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Expenses WHERE ExpenseId=@ExpenseId", con))
                {
                    cmd.Parameters.AddWithValue("@ExpenseId", expenseId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadExpenses();
            LoadMonthlyExpensesSummary();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Expenses", con))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);   
                    
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        object p = wb.Worksheets.Add(dt, "Gastos");

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=Gastos.xlsx");

                        using (System.IO.MemoryStream memoryStream = new MemoryStream())
                        {
                            wb.SaveAs(memoryStream);
                            memoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }
    }
}
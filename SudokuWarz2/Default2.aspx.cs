using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudokuWarz2
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblusername.Text = (String)Session["mySessionVar"];
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Refreshed at " + DateTime.Now.ToLongTimeString();
            GridView1.DataSourceID = "SqlDataSource1";
            DataList1.DataSourceID = "SqlDataSource2";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("INSERT INTO [Chat] ([name], [text]) VALUES ('" + lblusername.Text + "', @chatMessage)", conn);
                da3.SelectCommand.Parameters.AddWithValue("@chatMessage", TextBox3.Text);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
            GridView1.DataSourceID = "SqlDataSource1";
            TextBox3.Text = "";
            TextBox3.Focus();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
            Session.Remove("mySessionVar");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("UPDATE Users SET [seat] = 1, WHERE ([name] = " + (String)Session["mySessionVar"] + ")", conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("UPDATE Users SET [seat] = 2, WHERE ([name] = " + (String)Session["mySessionVar"] + ")", conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
        }
    }
}
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
            ListBox1.Items.Clear();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            conn.Open();
            var cmd = new SqlCommand();
            cmd.CommandText = "Select * from Users";
            cmd.Connection = conn;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListBox1.Items.Add(reader.GetSqlValue(0).ToString());
                }
            }
            reader.Close();

            // load the name as a seat if in a seat
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            conn2.Open();
            cmd.CommandText = "Select * from Users";
            cmd.Connection = conn2;
            var reader2 = cmd.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    if (reader2.GetSqlValue(1).ToString() == "1") // seat
                    {
                        lblSeat1.Text = reader2.GetSqlValue(0).ToString();
                    }
                    if (reader2.GetSqlValue(1).ToString() == "2") // seat
                    {
                        lblSeat2.Text = reader2.GetSqlValue(0).ToString();
                    }
                    if (reader2.GetSqlValue(2).ToString() == "1") // yourTurn
                    {
                        if (lblSeat1.Text == lblusername.Text)
                        {
                            lblturn.Visible = true;
                            Button5.Visible = true;
                            lblnotMyTurn.Text = lblSeat2.Text;
                        }
                        else if (lblSeat2.Text == lblusername.Text)
                        {
                            lblturn.Visible = true;
                            Button5.Visible = true;
                            lblnotMyTurn.Text = lblSeat1.Text;
                        }
                        lblwhosTurn.Text = reader2.GetSqlValue(0).ToString();
                    }
                }
            }
            reader2.Close();
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
                SqlDataAdapter da3 = new SqlDataAdapter("INSERT INTO [Chat] ([name], [text], [datetime]) VALUES ('" + lblusername.Text + "', @chatMessage, '" + DateTime.Now.ToString() + "')", conn);
                da3.SelectCommand.Parameters.AddWithValue("@chatMessage", TextBox3.Text);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
            TextBox3.Text = "";
            GridView1.DataSourceID = "SqlDataSource1";
            TextBox3.Focus();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("DELETE FROM Users WHERE name='" + lblusername.Text + "';", conn);
                da3.SelectCommand.Parameters.AddWithValue("@chatMessage", TextBox3.Text);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
            Session.Remove("mySessionVar");
            Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("UPDATE Users SET [seat] = 1 WHERE ([name] = '" + lblusername.Text + "');", conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
            lblSeat1.Text = lblusername.Text;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("UPDATE Users SET [seat] = 2 WHERE ([name] = '" + lblusername.Text + "');", conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
            lblSeat2.Text = lblusername.Text;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (ListBox1.Visible == true)
            {
                ListBox1.Visible = false;
                Button4.Text = "Show Users List";
            }
            else
            {
                Button4.Text = "Hide Users List";
                ListBox1.Visible = true;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("UPDATE Users SET [yourTurn] = 0 WHERE ([name] = '" + lblusername.Text + "');", conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                SqlDataAdapter da2 = new SqlDataAdapter("UPDATE Users SET [yourTurn] = 1 WHERE ([name] = '" + lblnotMyTurn.Text + "');", conn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
            }
        }
    }
}
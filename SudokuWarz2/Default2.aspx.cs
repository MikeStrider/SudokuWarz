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
                        Button1.Visible = false;
                    }
                    if (reader2.GetSqlValue(1).ToString() == "2") // seat
                    {
                        lblSeat2.Text = reader2.GetSqlValue(0).ToString();
                        Button3.Visible = false;
                    }
                    if (reader2.GetSqlValue(2).ToString() == "1") // yourTurn
                    {
                        lblitsYourTurn.Text = reader2.GetSqlValue(0).ToString();
                    }
                }
            }
            reader2.Close();

            if (lblitsYourTurn.Text == lblusername.Text)
            {
                lblturn.Visible = true;
                Button5.Visible = true;
            }
            else
            {
                lblturn.Visible = false;
                Button5.Visible = false;
            }

            if (lblitsYourTurn.Text == "none")
            {
                Button6.Visible = true;
            } else
            {
                Button6.Visible = false;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Refreshed at " + DateTime.Now.ToLongTimeString();
            GridView1.DataSourceID = "SqlDataSource1";
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
            Response.Redirect("Default2.aspx");
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
            Response.Redirect("Default2.aspx");
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
            string notMyTurn;
            if (lblusername.Text == lblSeat2.Text)
            {
                notMyTurn = lblSeat1.Text;
            }
            else
            {
                notMyTurn = lblSeat2.Text;
            }

            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("UPDATE Users SET [yourTurn] = 0 WHERE ([name] = '" + lblitsYourTurn.Text + "');", conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                SqlDataAdapter da2 = new SqlDataAdapter("UPDATE Users SET [yourTurn] = 1 WHERE ([name] = '" + notMyTurn + "');", conn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
            }
            Response.Redirect("Default2.aspx");
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (lblitsYourTurn.Text == lblusername.Text)
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblcol1 = (Label)e.Item.FindControl("lblcol1");
                    TextBox txtcol1 = (TextBox)e.Item.FindControl("txtcol1");
                    if (lblcol1.Text == "0")
                    {
                        lblcol1.Visible = false;
                        txtcol1.Visible = true;
                    }
                    Label lblcol2 = (Label)e.Item.FindControl("lblcol2");
                    TextBox txtcol2 = (TextBox)e.Item.FindControl("txtcol2");
                    if (lblcol2.Text == "0")
                    {
                        lblcol2.Visible = false;
                        txtcol2.Visible = true;
                    }
                    Label lblcol3 = (Label)e.Item.FindControl("lblcol3");
                    TextBox txtcol3 = (TextBox)e.Item.FindControl("txtcol3");
                    if (lblcol3.Text == "0")
                    {
                        lblcol3.Visible = false;
                        txtcol3.Visible = true;
                    }
                    Label lblcol4 = (Label)e.Item.FindControl("lblcol4");
                    TextBox txtcol4 = (TextBox)e.Item.FindControl("txtcol4");
                    if (lblcol4.Text == "0")
                    {
                        lblcol4.Visible = false;
                        txtcol4.Visible = true;
                    }
                    Label lblcol5 = (Label)e.Item.FindControl("lblcol5");
                    TextBox txtcol5 = (TextBox)e.Item.FindControl("txtcol5");
                    if (lblcol5.Text == "0")
                    {
                        lblcol5.Visible = false;
                        txtcol5.Visible = true;
                    }
                    Label lblcol6 = (Label)e.Item.FindControl("lblcol6");
                    TextBox txtcol6 = (TextBox)e.Item.FindControl("txtcol6");
                    if (lblcol6.Text == "0")
                    {
                        lblcol6.Visible = false;
                        txtcol6.Visible = true;
                    }
                    Label lblcol7 = (Label)e.Item.FindControl("lblcol7");
                    TextBox txtcol7 = (TextBox)e.Item.FindControl("txtcol7");
                    if (lblcol7.Text == "0")
                    {
                        lblcol7.Visible = false;
                        txtcol7.Visible = true;
                    }
                    Label lblcol8 = (Label)e.Item.FindControl("lblcol8");
                    TextBox txtcol8 = (TextBox)e.Item.FindControl("txtcol8");
                    if (lblcol8.Text == "0")
                    {
                        lblcol8.Visible = false;
                        txtcol8.Visible = true;
                    }
                    Label lblcol9 = (Label)e.Item.FindControl("lblcol9");
                    TextBox txtcol9 = (TextBox)e.Item.FindControl("txtcol9");
                    if (lblcol9.Text == "0")
                    {
                        lblcol9.Visible = false;
                        txtcol9.Visible = true;
                    }
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("UPDATE Users SET [yourTurn] = 1 WHERE ([name] = '" + lblusername.Text + "');", conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
            Response.Redirect("Default2.aspx");
        }
    }
}
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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["mySessionVar"] = TextBox1.Text;


            string CS = ConfigurationManager.ConnectionStrings["SudokuWarzConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlDataAdapter da3 = new SqlDataAdapter("IF NOT EXISTS(Select[name] From[Users] where name = @name) insert into Users([name],seat,yourTurn) values(@name, 0, 0);", conn);
                // SqlDataAdapter da3 = new SqlDataAdapter("INSERT INTO [Users] ([seat], [name]) VALUES ('0', @name)", conn);
                da3.SelectCommand.Parameters.AddWithValue("@name", TextBox1.Text);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
            }
            Response.Redirect("Default2.aspx");
        }
    }
}
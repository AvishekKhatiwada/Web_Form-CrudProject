using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Diagnostics;
using System.Drawing;

namespace ProductCrud
{
    public partial class _Default : Page
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Database Connection
            string ConnectionString = "Server=localhost; Port=5432; Database=products; Username=postgres; Password=admin;";
            conn = new NpgsqlConnection(ConnectionString);
            conn.Open();

            string sql = "SELECT * FROM productDetails";
            cmd = new NpgsqlCommand(sql, conn);

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            productGridView.DataSource = dt;
            productGridView.DataBind();

            cmd.Dispose();
            conn.Close();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            
            LinkButton button = (LinkButton)sender;
            int ProductID = Convert.ToInt32(button.CommandArgument);

          
            Response.Redirect(String.Format("~/Edit.aspx?id={0}", ProductID));
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=localhost; Port=5432; Database=products; Username=postgres; Password=admin;";
            conn = new NpgsqlConnection(ConnectionString);
            conn.Open();

            LinkButton button = (LinkButton)sender;
            int ProductID = Convert.ToInt32(button.CommandArgument);

            string sql = "DELETE FROM productDetails WHERE id=@id";
            cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("id", ProductID);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            Response.Redirect("~/Default.aspx");
        }

    }
}
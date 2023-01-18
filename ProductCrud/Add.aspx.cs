using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProductCrud
{
    public partial class About : Page
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Database Connection
            string ConnectionString = "Server=localhost; Port=5432; Database=products; Username=postgres; Password=admin;";
            conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
        }

        protected void Add_Product(object sender,EventArgs e) 
        {
            //cmd = new NpgsqlCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = "DROP TABLE IF EXISTS Product";
            //cmd.ExecuteNonQuery();

            cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS ProductDetails (id SERIAL PRIMARY KEY,Name varchar(40),Quantity varchar(40),Price varchar(40), Color varchar(40))";
            cmd.ExecuteNonQuery();

            string Name = NameTextBox.Text;
            string Quantity = QuantityTextBox.Text;
            string Price = PriceTextBox.Text;
            string Color = ColorTextBox.Text;

            string sql = "INSERT INTO ProductDetails (Name, Quantity,Price,Color) VALUES(@name,@quantity,@price,@color)";
            cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("name", Name);
            cmd.Parameters.AddWithValue("quantity", Quantity);
            cmd.Parameters.AddWithValue("price", Price);
            cmd.Parameters.AddWithValue("color", Color);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            NameTextBox.Text = "";
            QuantityTextBox.Text = "";
            PriceTextBox.Text = "";
            ColorTextBox.Text = "";

            Response.Write("<script>alert('Data Inserted Successfully')</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}
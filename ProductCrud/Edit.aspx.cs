using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductCrud
{
    public partial class Contact : Page
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Server=localhost; Port=5432; Database=products; Username=postgres; Password=admin;";
            conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            if (!this.IsPostBack)
            {
                //Database Connection
                

                int id = Convert.ToInt32(Request.QueryString["id"]);
                string sql = "SELECT * FROM productDetails WHERE id=@id";
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);

                NpgsqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    Idtextbox.Text = read["id"].ToString();
                    NameTextBox.Text = read["Name"].ToString();
                    QuantityTextBox.Text = read["Quantity"].ToString();
                    PriceTextBox.Text = read["Price"].ToString();
                    ColorTextBox.Text = read["Color"].ToString();
                }

            }
        }
        protected void Edit_Product(object sender, EventArgs e)
        {
            cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            int id = Convert.ToInt32(Idtextbox.Text);
            string Name = NameTextBox.Text;
            string Quantity = QuantityTextBox.Text;
            string Price = PriceTextBox.Text;
            string Color = ColorTextBox.Text;

            string sql = "UPDATE ProductDetails SET Name=@name, Quantity =@quantity,Price=@price,Color=@color WHERE id=@id";
            cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("name", Name);
            cmd.Parameters.AddWithValue("quantity", Quantity);
            cmd.Parameters.AddWithValue("price", Price);
            cmd.Parameters.AddWithValue("color", Color);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            NameTextBox.Text = "";
            QuantityTextBox.Text = "";
            PriceTextBox.Text = "";
            ColorTextBox.Text = "";

            Response.Write("<script>alert('Data Updated Successfully')</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}
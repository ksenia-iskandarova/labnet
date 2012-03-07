using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class AdminPage : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["adm"]=="no")
                Response.Redirect("Comeformaspx.aspx");

            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Users\1\documents\visual studio 2010\Projects\WebApplication2\WebApplication2\App_Data\NetDB.mdf';Integrated Security=True;User Instance=True";
            Label1.Visible = false;
            conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM netadmins";
            SqlCommand qq1 = new SqlCommand(sql, conn);
            SqlDataReader reader = qq1.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            reader.Close();
            
            //string sql2 = "SELECT * FROM netusers";
            //SqlCommand qq2 = new SqlCommand(sql2, conn);
            //SqlDataReader reader2 = qq2.ExecuteReader();
            //GridView2.DataSource = reader2;
            //GridView2.DataBind();
            //reader2.Close();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //dataGridView2[dataGridView2.CurrentCellAddress.X,dataGridView2.CurrentCellAddress.Y].Value.ToString();
            string name = GridView2.SelectedValue.ToString();
            string status = GridView2.SelectedRow.Cells[3].ToString();
            string sql;
            if(status=="Locked")
                sql = "Update netusers set status = 'Open' where login = '"+name+"'";
            else
                sql = "Update netusers set status = 'Locked' where login = '" + name + "'";
            conn.Open();
            SqlCommand qq2 = new SqlCommand(sql, conn);
            SqlDataReader reader2 = qq2.ExecuteReader();
            reader2.Close();

            //string sql2 = "SELECT * FROM netusers";
            //SqlCommand qq1 = new SqlCommand(sql2, conn);
            //reader2 = qq1.ExecuteReader();
            //GridView2.DataSource = reader2;
            //GridView2.DataBind();
            //reader2.Close();
            conn.Close();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Label1.Visible = false;
            string login = TextBox1.Text;
            string pass = TextBox2.Text;
            conn.Open();
            string sql;
            sql = "select * from netadmins where login='"+login+"'";
            SqlCommand qq1 = new SqlCommand(sql, conn);
            SqlDataReader reader1 = qq1.ExecuteReader();
            if (reader1.HasRows)
            {
                Label1.Visible = true;
                Label1.Text = "В БД есть администратор с таким именем";
                reader1.Close();
                
            }
            else
            {
                Label1.Visible = false;
                reader1.Close();
                sql = "insert into netadmins values('" + login + "','" + pass + "')";
                SqlCommand qq2 = new SqlCommand(sql, conn);
                SqlDataReader reader = qq2.ExecuteReader();
                reader.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Comeformaspx.aspx");
        }
    }
}
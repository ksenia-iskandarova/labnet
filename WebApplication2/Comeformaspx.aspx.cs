using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    
    public partial class Comeformaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
        }

        protected void ComeButton_Click(object sender, EventArgs e)
        {
            Label2.Visible = false;
            string login = LoginText.Text.ToString();
            string pass = PasswordText.Text.ToString();
            try
            {
                string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Users\1\documents\visual studio 2010\Projects\WebApplication2\WebApplication2\App_Data\NetDB.mdf';Integrated Security=True;User Instance=True";
                //Data Source = myServerAddress; Initial Catalog = myDataBase; Integrated Security = SSPI;
                SqlConnection q = new SqlConnection(connectionString);//"Data Source=SQL Server Name;persist security info=False;Initial Catalog=NetDB;Integrated Security=SSPI;Asynchronous Processing=True");
                q.Open();
                
                string sqlreqst = "select * from netusers where login = '" + login + "' and pass = '" + pass + "'";
                SqlCommand qq1 = new SqlCommand(sqlreqst, q);
                //qq1.ExecuteNonQuery();
                SqlDataReader reader = qq1.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    string status = "select * from netusers where login = '" + login + "' and status = 'Open'";
                    SqlCommand qq = new SqlCommand(status, q);
                    //qq1.ExecuteNonQuery();
                    SqlDataReader reader1 = qq.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        Session["user"] = login;
                        Session["adm"] = "no";
                        Response.Redirect("WebClientTestPage.aspx");
                        
                    }
                    else 
                    {
                        Label2.Visible = true;
                        Label2.Text = "Вы заблокированы администратором.";
                    }
                    reader1.Close();
                }
                else
                {
                    reader.Close();
                    string sqlreqst1 = "select * from netadmins where login = '" + login + "' and pass = '" + pass + "'";
                    SqlCommand qq2 = new SqlCommand(sqlreqst1, q);
                    //qq1.ExecuteNonQuery();
                    SqlDataReader reader1 = qq2.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        Session["user"] = login;
                        Session["adm"] = "yes";
                        Response.Redirect("AdminPage.aspx");
                        reader1.Close();
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
                Label1.Text += '\n';
                Label1.Text += "Неверный логин или пароль";
            }
        }
    }
}
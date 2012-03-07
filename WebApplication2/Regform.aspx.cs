using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = LoginText.Text.ToString();
            string pass = PasswordText.Text.ToString();
            try
            {
                string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Users\1\documents\visual studio 2010\Projects\WebApplication2\WebApplication2\App_Data\NetDB.mdf';Integrated Security=True;User Instance=True";
                //Data Source = myServerAddress; Initial Catalog = myDataBase; Integrated Security = SSPI;
                SqlConnection q = new SqlConnection(connectionString);//"Data Source=SQL Server Name;persist security info=False;Initial Catalog=NetDB;Integrated Security=SSPI;Asynchronous Processing=True");
                q.Open();
                string sqlreqst = "INSERT INTO netusers VALUES ('" + login + "','" + pass+"')";
                SqlCommand qq1 = new SqlCommand(sqlreqst, q);
                qq1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
            }
            
            //string sqlreqst = "INSERT INTO [WebDB3].[dbo].[WebUser] VALUES ('" + login + "','" + pass + "','" + System.DateTime.Now.ToString() + "','" + System.DateTime.Now.ToString() + "','нет')";
            //SqlCommand qq1 = new SqlCommand(sqlreqst, q);
            //qq1.ExecuteNonQuery();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class AddTelephone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddPhone(object sender, EventArgs e)
        {

            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("addMobile", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string field1 = (string)(Session["field1"]);
            string nummer = txt_tel.Text;
            

            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@username", field1));
            cmd.Parameters.Add(new SqlParameter("@mobile_number", nummer));
          
            //Save the output from the procedure


            //Executing the SQLCommand
            conn.Open();
            if (nummer == "")
            {
                txtMessages.Text = "please enter a mobile number";
            }
            else
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    txtMessages.Text = ("success");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        txtMessages.Text = "this number is already entered";
                    }
                    else
                    {
                        txtMessages.Text = ("please try again. error:"+ ex.Number);
                    }

                }
            }
            conn.Close();
            // Response.Write("Registration Successful!");


        }
        protected void GOback(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx", true);
        }

    }
}
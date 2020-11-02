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
    public partial class AddCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddCard(object sender, EventArgs e)
        {

            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("AddCreditCard", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string field1 = (string)(Session["field1"]);
            string nummer = txt_num.Text;
            string exp = txt_exp.Text;
            string ccv = txt_ccv.Text;



            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@customername", field1));
            cmd.Parameters.Add(new SqlParameter("@creditcardnumber", nummer));
            cmd.Parameters.Add(new SqlParameter("@expirydate", exp));
            cmd.Parameters.Add(new SqlParameter("@cvv", ccv));

            //Save the output from the procedure


            //Executing the SQLCommand
            conn.Open();
            if (nummer == "" || exp == "" || ccv == "")
            {
                txtMessages.Text = "please fill all boxes";
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
                        txtMessages.Text = "this card is already entered";
                    }
                    else
                    {
                        txtMessages.Text = ("please enter a valid expiry date in format dd/mm/yyyy");
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
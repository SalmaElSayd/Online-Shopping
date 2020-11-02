using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("UserLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string username = txt_username.Text;
            string password = txt_password.Text;

            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            //Save the output from the procedure
            SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
            type.Direction = ParameterDirection.Output;

            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;

            //Executing the SQLCommand
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


            if (success.Value.ToString().Equals("1"))
            {
                //To send response data to the client side (HTML)
                Response.Write("Passed");

                /*ASP.NET session state enables you to store and retrieve values for a user
                as the user navigates ASP.NET pages in a Web application.
                This is how we store a value in the session*/
                Session["field1"] = username;

                //To navigate to another webpage
                 Response.Redirect("CustomerHome.aspx", true);//____________________dont forget______________-_-___---___-
                if (type.Value.ToString().Equals("0"))
                {
                    Response.Write("Customer");
                }
                else if (type.Value.ToString().Equals("1")) 
                {
                    Response.Write("Vendor");
                }
                else if (type.Value.ToString().Equals("2"))
                {
                    Response.Write("Admin");
                }
                else if (type.Value.ToString().Equals("3"))
                {
                    Response.Write("Delivery");
                };

            }
            else
            {
                //Console.WriteLine("Failed");
                Response.Write("Login failed. Please check username and password.");
            }
        }
        protected void GoRegVendor(object sender, EventArgs e) {
            Response.Redirect("VendorRegistration.aspx", true);
        }


              protected void GoRegCust(object sender, EventArgs e)
        {
            Response.Redirect("UserRegistration.aspx", true);
        }

    }
}
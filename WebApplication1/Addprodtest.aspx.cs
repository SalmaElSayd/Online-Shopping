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
    public partial class Addprodtest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Post(object sender, EventArgs e) { 
        
                //Get the information of the connection to the database
                string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                /*create a new SQL command which takes as parameters the name of the stored procedure and
                 the SQLconnection name*/
                SqlCommand cmd = new SqlCommand("postProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //To read the input from the user
                string username = usr.Text;
                string prodname = pass.Text;
                string category = fn.Text;
                string description = ln.Text;
                string prix = eml.Text;
                string color = company_name_text.Text;

                //pass parameters to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@vendorUsername", username));
                cmd.Parameters.Add(new SqlParameter("@product_name", prodname));
                cmd.Parameters.Add(new SqlParameter("@category", category));
                cmd.Parameters.Add(new SqlParameter("@product_description", description));
                cmd.Parameters.Add(new SqlParameter("@price", prix));
                cmd.Parameters.Add(new SqlParameter("@color", color));

            string query2 = "Select scope_Identity";


            int ID;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            using (SqlCommand cmd2 = new SqlCommand(query2, conn))
            {
                conn.Open();

                ID = (int)cmd.ExecuteScalar();
                conn.Close();
            }


            }



    }
}
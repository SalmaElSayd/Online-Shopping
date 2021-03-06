﻿using System;
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
    public partial class VendorRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void VendorReg(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("vendorRegister", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string username = usr.Text;
            string password = pass.Text;
            string first_name = fn.Text;
            string last_name = ln.Text;
            string email = eml.Text;
            string company_name = company_name_text.Text;
            string bank_account_no = bank_account_text.Text;

            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@first_name", first_name));
            cmd.Parameters.Add(new SqlParameter("@last_name", last_name));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@company_name", company_name));
            cmd.Parameters.Add(new SqlParameter("@bank_acc_no", bank_account_no));

            //Save the output from the procedure


            //Executing the SQLCommand
           
            if (username == "" || password == "" || first_name == "" || last_name == "" || email == "" || company_name == "" || bank_account_no == "")
            {
                txtMessages.Text = "please fill all boxes";
            }
            else
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    txtMessages.Text = ("success");
                    conn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        txtMessages.Text = "this username is already taken";
                    }
                    else
                    {
                        txtMessages.Text = ("please choose another username (below 20 characters).error:"+ex.Number);
                    }

                }
            }
         
            //Response.Write("Registration Successful!");


        }
        protected void GOback(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx", true);
        }
    }
}

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
    public partial class Wishlists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("showwishnames", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string field1 = (string)(Session["field1"]);
            cmd.Parameters.Add(new SqlParameter("@username", field1));

            conn.Open();

            //IF the output is a table, then we can read the records one at a time
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
               
                while (rdr.Read())
                {
                    //Get the value of the attribute name in the Company table
                    string lname = rdr.GetString(rdr.GetOrdinal("name"));


                    //Create a new label and add it to the HTML form
                    Label lbl_ListName = new Label();
                    lbl_ListName.Text = lname + "<br />";
                    form1.Controls.Add(lbl_ListName );
              

            }
                //this is how you retrive data from session variable.
            }
            catch (Exception ex) { }

        }
        public void AddWL(object sender, EventArgs e)
        {
            Boolean wishexists = false;
            Boolean prodexists = false;
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("AddtoWishlist", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //this is how you retrive data from session variable.
            string field1 = (string)(Session["field1"]);
            string serial_no = prod_add_txt.Text;
            //To read the input from the user
            //string username =field1;
            string wlname = listname_add_txt.Text;
            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Customername", field1));
            cmd.Parameters.Add(new SqlParameter("@wishlistname", wlname));
            cmd.Parameters.Add(new SqlParameter("@serial", serial_no));

            
            //Executing the SQLCommand
            conn.Open();
            SqlCommand myCommand = new SqlCommand("select serial_no from Product", conn);
            SqlDataReader rdr2 = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr2.Read())
            {
                if (rdr2["serial_no"].ToString().Contains(serial_no.ToString()))
                {
                    prodexists = true;
                    break;
                }
                else
                {
                    prodexists = false;

                }
            }
            conn.Close();


            conn.Open();
            if (serial_no == "")
            {
                txtMessages.Text = "please select a product to add";
            }
            else
            {
               
                        if (prodexists)
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
                            txtMessages.Text = ("product already in list");

                        }
                        else
                        {
                            txtMessages.Text = ("error:" + ex.Number);

                        }

                    }
                        }
                        else
                        {
                            txtMessages.Text = ("this product does not exist");

                        }
                    

                
            }
                conn.Close();

            
        }

        public void RemoveWL(object sender, EventArgs e)
        {

            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("removefromWishlist", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //this is how you retrive data from session variable.
            string field1 = (string)(Session["field1"]);
            string WLname = listname_rem_txt.Text;

            //To read the input from the user
            //string username =field1;
            string serial_no = prod_rem_txt.Text;
            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Customername", field1));
            cmd.Parameters.Add(new SqlParameter("@wishlistname", WLname));
            cmd.Parameters.Add(new SqlParameter("@serial", serial_no));


            //Executing the SQLCommand
            Boolean wishexists = false;
            Boolean prodexists = false;

            //Executing the SQLCommand
            conn.Open();
            SqlCommand myCommand = new SqlCommand("select serial_no from Product", conn);
            SqlDataReader rdr2 = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr2.Read())
            {
                if (rdr2["serial_no"].ToString().Contains(serial_no.ToString()))
                {
                    prodexists = true;
                    break;
                }
                else
                {
                    prodexists = false;

                }
            }
            conn.Close();


            conn.Open();
            if (serial_no == "")
            {
                txtMessages.Text = "please select a product to add";
            }
            else
            {

                if (prodexists)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        txtMessages.Text = ("success");
                    }
                    catch (SqlException ex)
                    {
                        txtMessages.Text = ("error:" + ex.Number);


                    }
                }
                else
                {
                    txtMessages.Text = ("this product does not exist");

                }



            }
            conn.Close();
            
        }

        protected void GOback(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx", true);
        }

        public void createWL(object sender, EventArgs e)
        {

            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("createWishlist", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //this is how you retrive data from session variable.
            string field1 = (string)(Session["field1"]);
            string WLname = newname_txt.Text;

            //To read the input from the user
            //string username =field1;
            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Customername", field1));
            cmd.Parameters.Add(new SqlParameter("@name", WLname));


            //Executing the SQLCommand
            conn.Open();
            if (WLname == "" )
            {
                txtMessages.Text = "please enter a name for your wishlist";
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
                        txtMessages.Text = "this wishlist already exists";
                    }
                    else
                    {
                        txtMessages.Text = ("please try again. error:"+ ex.Number);
                    }

                }
            }
            conn.Close();

        }
        public void viewWL(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("showWishlistProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string field1 = (string)(Session["field1"]);
            string WLname = viewname_txt.Text;
            cmd.Parameters.Add(new SqlParameter("@Customername", field1));
            cmd.Parameters.Add(new SqlParameter("@name", WLname));
            conn.Open();

            //IF the output is a table, then we can read the records one at a time
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    //Get the value of the attribute name in the Company table
                    int Prodserialno = rdr.GetInt32(rdr.GetOrdinal("serial_no"));
                    string Prodserial = (rdr.GetInt32(rdr.GetOrdinal("serial_no"))).ToString();
                    string ProdName = rdr.GetString(rdr.GetOrdinal("product_name"));
                    //Get the value of the attribute field in the Company table
                    string Prodfinalprice = (rdr.GetSqlDecimal(rdr.GetOrdinal("final_price"))).ToString();
                    string Prodprice = (rdr.GetSqlDecimal(rdr.GetOrdinal("price"))).ToString();

                    string availability = (rdr.GetSqlBoolean(rdr.GetOrdinal("available"))).ToString();
                    if (rdr.GetSqlBoolean(rdr.GetOrdinal("available")))
                    {
                        availability = "available";
                    }
                    else availability = "not available";

                    string category = rdr.GetString(rdr.GetOrdinal("category"));

                    string color;
                    if (!rdr.IsDBNull(rdr.GetOrdinal("color")))
                    {
                        color = (rdr.GetString(rdr.GetOrdinal("product_description")));
                    }
                    else color = "__";
                    string descrip;
                    if (!rdr.IsDBNull(rdr.GetOrdinal("product_description")))
                    {
                        descrip = (rdr.GetString(rdr.GetOrdinal("product_description")));
                    }
                    else descrip = "__";

                    string rating;
                    if (!rdr.IsDBNull(rdr.GetOrdinal("rate")))
                    {
                        rating = (rdr.GetFieldValue<Int16>(rdr.GetOrdinal("rate"))).ToString();
                    }
                    else rating = "__";

                    string ProdVendorName = rdr.GetString(rdr.GetOrdinal("vendor_username"));

                    //Create a new label and add it to the HTML form
                    Label lbl_serial = new Label();
                    lbl_serial.Text = "<div>" + " no.: " + Prodserial + "</div>";
                    form1.Controls.Add(lbl_serial);

                    Label lbl_ProdName = new Label();
                    lbl_ProdName.Text = "<div>" + "   name: " + ProdName + "</div>";
                    form1.Controls.Add(lbl_ProdName);

                    Label lbl_category = new Label();
                    lbl_category.Text = "<div>" + "   category: " + category + "</div>";
                    form1.Controls.Add(lbl_category);

                    Label lbl_color = new Label();
                    lbl_color.Text = "<div>" + "   color: " + color + "</div>";
                    form1.Controls.Add(lbl_color);

                    Label lbl_avail = new Label();
                    lbl_avail.Text = "<div>" + "    " + availability + "</div>";
                    form1.Controls.Add(lbl_avail);

                    Label lbl_Prodvendor = new Label();
                    lbl_Prodvendor.Text = "<div>" + "   category: " + ProdVendorName + "</div>";
                    form1.Controls.Add(lbl_Prodvendor);

                    Label lbl_rate = new Label();
                    lbl_rate.Text = "<div>" + "   rating: " + rating + "</div>";
                    form1.Controls.Add(lbl_rate);

                    Label lbl_price = new Label();
                    lbl_price.Text = "<div>" + "   price: " + Prodprice + "</div>";
                    form1.Controls.Add(lbl_price);

                    Label lbl_finalprice = new Label();
                    lbl_finalprice.Text = "<div>" + "   final price: " + Prodfinalprice + "</div>";
                    form1.Controls.Add(lbl_finalprice);

                    Label lbl_descrip = new Label();
                    lbl_descrip.Text = "<div>" + "   description: " + descrip + "</div>" + "  <br /> <br />";
                    form1.Controls.Add(lbl_descrip);


                    // Button AddToCart_btn = new Button();
                    // AddToCart_btn.Text = "   Add to cart: " ; 
                    // form1.Controls.Add(AddToCart_btn);

                }
            }
            else
            {
                txtMessages.Text = "this wishlist is empty";
            }

        }
    }
    }

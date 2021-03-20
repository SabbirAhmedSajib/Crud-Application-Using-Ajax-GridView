using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Crud_Application_Using_Ajax_GridView
{
    public partial class select_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void but1_Click(object sender, EventArgs e)
        {
            string maincon = ConfigurationManager.ConnectionStrings["Personal"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(maincon);
            string sqlquery = "Insert into [dbo].[SchoolName] (School_name) values (@School_name)";
            SqlCommand sqlconn = new SqlCommand(sqlquery, sqlcon);
            sqlconn.Parameters.AddWithValue("@School_name",DropDownList.SelectedItem.Value);
            sqlcon.Open();

            int i = sqlconn.ExecuteNonQuery();
            if (i != 0)
            {
                lit1.Text = ("Selected Record saved Successfully");
            }
            else
            {
                lit1.Text = ("Failed to Insert the Record");
            }

            sqlcon.Close();
        }

    }
}
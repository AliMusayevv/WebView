using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebView
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(DataSource.DS);
        SqlCommand cmd= new SqlCommand();
        string query;
        DataTable DT =new DataTable();
        DataSet DS=new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            query = "select*from CatProView where CategoryName='" + TxtSearch.Text + "'";
            cmd =new SqlCommand(query,conn);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DS);
            GrdResult.DataSource = DS.Tables[0].DefaultView;
             GrdResult.DataBind();
            GrdResult.Visible= true;
            LblResult.Visible = false;
            if (DS.Tables[0].Rows.Count == 0)
            {
                LblResult.Text = "There is not data such as this CategoryName";
                GrdResult.Visible = false;
                LblResult.Visible = true;
            }


        }

    }
}
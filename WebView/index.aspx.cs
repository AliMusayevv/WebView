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
        bool TextChanged = false;
        SqlConnection conn = new SqlConnection(DataSource.DS);
        SqlCommand cmd = new SqlCommand();
        string query;
        DataTable DT = new DataTable();
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {


            LblResult.Visible = false;
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            this.MetGrd();

        }

        private void MetGrd()
        {
            if (TextChanged)
            {
                Session["data"] = null;
            }


            if (Session["data"] == null)
            {


                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                query = "select*from CatProView where CategoryName='" + TxtSearch.Text + "'";
                cmd = new SqlCommand(query, conn);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS);
                Session["data"] = DS.Tables[0].DefaultView;
                GrdResult.DataSource = Session["data"];

                if (DS.Tables[0].Rows.Count == 0)
                {
                    LblResult.Text = "There is no data such as this CategoryName";
                    GrdResult.Visible = false;
                    LblResult.Visible = true;
                    Session["data"] = null;
                    return;
                }
                conn.Close();

            }

            GrdResult.DataSource = Session["data"];
            GrdResult.DataBind();
            GrdResult.Visible = true;
            LblResult.Visible = false;

        }

        protected void GrdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdResult.PageIndex = e.NewPageIndex;
            this.MetGrd();
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            TextChanged = true;
        }
    }
}
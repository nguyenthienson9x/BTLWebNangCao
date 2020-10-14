using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace SKH_Learning
{
    public partial class CategorySKH : System.Web.UI.Page
    {
        int iDUYET = 2;
        KhoaHocDAO khoaHocDAO = new KhoaHocDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadListViewKhoaHoc();
            }
        }

        private void LoadListViewKhoaHoc()
        {
            if (Request.QueryString["ID"] != null)
            {
                String sCategoryID = Request.QueryString["ID"].ToString();
                String CategoryStr = "";
                int iCategoryID = 0;
                try
                {
                    iCategoryID = int.Parse(sCategoryID);

                    List<String> listPara1 = new List<string>() { "@ID" };
                    object[] param1 = new object[] { iCategoryID };
                    CategoryStr = categoryDAO.GetData(param1, listPara1)[0].SCategory;
                }
                catch
                {
                    iCategoryID = 0;
                    CategoryStr = "";
                }
                List<String> listPara = new List<string>() { "@FK_iCategoryID", "@iDuyet" };
                object[] param = new object[] { iCategoryID, iDUYET };
                lsVKhoaHoc.DataSource = khoaHocDAO.GetData(param, listPara);
                lsVKhoaHoc.DataBind();

                Label lblh1 = (Label)Master.FindControl("lblh1");
                lblh1.Text = CategoryStr;
            }
        }
    }
}
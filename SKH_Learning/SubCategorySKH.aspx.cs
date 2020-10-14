using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace SKH_Learning
{
    public partial class SubCategorySKH : System.Web.UI.Page
    {
		int iDUYET = 2;
        KhoaHocDAO khoaHocDAO = new KhoaHocDAO();
        SubCategoryDAO subCategoryDAO = new SubCategoryDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadListViewKhoaHoc();
            }
        }

        private void LoadListViewKhoaHoc()
        {
            String sCategoryID = Request.QueryString["ID"].ToString();


            String sSubCategory = "";
            int iSubCategoryID = 0;
            try
            {
                iSubCategoryID = int.Parse(sCategoryID);

                List<String> listParaSub = new List<string>() { "@ID" };
                object[] paramSub = new object[] { iSubCategoryID };
                sSubCategory = subCategoryDAO.GetData(paramSub, listParaSub)[0].SSubCategory;
            }
            catch
            {
                iSubCategoryID = 0;
                sSubCategory = "";
            }
            List<String> listPara = new List<string>() { "@FK_iSubID" , "@iDuyet" };
            object[] param = new object[] { iSubCategoryID , iDUYET};
            lsVKhoaHoc.DataSource = khoaHocDAO.GetData(param, listPara);
            lsVKhoaHoc.DataBind();

            Label lblh1 = (Label)Master.FindControl("lblh1");
            lblh1.Text = sSubCategory;
        }
    }
}
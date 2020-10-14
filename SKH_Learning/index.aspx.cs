using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace SKH_Learning
{
    public partial class index : System.Web.UI.Page
    {
        KhoaHocDAO khoaHocDAO= new KhoaHocDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadListViewKhoaHoc();
            }
        }

        private void LoadListViewKhoaHoc()
        {
			object[] param = new object[] { 2 };
			List<string> listParam = new List<string>(){ "iDuyet"};
            lsVKhoaHoc.DataSource = khoaHocDAO.GetData(param, listParam);
            lsVKhoaHoc.DataBind();
        }
    }
}
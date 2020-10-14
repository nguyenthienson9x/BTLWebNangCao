using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SKH_Learning.Admin.MasterPage
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RawUrl.ToString().Contains("DangNhap"))
            {
                bg_btnChucNang.Visible = false;
                lsCategory.Visible = false;
            }
            CheckDangNhap();
        }

        private void CheckDangNhap()
        {
            if (Session["Admin"].ToString().Equals(""))
            {
                bg_btnChucNang.Visible = true; 
                btnDangXuat.Visible = false;
            }
            else
            {
                bg_btnChucNang.Visible = false;
                btnDangXuat.Visible = true;
            }
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["Admin"] = "";
            Response.Redirect("DangNhap.aspx");
        }
    }
}
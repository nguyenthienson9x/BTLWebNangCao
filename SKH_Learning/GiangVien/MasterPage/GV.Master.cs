using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;

namespace SKH_Learning.GiangVien.MasterPage
{
    public partial class GV : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RawUrl.ToString().Contains("DangNhap"))
            {
                bg_btnChucNang.Visible = false;
                lsCategory.Visible = false;
            }

            if (!IsPostBack)
            {
                LoadSideMenu();
            }
            CheckDangNhap();
        }
        private void LoadSideMenu()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            SubCategoryDAO subCategoryDAO = new SubCategoryDAO();

            List<Category> categories = categoryDAO.GetData(null, null);
            List<SubCategory> subCategories = subCategoryDAO.GetData(null, null);

            String list = "<ul class='supMenu'>";
            foreach (Category category in categories)
            {
                list += "<li><a href='QuanLyKhoaHoc.aspx?ID=" + category.IID + "'>" + category.SCategory + "</a><ul class='subMenu'>";
                foreach (SubCategory subCategory in subCategories)
                {
                    if (subCategory.IID_Category == category.IID)
                    {
                        list += "<li><a href='QuanLyKhoaHoc.aspx?SubID=" + subCategory.IID + "'>" + subCategory.SSubCategory + "</a></li>";
                    }
                }
                list += "</ul></li>";
            }
            list += "</ul>";
            lsCategory.InnerHtml += list;
        }
        private void CheckDangNhap()
        {
            if (Session["GiangVien"].ToString().Equals(""))
            {
                lblLoiChao.Text = "Mời bạn đăng nhập!";
                btnDangXuat.Visible = false;
            }
            else
            {
                lblLoiChao.Text = "Halo, chúc bạn một ngày tốt lành";
                bg_btnChucNang.Style.Add("display", "none");
                btnDangXuat.Visible = true;
            }
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["GiangVien"] = "";
            Response.Redirect("DangNhap.aspx");
        }
    }
}
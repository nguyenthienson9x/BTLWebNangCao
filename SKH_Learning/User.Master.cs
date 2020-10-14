using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
namespace SKH_Learning
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSideMenu();
            }
            CheckDangNhap();
            if (Request.RawUrl.Contains("index.aspx"))
            {
                lblh1.Text = "";
            }
        
        }

        

        private void CheckDangNhap()
        {
            if (Session["HocVien"].ToString().Equals(""))
            {
                lblLoiChao.Text = "Mời bạn đăng nhập!";
                btnDangXuat.Visible = false;
            }
            else
            {
                HocVienDAO hocVienDAO = new HocVienDAO();
                String sTenHocVien = hocVienDAO.GetTen(int.Parse(Session["HocVien"].ToString()));
                lblLoiChao.Text = "Chào "+ sTenHocVien;
                bg_btnChucNang.Style.Add("display","none");
                btnDangXuat.Visible = true;
            }
        }

        private void LoadSideMenu()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            SubCategoryDAO subCategoryDAO = new SubCategoryDAO();

            List<Category> categories = categoryDAO.GetData(null, null);
            List<SubCategory> subCategories = subCategoryDAO.GetData(null, null);

            String list = "<ul class='supMenu'>";
            foreach(Category category in categories)
            {
                list += "<li><a href='CategorySKH.aspx?ID=" + category.IID+"'>"+category.SCategory+"</a><ul class='subMenu'>";
                foreach(SubCategory subCategory in subCategories)
                {
                    if(subCategory.IID_Category == category.IID)
                    {
                        list += "<li><a href='SubCategorySKH.aspx?ID=" + subCategory.IID+"'>"+subCategory.SSubCategory+"</a></li>";
                    }
                }
                list += "</ul></li>";
            }
            list += "</ul>";
            lsCategory.InnerHtml += list;
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["HocVien"] = "";
            string[] cookies = Request.Cookies.AllKeys;
            foreach(string ck in cookies)
            {
                Response.Cookies[ck].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void btnTimKiem_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("TimKiem.aspx?Search="+txtbTimKiem.Value);
        }
    }
}
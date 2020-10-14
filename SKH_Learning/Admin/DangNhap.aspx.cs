using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace SKH_Learning.Admin
{
    public partial class DangNhap : System.Web.UI.Page
    {
        AdminDAO adminDAO = new AdminDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            String Email = txtbEmail.Text.Trim().ToString();
            String Password = EncodeMD5(txtbPassword.Text.Trim().ToString());
            //Response.Write("Email: " + Email + ", Pass:" + Password);
            List<String> listPara = new List<String>() { "@sEmail", "@sPassword" };
            object[] para = new object[] { Email, Password };
            int AdminID = adminDAO.DangNhap(para, listPara);
            if (AdminID > 0)
            {
                Session["HocVien"] = "";
                Session["Admin"] = AdminID;
                Session["GiangVien"] = "";
                Response.Write("<script>alert('Đăng nhập thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=DuyetDangKyHoc.aspx");
            }
            else
            {
                Response.Write("<script>alert('Đăng nhập thất bại, vui lòng kiểm tra lại Username và Password');</script>");
            }
        }

        private string EncodeMD5(string pass)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
            bs = (new MD5CryptoServiceProvider()).ComputeHash(bs);
            return BitConverter.ToString(bs).Replace("-", "").ToLower();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace SKH_Learning
{
    public partial class DangNhap : System.Web.UI.Page
    {
        HocVienDAO hocVienDAO = new HocVienDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblh1 = (Label)Master.FindControl("lblh1");
            lblh1.Text = "Đăng nhập";
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            String Email = txtbEmail.Text.Trim().ToString();
            String Password = EncodeMD5(txtbPassword.Text.Trim().ToString());

            /*String Password = password.InnerText.ToString();
            Response.Write("<script>alert('Hashed: " + Password + "')</script>");*/

            //Response.Write("Email: " + Email + ", Pass:" + Password);
            List<String> listPara = new List<String>() { "@sEmail", "@sPassword" };
            object[] para = new object[] { Email, Password };
            int HocVienID = hocVienDAO.DangNhap(para, listPara);
            if (HocVienID > 0)
            {
                Session["HocVien"] = HocVienID;
                Session["Admin"] = "";
                Session["GiangVien"] = "";

                HttpCookie hocVienCookie = new HttpCookie("HocVienCookie");
                hocVienCookie.Value = Session["HocVien"].ToString();
                hocVienCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(hocVienCookie);

                Response.Write("<script>alert('Đăng nhập thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=index.aspx");
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
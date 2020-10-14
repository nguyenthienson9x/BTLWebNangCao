using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace SKH_Learning
{
    public partial class DangKy : System.Web.UI.Page
    {
        static HocVienDAO hocVienDAO = new HocVienDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblh1 = (Label)Master.FindControl("lblh1");
            lblh1.Text = "Đăng ký";
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            String Email = txtbEmail.Text.ToString();
            String PassHashed = EncodeMD5(txtbPassword.Text.Trim().ToString());
            
            String HoTen = txtbHoTen.Text.ToString();
            String SDT = txtbSDT.Text.ToString();
            String DiaChi = txtbDiaChi.Text.ToString();
            String NgaySinh = txtbNgaySinh.Text.ToString();
            List<string> listParam = new List<string> { "@sHoTen" , "@sSDT", "@sDiaChi", "@dNgaySinh", "@sEmail", "@sPassword" };
            object[] param = new object[] { HoTen, SDT, DiaChi, NgaySinh, Email, PassHashed };
            if(hocVienDAO.DangKy(param, listParam))
            {
                DangNhap();
                Response.Write("<script>alert('Đăng ký thành công!');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=index.aspx");
            }
            else
            {
                Response.Write("<script>alert('Đăng ký thất bại, vui lòng kiểm tra lại đường truyền');</script>");

            }
        }
        private string EncodeMD5(string pass)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
            bs = (new MD5CryptoServiceProvider()).ComputeHash(bs);
            return BitConverter.ToString(bs).Replace("-", "").ToLower();
        }

        private void DangNhap()
        {
            String Username = txtbEmail.Text.Trim().ToString();
            String Password = EncodeMD5(txtbPassword.Text.Trim().ToString());
            List<String> listPara = new List<String>() { "@sUsername", "@sPassword" };
            object[] para = new object[] { Username, Password };
            int HocVienID = hocVienDAO.DangNhap(para, listPara);
            if (HocVienID > 0)
            {
                Session["HocVien"] = HocVienID;
                Session["Admin"] = "";
                Session["GiangVien"] = "";
            }
        }

        [WebMethod]
        public static bool CheckMail(String Email)
        {
            return hocVienDAO.CheckMail(Email);            
        }
    }
}
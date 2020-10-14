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
    public partial class AddGiangVien : System.Web.UI.Page
    {
        GiangVienDAO giangVienDAO = new GiangVienDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            String Email = txtbEmail.Text.ToString();
            String PassHashed = EncodeMD5(txtbPassword.Text.Trim().ToString());

            String HoTen = txtbHoTen.Text.ToString();
            String SDT = txtbSDT.Text.ToString();
            String DiaChi = txtbDiaChi.Text.ToString();
            String NgaySinh = txtbNgaySinh.Text.ToString();
            List<string> listParam = new List<string> { "@sHoTen", "@sSDT", "@sDiaChi", "@dNgaySinh", "@sEmail", "@sPassword" };
            object[] param = new object[] { HoTen, SDT, DiaChi, NgaySinh, Email, PassHashed };
            if (giangVienDAO.Insert(param, listParam))
            {
                Response.Write("<script>alert('Thêm mới thành công!');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=AddGiangVien.aspx");
            }
            else
            {
                Response.Write("<script>alert('Thêm mới thất bại, vui lòng kiểm tra lại đường truyền');</script>");

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
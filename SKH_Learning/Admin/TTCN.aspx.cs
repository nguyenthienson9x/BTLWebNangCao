using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;

namespace SKH_Learning.Admin
{
    public partial class TTCN : System.Web.UI.Page
    {
        AdminDAO adminDAO = new AdminDAO();
        DTO.Admin admin = new DTO.Admin();
        int AdminID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"].ToString() != "")
            {
                AdminID = int.Parse(Session["Admin"].ToString());
                if (!IsPostBack)
                {
                    LoadThongTin(AdminID);
                }
            }
            else
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        private void LoadThongTin(int PK_iAdminID)
        {
            admin = adminDAO.GetData(PK_iAdminID);
            lblEmail.Text = admin.SEmail;
            lblHoTen.Text = admin.SHoTen;           

            txtbHoTen.Text = lblHoTen.Text;         
        }

        protected void btnSuaTT_Click(object sender, EventArgs e)
        {
            lblHoTen.Visible = false;
           

            txtbHoTen.Visible = true;
            

            btnSuaTT.Visible = false;
            btnSua_OK.Visible = true;
            btnSua_Huy.Visible = true;

            btnDoiMK.Visible = false;
        }

        protected void btnSua_OK_Click(object sender, EventArgs e)
        {
            object[] param = new object[] { AdminID, txtbHoTen.Text };
            List<string> lsParam = new List<string>() { "@PK_iAdminID", "@sHoTen"};
            if (adminDAO.SuaTT(param, lsParam))
            {
                Response.Write("<script>alert('Sửa thông tin thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Sửa thông tin thất bại');</script>");
            }
        }

        protected void btnSua_Huy_Click(object sender, EventArgs e)
        {
            lblHoTen.Visible = true;            

            txtbHoTen.Visible = false;           

            btnSuaTT.Visible = true;
            btnSua_OK.Visible = false;
            btnSua_Huy.Visible = false;

            btnDoiMK.Visible = true;

            txtbHoTen.Text = lblHoTen.Text;           
        }

        protected void btnDoiMK_Click(object sender, EventArgs e)
        {
            DoiMK.Visible = true;
            btnDoiMK.Visible = false;
            btnDoiMK_OK.Visible = true;
            btnDoiMK_Huy.Visible = true;
        }

        protected void btnDoiMK_OK_Click(object sender, EventArgs e)
        {
            object[] param = new object[] { AdminID, EncodeMD5(txtbCurrentPassword.Text), EncodeMD5(txtbReEnterPassword.Text) };
            List<string> lsParam = new List<string>() { "@PK_iAdminID", "@sOldPassword", "@sNewPassword" };
            if (adminDAO.DoiMK(param, lsParam))
            {
                Response.Write("<script>alert('Đổi mật khẩu thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Đổi mật khẩu thất bại');</script>");
            }
        }

        protected void btnDoiMK_Huy_Click(object sender, EventArgs e)
        {
            DoiMK.Visible = false;
            btnDoiMK.Visible = true;
            btnDoiMK_OK.Visible = false;

            txtbCurrentPassword.Text = "";
            txtbNewPassword.Text = "";
            txtbReEnterPassword.Text = "";
        }

        private string EncodeMD5(string pass)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
            bs = (new MD5CryptoServiceProvider()).ComputeHash(bs);
            return BitConverter.ToString(bs).Replace("-", "").ToLower();
        }
    }
}
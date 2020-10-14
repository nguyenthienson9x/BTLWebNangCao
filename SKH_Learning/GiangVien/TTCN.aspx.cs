﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;

namespace SKH_Learning.GiangVien
{
    public partial class TTCN : System.Web.UI.Page
    {
        GiangVienDAO giangVienDAO = new GiangVienDAO();
        DTO.GiangVien giangVien = new DTO.GiangVien();
        int GiangVienID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GiangVien"].ToString() != "")
            {
                GiangVienID = int.Parse(Session["GiangVien"].ToString());
                if (!IsPostBack)
                {
                    LoadThongTin(GiangVienID);
                }
            }
            else
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        private void LoadThongTin(int PK_iGVID)
        {
            giangVien = giangVienDAO.GetData(PK_iGVID);
            lblEmail.Text = giangVien.SEmail;
            lblHoTen.Text = giangVien.SHoTen;
            lblSDT.Text = giangVien.SSDT;
            lblDiaChi.Text = giangVien.SDiaChi;
            lblNgaySinh.Text = giangVien.DNgaySinh.ToShortDateString();

            txtbHoTen.Text = lblHoTen.Text;
            txtbSDT.Text = lblSDT.Text;
            txtbDiaChi.Text = lblDiaChi.Text;
            txtbNgaySinh.Text = lblNgaySinh.Text;
        }

        protected void btnSuaTT_Click(object sender, EventArgs e)
        {
            lblHoTen.Visible = false;
            lblSDT.Visible = false;
            lblDiaChi.Visible = false;
            lblNgaySinh.Visible = false;

            txtbHoTen.Visible = true;
            txtbSDT.Visible = true;
            txtbDiaChi.Visible = true;
            txtbNgaySinh.Visible = true;

            btnSuaTT.Visible = false;
            btnSua_OK.Visible = true;
            btnSua_Huy.Visible = true;

            btnDoiMK.Visible = false;
        }

        protected void btnSua_OK_Click(object sender, EventArgs e)
        {
            object[] param = new object[] { GiangVienID, txtbHoTen.Text, txtbSDT.Text, txtbDiaChi.Text, txtbNgaySinh.Text };
            List<string> lsParam = new List<string>() { "@PK_iGVID", "@sHoTen", "@sSDT", "@sDiaChi", "@dNgaySinh" };
            if (giangVienDAO.SuaTT(param, lsParam))
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
            lblSDT.Visible = true;
            lblDiaChi.Visible = true;
            lblNgaySinh.Visible = true;

            txtbHoTen.Visible = false;
            txtbSDT.Visible = false;
            txtbDiaChi.Visible = false;
            txtbNgaySinh.Visible = false;

            btnSuaTT.Visible = true;
            btnSua_OK.Visible = false;
            btnSua_Huy.Visible = false;

            btnDoiMK.Visible = true;

            txtbHoTen.Text = lblHoTen.Text;
            txtbSDT.Text = lblSDT.Text;
            txtbDiaChi.Text = lblDiaChi.Text;
            txtbNgaySinh.Text = lblNgaySinh.Text;
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
            object[] param = new object[] { GiangVienID, EncodeMD5(txtbCurrentPassword.Text), EncodeMD5(txtbReEnterPassword.Text) };
            List<string> lsParam = new List<string>() { "@PK_iGVID", "@sOldPassword", "@sNewPassword" };
            if (giangVienDAO.DoiMK(param, lsParam))
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
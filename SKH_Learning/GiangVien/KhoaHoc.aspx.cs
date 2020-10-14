using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;
namespace SKH_Learning
{
    public partial class KhoaHoc : System.Web.UI.Page
    {
        int GVID = 1;//Ktra session
        Video video = new Video();
        VideoDAO videoDAO = new VideoDAO();
        static String IDKhoaHoc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GiangVien"].ToString().Equals(""))
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                GVID = int.Parse(Session["GiangVien"].ToString());
                if (Request.QueryString["KhoaHocID"] != null)
                {
                    IDKhoaHoc = Request.QueryString["KhoaHocID"].ToString();
                    if (!IsPostBack)
                    {
                        LoadGridView();
                    }
                    giangVienTool.Visible = false;
                }
                else
                {
                    Response.Redirect("QuanLyKhoaHoc.aspx");
                }
            }
        }

        private void LoadGridView()
        {// Phải ktra khóa này của đúng gv chưa?
            if (IDKhoaHoc != "")
            {
                grvVideo.DataKeyNames = new string[] { "iID" };
                object[] param = new object[] { IDKhoaHoc };
                List<String> listPara = new List<string>() { "@FK_iKhoaHocID" };
                grvVideo.DataSource = videoDAO.GetData(param, listPara);
                grvVideo.DataBind();
            }

        }

        protected void btnThem_OK_Click(object sender, EventArgs e)
        {
            if (videoUpload.HasFile)
            {
                string allowEx = ".mp4";
                string extension = Path.GetExtension(videoUpload.FileName);
                if (allowEx.Contains(extension))
                {                    
                    String sLink = videoUpload.FileName;
                    String sTenBaiHoc = txtbTenBaiHoc.Text.Trim().ToString();
                    String sMoTa = txtbMoTa.Text.Trim().ToString();
                    if (sTenBaiHoc.Equals("") || sMoTa.Equals(""))
                    {
                        Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin');</script>");
                    }
                    else
                    {
                        string filePath = Server.MapPath("../Data/video/" + videoUpload.FileName);
                        videoUpload.SaveAs(filePath);
                        object[] param = new object[] { sLink, sTenBaiHoc, sMoTa, IDKhoaHoc };
                        List<String> listPara = new List<string>() { "@sLink", "@sTenBaiHoc", "@sMoTa", "@FK_iKhoaHocID" };
                        int kq = videoDAO.Insert(param, listPara);
                        if (kq > 0)
                        {
                            Response.Write("<script>alert('Thêm thành công');</script>");
                            Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
                        }
                        else
                        {
                            Response.Write("<script>alert('Lỗi');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Mởi bạn tải lên file video *.mp4');</script>");
                }
            }


        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            giangVienTool.Visible = true;
            btnThem.Visible = true;
            btnSua_OK.Visible = false;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Visible = true;
            txtbMoTa.Text = "";
            txtbTenBaiHoc.Text = "";
            giangVienTool.Visible = false;
        }

        protected void grvVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            giangVienTool.Visible = true;
            btnThem.Visible = false;
            btnSua_OK.Visible = true;
            btnThem_OK.Visible = false;
            //grvVideo.DataKeyNames = new string[] { "iID" };
            int iVideoID = int.Parse(grvVideo.SelectedDataKey.Value.ToString());
            object[] param = new object[] { iVideoID, GVID };
            List<String> listPara = new List<string>() { "PK_iVideoID", "FK_iGVID" };
            List<Video> lsVideo = videoDAO.GetData(param, listPara);
            foreach (Video v in lsVideo)
            {
                if (v.IID == iVideoID)
                {
                    txtbMoTa.Text = v.SMota;
                    txtbTenBaiHoc.Text = v.STenBaiHoc;
                }
            }
        }

        protected void btnSua_OK_Click(object sender, EventArgs e)
        {
            int iVideoID = int.Parse(grvVideo.SelectedDataKey.Value.ToString());
            if (videoUpload.HasFile)
            {
                string allowEx = ".mp4";
                string extension = Path.GetExtension(videoUpload.FileName);
                if (allowEx.Contains(extension))
                {
                    
                    String sLink = videoUpload.FileName;
                    String sTenBaiHoc = txtbTenBaiHoc.Text.Trim().ToString();
                    String sMoTa = txtbMoTa.Text.Trim().ToString();
                    if (sTenBaiHoc.Equals("") || sMoTa.Equals(""))
                    {
                        Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin');</script>");
                    }
                    else
                    {
                        string filePath = Server.MapPath("../Data/video/" + videoUpload.FileName);
                        videoUpload.SaveAs(filePath);
                        object[] param = new object[] { iVideoID, sLink, sTenBaiHoc, sMoTa};
                        List<String> listPara = new List<string>() { "@PK_iVideoID", "@sLink", "@sTenBaiHoc", "@sMoTa"};
                        
                        if (videoDAO.Update(param, listPara))
                        {
                            Response.Write("<script>alert('Sửa thành công');</script>");
                            Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
                        }
                        else
                        {
                            Response.Write("<script>alert('Lỗi');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Mởi bạn tải lên file video *.mp4');</script>");
                }
            }
            else
            {
                String sTenBaiHoc = txtbTenBaiHoc.Text.Trim().ToString();
                String sMoTa = txtbMoTa.Text.Trim().ToString();
                if (sTenBaiHoc.Equals("") || sMoTa.Equals(""))
                {
                    Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin');</script>");
                }
                else
                {
                    object[] param = new object[] { iVideoID, sTenBaiHoc, sMoTa };
                    List<String> listPara = new List<string>() { "@PK_iVideoID", "@sTenBaiHoc", "@sMoTa" };
                    
                    if (videoDAO.Update(param, listPara))
                    {
                        Response.Write("<script>alert('Sửa thành công');</script>");
                        Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
                    }
                    else
                    {
                        Response.Write("<script>alert('Lỗi');</script>");
                    }
                }
            }
        }
    }
}
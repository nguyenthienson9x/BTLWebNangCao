using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;

namespace SKH_Learning
{
    public partial class KhoaHoc1 : System.Web.UI.Page
    {
        static Video video = new Video();
        static VideoDAO videoDAO = new VideoDAO();
        static KhoaHocDAO khoaHocDAO = new KhoaHocDAO();
        static CommentDAO commentDAO = new CommentDAO();
        HocDAO hocDAO = new HocDAO();
        static String KhoaHocID = "";
        static String VideoID = "";
        int iDuyet = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            sNoiDungThongbao.Visible = false;
            if (!Session["HocVien"].ToString().Equals("") || !Session["Admin"].ToString().Equals("") || !Session["GiangVien"].ToString().Equals(""))// Check đăng nhập;
            {
                if (Request.QueryString["KhoaHocID"] != null)
                {
                    KhoaHocID = Request.QueryString["KhoaHocID"].ToString();
                    if (Request.QueryString["VideoID"] != null)
                    {
                        VideoID = Request.QueryString["VideoID"].ToString();
                    }
                    else
                    {
                        VideoID = "";
                    }

                    if (!IsPostBack)
                    {
                        if (!Session["HocVien"].ToString().Equals(""))
                        {
                            iDuyet = hocDAO.Check(new object[] { int.Parse(Session["HocVien"].ToString()), int.Parse(KhoaHocID) }, new List<string>() { "@FK_iHocVienID", "@FK_iKHID" });
                            if (iDuyet == 2)
                            {
                                LoadListView();
                                LoadVideo();
                                LoadThongTinKhoaHoc();
                                LoadBinhLuan();
                            }
                            else
                            {
                                sNoiDungThongbao.Visible = true;
                                VideoTool.Visible = false;
                                BinhLuan.Visible = false;
                                NoiDungBaiHoc.Visible = false;
                                if (iDuyet == 1)
                                {
                                    sNoiDungThongbao.InnerHtml = "Chờ duyệt đăng ký, mời bạn quay lại sau";
                                    btnHuyDangKyHoc.Visible = true;
                                }
                                else if (iDuyet == 0)
                                {
                                    sNoiDungThongbao.InnerHtml = "Bạn không được học khóa học này";
                                }
                                else if (iDuyet == -1)
                                {
                                    sNoiDungThongbao.InnerHtml = "Bạn chưa đăng ký học khóa này, mời bạn đăng ký";
                                    btnDangKyHoc.Visible = true;
                                }
                            }
                        }
                        else if (!Session["Admin"].ToString().Equals("") || !Session["GiangVien"].ToString().Equals(""))
                        {
                            LoadListView();
                            LoadVideo();
                            LoadThongTinKhoaHoc();
                            LoadBinhLuan();
                        }

                    }
                }
            }
            else
            {
                VideoTool.Visible = false;
                BinhLuan.Visible = false;
                NoiDungBaiHoc.Visible = false;

                if (Request.QueryString["KhoaHocID"] != null)
                {
                    KhoaHocID = Request.QueryString["KhoaHocID"].ToString();
                    LoadThongTinKhoaHoc();
                }
                sNoiDungThongbao.Visible = true;
                sNoiDungThongbao.InnerHtml = "Bạn cần đăng nhập để có thể học bài!";

                //Response.Write("<script>alert('Vui lòng đăng nhập để sử dụng tính năng này');</script>");
                //Response.AddHeader("REFRESH", "0.1;URL='DangNhap.aspx'");
            }
        }

        private void LoadBinhLuan()
        {
            List<Comment> lsComment; /*= new List<Comment>();*/
            if (KhoaHocID != "" && VideoID == "")
            {
                object[] param = new object[] { KhoaHocID, 0 };
                List<String> listPara = new List<string>() { "@KhoaHocID", "@VideoID" };
                lsComment = commentDAO.GetData(param, listPara);
                lsVBinhLuan.DataSource = lsComment;
                lsVBinhLuan.DataBind();
            }
            else if (KhoaHocID != "" && VideoID != "")
            {
                object[] param = new object[] { KhoaHocID, VideoID };
                List<String> listPara = new List<string>() { "@KhoaHocID", "@VideoID" };
                lsComment = commentDAO.GetData(param, listPara);
                lsVBinhLuan.DataSource = lsComment;
                lsVBinhLuan.DataBind();
            }

        }

        private void LoadThongTinKhoaHoc()
        {
            if (KhoaHocID != "")
            {
                DTO.KhoaHoc khoaHoc = new DTO.KhoaHoc();
                object[] param = new object[] { KhoaHocID };
                List<String> listPara = new List<string>() { "@PK_iKhoaHocID" };
                try
                {
                    khoaHoc = khoaHocDAO.GetData(param, listPara)[0];
                    sNoiDungKhoaHoc.InnerHtml = Server.HtmlDecode(khoaHoc.SMoTa);

                    Label lblh1 = (Label)Master.FindControl("lblh1");
                    lblh1.Text = "Khóa học: " + khoaHoc.STenKhoaHoc;
                }
                catch
                {

                }

            }
        }

        private void LoadListView()
        {
            if (KhoaHocID != "")
            {
                lsVVideo.DataKeyNames = new string[] { "iID" };
                object[] param = new object[] { KhoaHocID };
                List<String> listPara = new List<string>() { "@FK_iKhoaHocID" };
                lsVVideo.DataSource = videoDAO.GetData(param, listPara);
                lsVVideo.DataBind();
            }
        }

        void LoadVideo()
        {
            String sLink = "";
            Video video;
            try
            {
                if (VideoID != "" && KhoaHocID != "")
                {
                    object[] param = new object[] { KhoaHocID, VideoID };
                    List<String> listPara = new List<string>() { "@FK_iKhoaHocID", "@PK_iVideoID" };
                    video = videoDAO.GetData(param, listPara)[0];
                    sLink = video.SLink;
                    this.Title = video.STenBaiHoc;
                    if (sLink != null)
                    {
                        videoPlayer.Src = "~/Data/video/" + sLink;
                        sNoiDungBaiHoc.InnerHtml = Server.HtmlDecode(video.SMota);
                        lblBaiHoc.Text = video.STenBaiHoc;
                    }
                }
                else if (VideoID == "" && KhoaHocID != "")
                {
                    object[] param = new object[] { KhoaHocID };
                    List<String> listPara = new List<string>() { "@FK_iKhoaHocID" };
                    video = videoDAO.GetData(param, listPara)[0];
                    VideoID = video.IID.ToString();
                    sLink = video.SLink;
                    this.Title = video.STenBaiHoc;
                    if (sLink != null)
                    {
                        videoPlayer.Src = "~/Data/video/" + sLink;
                        sNoiDungBaiHoc.InnerHtml = Server.HtmlDecode(video.SMota);
                        lblBaiHoc.Text = video.STenBaiHoc;
                    }
                }

            }
            catch { }

        }

        protected void btnBinhLuan_Click(object sender, EventArgs e)
        {
            String HocVienID = Session["HocVien"].ToString();
            String GVID = Session["GiangVien"].ToString();
            String AdminID = Session["Admin"].ToString();

            //Response.Write(HocVienID + ", " + GVID + ", " + AdminID+", VideoID: "+VideoID);

            if (VideoID == null || VideoID.Equals(""))
            {
                object[] param = new object[] { KhoaHocID };
                List<String> listPara = new List<string>() { "@FK_iKhoaHocID" };
                video = videoDAO.GetData(param, listPara)[0];
                VideoID = video.IID.ToString();
            }

            String sNoiDung = txtbBinhLuan.Text.Trim().ToString();
            if (!HocVienID.Equals(""))
            {
                object[] param = new object[] { VideoID, HocVienID, sNoiDung };
                List<string> listPara = new List<string>() { "@FK_iVideoID", "@FK_iUserID", "@sNoiDung" };
                commentDAO.Insert(param, listPara);
            }
            else if (!GVID.Equals(""))
            {
                object[] param = new object[] { VideoID, GVID, sNoiDung };
                List<string> listPara = new List<string>() { "@FK_iVideoID", "@FK_iGVID", "@sNoiDung" };
                commentDAO.Insert(param, listPara);
            }
            else
            {
                object[] param = new object[] { VideoID, AdminID, sNoiDung };
                List<string> listPara = new List<string>() { "@FK_iVideoID", "@FK_iAdminID", "@sNoiDung" };
                commentDAO.Insert(param, listPara);
            }
            txtbBinhLuan.Text = "";
            Response.Redirect(Request.RawUrl);
        }

        static Video videoAjax = new Video();


        [WebMethod(EnableSession = true)]
        public static bool Comment(String sNoiDung)
        {
            HttpContext context = HttpContext.Current;
            String HocVienID = context.Session["HocVien"].ToString();
            String GVID = context.Session["GiangVien"].ToString();
            String AdminID = context.Session["Admin"].ToString();
            if (VideoID == null || VideoID.Equals(""))
            {
                object[] param = new object[] { KhoaHocID };
                List<String> listPara = new List<string>() { "@FK_iKhoaHocID" };
                video = videoDAO.GetData(param, listPara)[0];
                VideoID = video.IID.ToString();
            }
            
            if (!HocVienID.Equals(""))
            {
                object[] param = new object[] { VideoID, HocVienID, sNoiDung };
                List<string> listPara = new List<string>() { "@FK_iVideoID", "@FK_iUserID", "@sNoiDung" };
                return commentDAO.Insert(param, listPara);
            }
            else if (!GVID.Equals(""))
            {
                object[] param = new object[] { VideoID, GVID, sNoiDung };
                List<string> listPara = new List<string>() { "@FK_iVideoID", "@FK_iGVID", "@sNoiDung" };
                return commentDAO.Insert(param, listPara);
            }
            else
            {
                object[] param = new object[] { VideoID, AdminID, sNoiDung };
                List<string> listPara = new List<string>() { "@FK_iVideoID", "@FK_iAdminID", "@sNoiDung" };
                return commentDAO.Insert(param, listPara);
            }            
        }

        protected void lsVBinhLuan_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblTenNguoiDangNhap;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                lblTenNguoiDangNhap = (Label)e.Item.FindControl("lblTenNguoiBL");
                if (lblTenNguoiDangNhap.Text.Contains("GV"))
                {
                    //Chỉnh màu...                    
                }
            }
        }

        protected void btnDangKyHoc_Click(object sender, EventArgs e)
        {
            bool kq = hocDAO.Insert(new object[] { int.Parse(Session["HocVien"].ToString()), int.Parse(KhoaHocID) }, new List<string>() { "@FK_iHocVienID", "@FK_iKHID" });
            if (kq == true)
            {
                Response.Write("<script>alert('Đã đăng ký, chờ duyệt');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
        }

        protected void btnHuyDangKyHoc_Click(object sender, EventArgs e)
        {
            bool kq = hocDAO.HuyDangKy(new object[] { int.Parse(Session["HocVien"].ToString()), int.Parse(KhoaHocID) }, new List<string>() { "@FK_iHocVienID", "@FK_iKHID" });
            if (kq == true)
            {
                Response.Write("<script>alert('Đã hủy đăng ký');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
        }
    }
}
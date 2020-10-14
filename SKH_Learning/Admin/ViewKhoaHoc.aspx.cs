using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;

namespace SKH_Learning.Admin
{
    public partial class ViewKhoaHoc : System.Web.UI.Page
    {
        Video video = new Video();
        VideoDAO videoDAO = new VideoDAO();
        KhoaHocDAO khoaHocDAO = new KhoaHocDAO();
        CommentDAO commentDAO = new CommentDAO();
        HocDAO hocDAO = new HocDAO();
        static String KhoaHocID = "";
        static String VideoID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["Admin"].ToString().Equals(""))
            {
                if (Request.QueryString["ID"] != null)
                {
                    KhoaHocID = Request.QueryString["ID"].ToString();
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
                        LoadListView();
                        LoadVideo();
                        LoadThongTinKhoaHoc();
                    }
                }
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
                    }
                }

            }
            catch { }

        }
    }
}
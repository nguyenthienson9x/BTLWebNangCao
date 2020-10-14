using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace SKH_Learning.Admin
{
    public partial class DuyetKhoaHoc : System.Web.UI.Page
    {
        KhoaHocDAO khoaHocDAO = new KhoaHocDAO();
        int iDUYET = 2;
        int iCHODUYET = 1;
        int iTUCHOI = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"].ToString().Equals(""))
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    lblTrangThai.InnerText = "Danh sách các khóa học chờ duyệt";
                    object[] param = new object[] { iCHODUYET };
                    List<string> lsParam = new List<string>() { "@iDuyet" };
                    LoadGridView(param, lsParam);
                }
            }
        }

        private void LoadGridView(object[] param, List<string> lsParam)
        {
            grvKhoaHoc.DataKeyNames = new string[] { "iID" };
            grvKhoaHoc.DataSource = khoaHocDAO.GetData(param, lsParam);
            grvKhoaHoc.DataBind();
        }

        protected void btnXemTatCa_Click(object sender, EventArgs e)
        {
            lblTrangThai.InnerText = "Danh sách khóa học!";
            LoadGridView(null, null);
            btnXemTatCa.Visible = false;
            btnXemDeDuyet.Visible = true;
        }

        protected void btnXemDeDuyet_Click(object sender, EventArgs e)
        {
            lblTrangThai.InnerText = "Danh sách các khóa học chờ duyệt";
            object[] param = new object[] { iCHODUYET };
            List<string> lsParam = new List<string>() { "@iDuyet" };
            LoadGridView(param, lsParam);
            btnXemTatCa.Visible = true;
            btnXemDeDuyet.Visible = false;
        }

        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            String iKhoaHocID = ((Button)sender).CommandArgument.ToString();

            object[] param = new object[] { iKhoaHocID, iDUYET };
            List<string> listParam = new List<string>() { "@PK_iKhoaHocID", "@iDuyet" };
            if (khoaHocDAO.Duyet(param, listParam))
            {
                Response.Write("<script>alert('Duyệt!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Thất bại! Vui lòng kiểm tra đường truyền')</script>");
            }
        }

        protected void btnTuChoi_Click(object sender, EventArgs e)
        {
            String iKhoaHocID = ((Button)sender).CommandArgument.ToString();

            object[] param = new object[] { iKhoaHocID, iTUCHOI };
            List<string> listParam = new List<string>() { "@PK_iKhoaHocID", "@iDuyet" };
            if (khoaHocDAO.Duyet(param, listParam))
            {
                Response.Write("<script>alert('Đã từ chối!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Thất bại! Vui lòng kiểm tra đường truyền')</script>");
            }
        }

        protected void grvKhoaHoc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTrangThai = (Label)e.Row.FindControl("lblTrangThai");
                Button btnDuyet = (Button)e.Row.FindControl("btnDuyet");
                Button btnTuChoi = (Button)e.Row.FindControl("btnTuChoi");
                int Duyet = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "iDuyet"));
                switch (Duyet)
                {
                    case 0:
                        lblTrangThai.Text = "Đã từ chối!";
                        btnDuyet.Visible = false;
                        btnTuChoi.Visible = false;
                        break;
                    case 1:
                        lblTrangThai.Text = "Chờ duyệt";
                        break;
                    case 2:
                        lblTrangThai.Text = "Đã duyệt!";
                        btnDuyet.Visible = false;
                        btnTuChoi.Visible = false;
                        break;
                }
            }
        }
    }
}
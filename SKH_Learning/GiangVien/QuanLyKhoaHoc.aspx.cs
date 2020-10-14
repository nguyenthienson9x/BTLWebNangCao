using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;
using Newtonsoft.Json;

namespace SKH_Learning.GiangVien
{
    public partial class QuanLyKhoaHoc : System.Web.UI.Page
    {
        int GVID = 1;

        SubCategoryDAO subCategoryDAO = new SubCategoryDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        KhoaHocDAO khoaHocDAO = new KhoaHocDAO();
        List<DTO.KhoaHoc> lsKhoaHoc = new List<DTO.KhoaHoc>();
        List<SubCategory> subCategories = new List<SubCategory>();
        List<Category> categories = new List<Category>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GiangVien"].ToString().Equals(""))
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                GVID = int.Parse(Session["GiangVien"].ToString());
                LoadListCategory();
                if (!IsPostBack)
                {
                    LoadGridView();
                    LoadDDLCategory();
                    DDLCategory_SelectedIndexChanged(sender, e);
                    giangVienTool.Visible = false;
                }
            }
        }

        private void LoadDDLCategory()
        {
            DDLCategory.DataSource = categories;
            DDLCategory.DataTextField = "SCategory";
            DDLCategory.DataValueField = "IID";
            DDLCategory.DataBind();
        }

        private void LoadGridView()
        {

            object[] para = new object[] { GVID };
            List<String> listPara = new List<string>() { "@FK_iGVID" };
            grvQLKhoaHoc.DataKeyNames = new string[] { "iID" };

            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"] != "")
                {
                    listPara.Add("@FK_iCategoryID");
                    para = new object[] { GVID, Request.QueryString["ID"] };
                }

            }
            else if (Request.QueryString["SubID"] != null)
            {
                if (Request.QueryString["SubID"] != "")
                {
                    listPara.Add("@FK_iSubID");
                    para = new object[] { GVID, Request.QueryString["SubID"] };
                }
            }
            lsKhoaHoc = khoaHocDAO.GetData(para, listPara);
            grvQLKhoaHoc.DataSource = lsKhoaHoc;
            grvQLKhoaHoc.DataBind();
        }

        private void LoadListCategory()
        {
            subCategories.Clear();
            categories.Clear();

            subCategories = subCategoryDAO.GetData(null, null);
            categories = categoryDAO.GetData(null, null);
        }

        protected void grvQLKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            object[] para = new object[] { GVID };
            List<String> listPara = new List<string>() { "@FK_iGVID" };
            grvQLKhoaHoc.DataKeyNames = new string[] { "iID" };
            lsKhoaHoc = khoaHocDAO.GetData(para, listPara);
            foreach (DTO.KhoaHoc kh in lsKhoaHoc)
            {
                if (kh.IID == int.Parse(grvQLKhoaHoc.SelectedDataKey.Value.ToString()))
                {
                    txtbKhoaHoc.Text = kh.STenKhoaHoc;
                    //txtbMoTa.Text = kh.SMoTa;
                    txtbMoTa.InnerHtml = kh.SMoTa;
                    LoadDDLSub();
                    DDLSubCategory.SelectedValue = kh.FK_SubID.ToString();
                    
                    foreach (SubCategory s in subCategories)
                    {
                        if (s.IID.ToString() == kh.FK_SubID.ToString())
                        {
                            DDLCategory.SelectedValue = s.IID_Category.ToString();
                            break;
                        }
                    }
                    break;
                }
            }

            giangVienTool.Visible = true;
            btnSuaOK.Visible = true;
            btnThemOK.Visible = false;
        }

        void LoadDDLSub()
        {
            DDLSubCategory.DataSource = subCategories;
            DDLSubCategory.DataTextField = "SSubCategory";
            DDLSubCategory.DataValueField = "IID";
            DDLSubCategory.DataBind();
        }

        protected void DDLCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<SubCategory> subs = new List<SubCategory>();
            foreach (SubCategory s in subCategories)
            {
                if (int.Parse(DDLCategory.SelectedValue) == s.IID_Category)
                {
                    subs.Add(s);
                }

            }
            DDLSubCategory.DataSource = subs;
            DDLSubCategory.DataTextField = "SSubCategory";
            DDLSubCategory.DataValueField = "IID";
            DDLSubCategory.DataBind();
        }

        protected void btnThemOK_Click(object sender, EventArgs e)
        {
            if (imgUpload.HasFile)
            {
                string allowEx = ".jpg .png .gif .tiff .bmp";
                string extension = Path.GetExtension(imgUpload.FileName);
                if (allowEx.Contains(extension))
                {
                    String sTenKhoaHoc = txtbKhoaHoc.Text.Trim().ToString();
                    String sImgLink = imgUpload.FileName;
                    String sMoTa = Server.HtmlDecode(txtbMoTa.InnerHtml.Trim().ToString());
                    int FK_iSubID = int.Parse(DDLSubCategory.SelectedValue.ToString());
                    int FK_iGVID = GVID;
                    if (sTenKhoaHoc.Equals("") || sMoTa.Equals("") || DDLSubCategory.SelectedIndex < 0)
                    {
                        Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin');</script>");
                    }
                    else
                    {
                        string filePath = Server.MapPath("../Data/img/KhoaHoc/" + imgUpload.FileName);
                        imgUpload.SaveAs(filePath);
                        object[] param = new object[] { sTenKhoaHoc, sImgLink, sMoTa, FK_iSubID, FK_iGVID };
                        List<String> listPara = new List<string>() { "@sTenKhoaHoc", "@sImgLink", "@sMoTa", "@FK_iSubCategoryID", "@FK_iGVID" };
                        int kq = khoaHocDAO.Insert(param, listPara);
                        Response.Write("kq: " + kq);
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
                    Response.Write("<script>alert('Mởi bạn tải lên file ảnh *.jpg, png, gif, tiff, bmp');</script>");
                }
            }

        }

        protected void tbnThemKhoaHoc_Click(object sender, EventArgs e)
        {
            /*
            if (Request.QueryString["ID"] == null && Request.QueryString["SubID"] == null)//Hiden Feature
            {

            }
            else if (Request.QueryString["ID"] != null && Request.QueryString["SubID"] == null)
            {
                LoadDDLCategory();
                DDLCategory.SelectedValue = Request.QueryString["ID"].ToString();
                DDLCategory_SelectedIndexChanged(sender, e);


            }
            else if (Request.QueryString["SubID"] != null)
            {
                LoadDDLSub();
                foreach (SubCategory subCategory in subCategories)
                {
                    if (subCategory.IID == int.Parse(Request.QueryString["SubID"].ToString()))
                    {
                        foreach (Category category in categories)
                        {
                            if (subCategory.IID_Category == category.IID)
                            {
                                LoadDDLCategory();
                                DDLCategory.SelectedValue = category.IID.ToString();
                                DDLCategory_SelectedIndexChanged(sender, e);
                                //Response.Write("<script>alert('" + category.IID + Request.QueryString["SubID"].ToString() + "')</script>");
                                DDLSubCategory.SelectedValue = Request.QueryString["SubID"].ToString();
                                break;                                  
                            }
                        }
                        break;
                    }
                }

            }*/

            txtbMoTa.InnerHtml = "";
            giangVienTool.Visible = true;
            btnSuaOK.Visible = false;
            btnThemOK.Visible = true;
            //Cái này sẽ dùng 


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtbKhoaHoc.Text = "";
            txtbMoTa.InnerHtml = "";
            DDLCategory.SelectedIndex = 0;
            DDLSubCategory.SelectedIndex = 0;
            giangVienTool.Visible = false;
        }

        protected void btnSuaOK_Click(object sender, EventArgs e)
        {
            int iKhoaHocID = int.Parse(grvQLKhoaHoc.SelectedDataKey.Value.ToString());
            if (imgUpload.HasFile)
            {
                string allowEx = ".jpg .png .gif .tiff .bmp";
                string extension = Path.GetExtension(imgUpload.FileName);
                if (allowEx.Contains(extension))
                {
                    String sTenKhoaHoc = txtbKhoaHoc.Text.Trim().ToString();
                    String sImgLink = imgUpload.FileName;
                    //String sMoTa = txtbMoTa.Text.Trim().ToString();
                    String sMoTa = Server.HtmlDecode(txtbMoTa.InnerHtml);
                    int FK_iSubID = int.Parse(DDLSubCategory.SelectedValue.ToString());
                    int FK_iGVID = GVID;
                    if (sTenKhoaHoc.Equals("") || sMoTa.Equals("") || DDLSubCategory.SelectedIndex < 0)
                    {
                        Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin');</script>");
                    }
                    else
                    {
                        string filePath = Server.MapPath("../Data/img/KhoaHoc/" + imgUpload.FileName);
                        imgUpload.SaveAs(filePath);
                        object[] param = new object[] { iKhoaHocID, sTenKhoaHoc, sImgLink, sMoTa, FK_iSubID };
                        List<String> listPara = new List<string>() { "@PK_iKhoaHocID", "@sTenKhoaHoc", "@sImgLink", "@sMoTa", "@FK_iSubCategoryID" };

                        if (khoaHocDAO.Update(param, listPara))
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
                    Response.Write("<script>alert('Mởi bạn tải lên file ảnh *.jpg, png, gif, tiff, bmp');</script>");
                }
            }
            else
            {
                String sTenKhoaHoc = txtbKhoaHoc.Text.Trim().ToString();
                //String sMoTa = txtbMoTa.Text.Trim().ToString();
                String sMoTa = Server.HtmlDecode(txtbMoTa.InnerHtml);

                int FK_iSubID = int.Parse(DDLSubCategory.SelectedValue.ToString());
                int FK_iGVID = GVID;
                if (sTenKhoaHoc.Equals("") || sMoTa.Equals("") || DDLSubCategory.SelectedIndex < 0)
                {
                    Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin');</script>");
                }
                else
                {
                    Response.Write("ID: " + iKhoaHocID + ", " + sTenKhoaHoc.ToString() + ", " + sMoTa.ToString() + ", " + FK_iGVID + ", " + FK_iSubID);
                    object[] param = new object[] { iKhoaHocID, sTenKhoaHoc, sMoTa, FK_iSubID };
                    List<String> listPara = new List<string>() { "@PK_iKhoaHocID", "@sTenKhoaHoc", "@sMoTa", "@FK_iSubCategoryID" };

                    if (khoaHocDAO.Update(param, listPara))
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

        protected void grvQLKhoaHoc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTrangThai = (Label)e.Row.FindControl("lblTrangThai");
                int Duyet = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "iDuyet"));
                switch (Duyet)
                {
                    case 0:
                        lblTrangThai.Text = "Không được duyệt!";
                        break;
                    case 1:
                        lblTrangThai.Text = "Chờ duyệt";
                        break;
                    case 2:
                        lblTrangThai.Text = "Đã được duyệt!";
                        break;
                }
            }
        }


        [WebMethod]
        public static string LoadCate()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            return JsonConvert.SerializeObject(categoryDAO.GetData(null, null));            
        }
        [WebMethod]
        public static string LoadSubCate()
        {
            SubCategoryDAO subcategoryDAO = new SubCategoryDAO();
            return JsonConvert.SerializeObject(subcategoryDAO.GetData(null, null));
        }
    }
}
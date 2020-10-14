using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;
using Newtonsoft.Json;
namespace SKH_Learning
{
    public partial class TimKiem : System.Web.UI.Page
    {
        static KhoaHocDAO khoaHocDAO = new KhoaHocDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Search"] != null)
            {
                String Search = Request.QueryString["Search"].ToString();
                LoadListViewKhoaHoc(Search);
            }
        }

        private void LoadListViewKhoaHoc(String TimKiem)
        {
            object[] param = new object[] { TimKiem };
            List<string> listParam = new List<string>() { "sTenKhoaHoc" };
            List<DTO.KhoaHoc> lsKhoaHoc = new List<DTO.KhoaHoc>();
            lsKhoaHoc = khoaHocDAO.TimKiem(param, listParam);
            lsVKhoaHoc.DataSource = lsKhoaHoc;
            lsVKhoaHoc.DataBind();
            if(lsKhoaHoc.Count == 0)
            {
                lblThongBao.Visible = true;
            }
            else
            {
                lblThongBao.Visible = false;
            }            
        }

        [WebMethod]
        public static string Search(String TimKiem)
        {
            object[] param = new object[] { TimKiem };
            List<string> lsParam = new List<string>() { "@sTenKhoaHoc" };
            
            //HttpContext.Current.Response.Write("Nội dung return: " + JsonConvert.SerializeObject(dt) + "\n****\n");
            List<DTO.KhoaHoc> lsKhoaHoc = new List<DTO.KhoaHoc>();
            lsKhoaHoc = khoaHocDAO.TimKiem(param, lsParam);
            if (lsKhoaHoc.Count>0){
                var result = JsonConvert.SerializeObject(lsKhoaHoc);                
                return result;
            }
            else
            {
                return "false";
            }
        }
    }
}
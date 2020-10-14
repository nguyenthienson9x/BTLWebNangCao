using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KhoaHocDAO
    {
        DataProvider dataProvider = new DataProvider();

        public List<KhoaHoc> GetData(object[] param, List<string> listParam)
        {
            List<KhoaHoc> lsKhoaHoc = new List<KhoaHoc>();
            DataTable dt = dataProvider.ExecuteQuery("sp_KhoaHoc_GetData", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int ID = int.Parse(row["PK_iKhoaHocID"].ToString());
                    String sTenKhoaHoc = row["sTenKhoaHoc"].ToString();
                    String sImgLink = row["sImgLink"].ToString();
                    String sMoTa = row["sMoTa"].ToString();
                    DateTime dNgayKhoiTao = Convert.ToDateTime(row["dNgayKhoiTao"].ToString());
                    DateTime dUpdateTime = Convert.ToDateTime(row["dUpdateTime"].ToString());
                    int FK_SubID = int.Parse(row["FK_iSubCategoryID"].ToString());
                    String sSub = row["sSubCategory"].ToString();
                    int FK_GVID = int.Parse(row["FK_iGVID"].ToString());
                    String sHoTen = row["sHoTen"].ToString();
                    int iDuyet = int.Parse(row["iDuyet"].ToString());
                    int FK_CateID = int.Parse(row["PK_iID"].ToString());
                    String sCate = row["sCategory"].ToString();
                    lsKhoaHoc.Add(new KhoaHoc(ID, sTenKhoaHoc, sImgLink, sMoTa, dNgayKhoiTao, dUpdateTime, FK_SubID, sSub, FK_GVID, sHoTen, iDuyet, FK_CateID, sCate));
                }
            }
            return lsKhoaHoc;
        }

        public int Insert(object[] param, List<string> listParam)
        {
            string rs = dataProvider.ExecuteScalar("sp_KhoaHoc_Insert", param, listParam);
            if (int.TryParse(rs, out int kq))
            {
                return kq;
            }
            else
                return 0;
        }

        public bool Update(object[] param, List<string> listPara)
        {
            int rs = dataProvider.ExecuteNonQuery("sp_KhoaHoc_Update", param, listPara);
            if (rs > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Duyet(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_KhoaHoc_Duyet", param, listParam);
            if (kq > 0)
                return true;
            else
                return false;
        }

        public List<KhoaHoc> TimKiem(object[] param, List<string> listParam)
        {
            List<KhoaHoc> lsKhoaHoc = new List<KhoaHoc>();
            DataTable dt = dataProvider.ExecuteQuery("sp_KhoaHoc_TimKiem", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int ID = int.Parse(row["PK_iKhoaHocID"].ToString());
                    String sTenKhoaHoc = row["sTenKhoaHoc"].ToString();
                    String sImgLink = row["sImgLink"].ToString();
                    String sMoTa = row["sMoTa"].ToString();
                    DateTime dNgayKhoiTao = Convert.ToDateTime(row["dNgayKhoiTao"].ToString());
                    DateTime dUpdateTime = Convert.ToDateTime(row["dUpdateTime"].ToString());
                    int FK_SubID = int.Parse(row["FK_iSubCategoryID"].ToString());
                    String sSub = row["sSubCategory"].ToString();
                    int FK_GVID = int.Parse(row["FK_iGVID"].ToString());
                    String sHoTen = row["sHoTen"].ToString();
                    int iDuyet = int.Parse(row["iDuyet"].ToString());
                    int FK_CateID = int.Parse(row["PK_iID"].ToString());
                    String sCate = row["sCategory"].ToString();
                    lsKhoaHoc.Add(new KhoaHoc(ID, sTenKhoaHoc, sImgLink, sMoTa, dNgayKhoiTao, dUpdateTime, FK_SubID, sSub, FK_GVID, sHoTen, iDuyet, FK_CateID, sCate));
                }
            }
            return lsKhoaHoc;
        }

    }
}

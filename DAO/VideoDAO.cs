using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class VideoDAO
    {
        DataProvider dataProvider = new DataProvider();

        public List<Video> GetData(object[] param, List<string> listParam)
        {
            List<Video> lsVideo = new List<Video>();
            DataTable dt = dataProvider.ExecuteQuery("sp_Video_GetData", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    int ID = int.Parse(r["PK_iVideoID"].ToString());
                    String sLink = r["sLink"].ToString();
                    String sTenBaiHoc = r["sTenBaiHoc"].ToString();
                    String sMoTa = r["sMoTa"].ToString();
                    DateTime dNgayUpload = Convert.ToDateTime(r["dNgayUpload"].ToString());
                    int fk_iKHID = int.Parse(r["FK_iKhoaHocID"].ToString());
                    String sTenKhoaHoc = r["sTenKhoaHoc"].ToString();
                    int fk_iGVID = int.Parse(r["FK_iGVID"].ToString());
                    String sHoTenGV = r["sHoTen"].ToString();
                    lsVideo.Add(new Video(ID, sLink, sTenBaiHoc, sMoTa, dNgayUpload, fk_iKHID, sTenKhoaHoc, fk_iGVID, sHoTenGV));
                }
            }
            return lsVideo;
        }

        public int Insert(object[] param, List<string> listParam)
        {
            string kq = dataProvider.ExecuteScalar("sp_Video_Insert", param, listParam);
            if (int.TryParse(kq, out int rs))
            {
                return rs;
            }
            else
                return 0;
        }

        public bool Update(object[] param, List<string> listPara)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_Video_Update", param, listPara);
            if (kq > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}

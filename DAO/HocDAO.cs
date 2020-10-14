using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class HocDAO
    {
        DataProvider dataProvider = new DataProvider();
        public int Check(object[] param, List<string> listParam)
        {
            String kq = dataProvider.ExecuteScalar("sp_Hoc_Check", param, listParam);
            if (int.TryParse(kq, out int rs))
            {
                return rs;
            }
            else
                return -1;
        }

        public bool Insert(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_Hoc_Insert", param, listParam);
            if (kq > 0)
                return true;
            else
                return false;
        }

        public bool HuyDangKy(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_Hoc_Del", param, listParam);
            if (kq > 0)
                return true;
            else
                return false;
        }

		public List<Hoc> GetData(object[] param, List<string> listParam)
		{
			List<Hoc> lsHoc = new List<Hoc>();
			DataTable dt = dataProvider.ExecuteQuery("sp_Hoc_GetData", param, listParam);
			foreach(DataRow row in dt.Rows)
			{
				int ID = int.Parse(row["PK_iHocID"].ToString());
				int FK_iHocVienID = int.Parse(row["FK_iHocVienID"].ToString());
				int FK_iKhoaHocID = int.Parse(row["FK_iKhoaHocID"].ToString());
				String sHoTen = row["sHoTen"].ToString();
				String sTenKhoaHoc = row["sTenKhoaHoc"].ToString();
				int Duyet = int.Parse(row["iDuyet"].ToString());
				lsHoc.Add(new Hoc(ID, FK_iHocVienID, FK_iKhoaHocID, Duyet, sHoTen, sTenKhoaHoc));
			}
			return lsHoc;
		}

		public bool Duyet(object[] param, List<string> listParam)
		{
			int kq = dataProvider.ExecuteNonQuery("sp_Hoc_Duyet", param, listParam);
			if (kq > 0)
				return true;
			else
				return false;
		}

	}
}

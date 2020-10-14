using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class GiangVienDAO
    {
        DataProvider dataProvider = new DataProvider();

        public int DangNhap(object[] param, List<string> listParam)
        {
            List<HocVien> lsHocVien = new List<HocVien>();
            DataTable dt = dataProvider.ExecuteQuery("sp_GiangVien_DangNhap", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            else
                return 0;
        }

        public String GetTen(int GVID)
        {
            String ten = dataProvider.ExecuteScalar("sp_GiangVien_GetTen", new object[] { GVID }, new List<string>() { "PK_iGVID" });
            return ten;
        }

        public List<GiangVien> GetData(object[] param, List<string> listParam)
        {
            List<GiangVien> lsGV = new List<GiangVien>();
            /*Chưa viết, về nhà viết đi!!*/
            return lsGV;
        }

        public bool Insert(object[] param, List<string> listParam)
        {
            int Inserted = dataProvider.ExecuteNonQuery("sp_GiangVien_Insert", param, listParam);
            if (Inserted != 0)
                return true;
            else
                return false;
        }


        public GiangVien GetData(int PK_iGVID)
        {
            GiangVien giangVien = new GiangVien();
            DataTable dt = dataProvider.ExecuteQuery("sp_GiangVien_GetData", new object[] { PK_iGVID }, new List<string>() { "@PK_iGVID" });
            if (dt != null && dt.Rows.Count > 0)
            {
                int ID = int.Parse(dt.Rows[0]["PK_iGVID"].ToString());
                String HoTen = dt.Rows[0]["sHoTen"].ToString();
                String SDT = dt.Rows[0]["sSDT"].ToString();
                String DiaChi = dt.Rows[0]["sDiaChi"].ToString();
                DateTime NgaySinh = Convert.ToDateTime(dt.Rows[0]["dNgaySinh"].ToString());
                String Email = dt.Rows[0]["sEmail"].ToString();

                giangVien.IID = ID;
                giangVien.SHoTen = HoTen;
                giangVien.SSDT = SDT;
                giangVien.SDiaChi = DiaChi;
                giangVien.DNgaySinh = NgaySinh;
                giangVien.SEmail = Email;
                giangVien.SPassword = "";
            }
            return giangVien;
        }
        public bool SuaTT(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_GiangVien_Update", param, listParam);
            if (kq != 0)
                return true;
            else
                return false;
        }

        public bool DoiMK(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_GiangVien_ChangePass", param, listParam);
            if (kq != 0)
                return true;
            else
                return false;
        }
    }
}

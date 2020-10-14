using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HocVienDAO
    {
        DataProvider dataProvider = new DataProvider();
        public bool DangKy(object[] param, List<string> listParam)
        {
            List<HocVien> lsHocVien = new List<HocVien>();
            int Inserted = dataProvider.ExecuteNonQuery("sp_HocVien_DangKy", param, listParam);
            if (Inserted != 0)
                return true;
            else
                return false;
        }

        public String GetTen(int HocVienID)
        {
            String ten = dataProvider.ExecuteScalar("sp_HocVien_GetTen", new object[] { HocVienID }, new List<string>() { "PK_iHocVienID" });
            return ten;
        }
        public int DangNhap(object[] param, List<string> listParam)
        {
            List<HocVien> lsHocVien = new List<HocVien>();
            DataTable dt = dataProvider.ExecuteQuery("sp_HocVien_DangNhap", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            else
                return 0;
        }

        public bool CheckMail(string sEmail)
        {
            int kq = int.Parse(dataProvider.ExecuteScalar("sp_HocVien_CheckMail", new object[] { sEmail }, new List<string>() { "@sEmail" }));
            if (kq != 0)
            {
                return false;
            }
            else
                return true;
        }

        public HocVien GetData(int PK_iHocVienID)
        {
            HocVien hocVien = new HocVien();
            DataTable dt = dataProvider.ExecuteQuery("sp_HocVien_GetData", new object[] { PK_iHocVienID }, new List<string>() { "@PK_iHocVienID" });
            if (dt != null && dt.Rows.Count > 0)
            {
                int ID = int.Parse(dt.Rows[0]["PK_iHocVienID"].ToString());
                String HoTen = dt.Rows[0]["sHoTen"].ToString();
                String SDT = dt.Rows[0]["sSDT"].ToString();
                String DiaChi = dt.Rows[0]["sDiaChi"].ToString();
                DateTime NgaySinh = Convert.ToDateTime(dt.Rows[0]["dNgaySinh"].ToString());
                String Email = dt.Rows[0]["sEmail"].ToString();

                hocVien.IID = ID;
                hocVien.SHoTen = HoTen;
                hocVien.SSDT = SDT;
                hocVien.SDiaChi = DiaChi;
                hocVien.DNgaySinh = NgaySinh;
                hocVien.SEmail = Email;
                hocVien.SPassword = "";
            }
            return hocVien;
        }
        public bool SuaTT(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_HocVien_Update", param, listParam);
            if (kq != 0)
                return true;
            else
                return false;
        }

        public bool DoiMK(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_HocVien_ChangePass", param, listParam);
            if (kq != 0)
                return true;
            else
                return false;
        }
    }
}

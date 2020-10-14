using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class AdminDAO
    {
        DataProvider dataProvider = new DataProvider();
        public int DangNhap(object[] param, List<string> listParam)
        {
            List<HocVien> lsHocVien = new List<HocVien>();
            DataTable dt = dataProvider.ExecuteQuery("sp_Admin_DangNhap", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            else
                return 0;
        }

        public Admin GetData(int PK_iAdminID)
        {
            Admin admin = new Admin();
            DataTable dt = dataProvider.ExecuteQuery("sp_Admin_GetData", new object[] { PK_iAdminID }, new List<string>() { "@PK_iAdminID" });
            if (dt != null && dt.Rows.Count > 0)
            {
                int ID = int.Parse(dt.Rows[0]["PK_iAdminID"].ToString());
                String HoTen = dt.Rows[0]["sHoTen"].ToString();
                String Email = dt.Rows[0]["sEmail"].ToString();

                admin.ID1 = ID;
                admin.SHoTen = HoTen;
                admin.SEmail = Email;
            }
            return admin;
        }
        public bool SuaTT(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_Admin_Update", param, listParam);
            if (kq != 0)
                return true;
            else
                return false;
        }

        public bool DoiMK(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_Admin_ChangePass", param, listParam);
            if (kq != 0)
                return true;
            else
                return false;
        }


    }
}

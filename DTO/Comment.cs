using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Comment
    {
        int iID;
        int fk_iVideoID;
        int fk_iKHID;
        int fk_iUserID;
        int fK_iGVID;
        int fk_iAdminID;
        String sHoTen;
        String sNoiDung;
        DateTime dNgay;

        public Comment(int iID, int fk_iVideoID, int fk_iKHID, int fk_iUserID, int fK_iGVID, int fk_iAdminID, string sHoTen, string sNoiDung, DateTime dNgay)
        {
            this.iID = iID;
            this.fk_iVideoID = fk_iVideoID;
            this.fk_iKHID = fk_iKHID;
            this.fk_iUserID = fk_iUserID;
            this.fK_iGVID = fK_iGVID;
            this.fk_iAdminID = fk_iAdminID;
            this.SHoTen = sHoTen;
            this.sNoiDung = sNoiDung;
            this.dNgay = dNgay;
        }

        public int IID { get => iID; set => iID = value; }
        public int Fk_iVideoID { get => fk_iVideoID; set => fk_iVideoID = value; }
        public int Fk_iKHID { get => fk_iKHID; set => fk_iKHID = value; }
        public int Fk_iUserID { get => fk_iUserID; set => fk_iUserID = value; }
        public int FK_iGVID { get => fK_iGVID; set => fK_iGVID = value; }
        public int Fk_iAdminID { get => fk_iAdminID; set => fk_iAdminID = value; }
        public string SNoiDung { get => sNoiDung; set => sNoiDung = value; }
        public DateTime DNgay { get => dNgay; set => dNgay = value; }
        public string SHoTen { get => sHoTen; set => sHoTen = value; }
    }
}

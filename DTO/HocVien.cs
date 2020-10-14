using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocVien
    {
        int iID;
        String sHoTen;
        String sSDT;
        String sDiaChi;
        DateTime dNgaySinh;
        String sImgLink;
        String sEmail;
        String sPassword;

        public int IID { get => iID; set => iID = value; }
        public string SHoTen { get => sHoTen; set => sHoTen = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public DateTime DNgaySinh { get => dNgaySinh; set => dNgaySinh = value; }
        public string SImgLink { get => sImgLink; set => sImgLink = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
        public string SPassword { get => sPassword; set => sPassword = value; }

        public HocVien(int iID, string sHoTen, string sSDT, string sDiaChi, DateTime dNgaySinh, string sImgLink, string sEmail, string sPassword)
        {
            this.iID = iID;
            this.sHoTen = sHoTen;
            this.sSDT = sSDT;
            this.sDiaChi = sDiaChi;
            this.dNgaySinh = dNgaySinh;
            this.sImgLink = sImgLink;
            this.sEmail = sEmail;
            this.sPassword = sPassword;
        }

        public HocVien()
        {
        }
    }
}

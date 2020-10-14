using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiangVien
    {
        int iID;
        String sHoTen;
        String sDiaChi;
        String sSDT;
        DateTime dNgaySinh;
        String sImgLink;
        String sEmail;
        String sPassword;

        public GiangVien()
        {
        }

        public GiangVien(int iID, string sHoTen, string sDiaChi, string sSDT, DateTime dNgaySinh, string sImgLink, string sEmail, string sPassword)
        {
            this.IID = iID;
            this.SHoTen = sHoTen;
            this.SDiaChi = sDiaChi;
            this.SSDT = sSDT;
            this.DNgaySinh = dNgaySinh;
            this.SImgLink = sImgLink;
            this.SEmail = sEmail;
            this.SPassword = sPassword;
        }

        public int IID { get => iID; set => iID = value; }
        public string SHoTen { get => sHoTen; set => sHoTen = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
        public DateTime DNgaySinh { get => dNgaySinh; set => dNgaySinh = value; }
        public string SImgLink { get => sImgLink; set => sImgLink = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
        public string SPassword { get => sPassword; set => sPassword = value; }
    }
}

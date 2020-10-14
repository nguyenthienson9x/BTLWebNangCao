using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Video
    {
        int iID;
        String sLink;
        String sTenBaiHoc;
        String sMota;
        DateTime dNgayUpload;
        int fk_iKhoaHocID;
        String sTenKhoaHoc;
        int fk_iGVID;
        string sHoTenGV;

        public Video()
        {
        }

        public Video(int iID, string sLink, string sTenBaiHoc, string sMota, DateTime dNgayUpload, int fk_iKhoaHocID, string sTenKhoaHoc, int fk_iGVID, string sHoTenGV)
        {
            this.IID = iID;
            this.SLink = sLink;
            this.STenBaiHoc = sTenBaiHoc;
            this.SMota = sMota;
            this.DNgayUpload = dNgayUpload;
            this.Fk_iKhoaHocID = fk_iKhoaHocID;
            this.STenKhoaHoc = sTenKhoaHoc;
            this.Fk_iGVID = fk_iGVID;
            this.SHoTenGV = sHoTenGV;
        }

        public int IID { get => iID; set => iID = value; }
        public string SLink { get => sLink; set => sLink = value; }
        public string STenBaiHoc { get => sTenBaiHoc; set => sTenBaiHoc = value; }
        public string SMota { get => sMota; set => sMota = value; }
        public DateTime DNgayUpload { get => dNgayUpload; set => dNgayUpload = value; }
        public int Fk_iKhoaHocID { get => fk_iKhoaHocID; set => fk_iKhoaHocID = value; }
        public string STenKhoaHoc { get => sTenKhoaHoc; set => sTenKhoaHoc = value; }
        public int Fk_iGVID { get => fk_iGVID; set => fk_iGVID = value; }
        public string SHoTenGV { get => sHoTenGV; set => sHoTenGV = value; }
    }
}

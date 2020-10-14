using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoaHoc
    {
        int iID;
        String sTenKhoaHoc;
        String sImgLink;
        String sMoTa;
        DateTime dNgayKhoiTao;
        DateTime dUpdateTime;
        int fK_SubID;
        String sSub;
        int fK_GVID;
        String sHoTen;
        int iDuyet;
		int fk_CateID;
		String sCate;

		public KhoaHoc(int iID, string sTenKhoaHoc, string sImgLink, string sMoTa, DateTime dNgayKhoiTao, DateTime dUpdateTime, int fK_SubID, string sSub, int fK_GVID, string sHoTen, int iDuyet, int fk_CateID, string sCate) : this(iID, sTenKhoaHoc, sImgLink, sMoTa, dNgayKhoiTao, dUpdateTime, fK_SubID, sSub, fK_GVID, sHoTen, iDuyet)
		{
			this.fk_CateID = fk_CateID;
			this.sCate = sCate;
		}

		public KhoaHoc()
        {
        }

        public KhoaHoc(int iID, string sTenKhoaHoc, string sImgLink, string sMoTa, DateTime dNgayKhoiTao, DateTime dUpdateTime, int fK_SubID, string sSub, int fK_GVID, string sHoTen, int iDuyet)
        {
            this.IID = iID;
            this.STenKhoaHoc = sTenKhoaHoc;
            this.SImgLink = sImgLink;
            this.SMoTa = sMoTa;
            this.DNgayKhoiTao = dNgayKhoiTao;
            this.DUpdateTime = dUpdateTime;
            this.FK_SubID = fK_SubID;
            this.SSub = sSub;
            this.FK_GVID = fK_GVID;
            this.SHoTen = sHoTen;
            this.IDuyet = iDuyet;
        }

        public KhoaHoc(int iID, string sTenKhoaHoc, string sImgLink, string sMoTa, DateTime dNgayKhoiTao, DateTime dUpdateTime, int fK_SubID, int fK_GVID, int duyet)
        {
            IID = iID;
            STenKhoaHoc = sTenKhoaHoc;
            SImgLink = sImgLink;
            SMoTa = sMoTa;
            DNgayKhoiTao = dNgayKhoiTao;
            DUpdateTime = dUpdateTime;
            FK_SubID = fK_SubID;
            FK_GVID = fK_GVID;
            IDuyet = duyet;
        }

        public int IID { get => iID; set => iID = value; }
        public string STenKhoaHoc { get => sTenKhoaHoc; set => sTenKhoaHoc = value; }
        public string SImgLink { get => sImgLink; set => sImgLink = value; }
        public string SMoTa { get => sMoTa; set => sMoTa = value; }
        public DateTime DNgayKhoiTao { get => dNgayKhoiTao; set => dNgayKhoiTao = value; }
        public DateTime DUpdateTime { get => dUpdateTime; set => dUpdateTime = value; }
        public int FK_SubID { get => fK_SubID; set => fK_SubID = value; }
        public string SSub { get => sSub; set => sSub = value; }
        public int FK_GVID { get => fK_GVID; set => fK_GVID = value; }
        public string SHoTen { get => sHoTen; set => sHoTen = value; }
        public int IDuyet { get => iDuyet; set => iDuyet = value; }
		public int Fk_CateID { get => fk_CateID; set => fk_CateID = value; }
		public string SCate { get => sCate; set => sCate = value; }
	}
}

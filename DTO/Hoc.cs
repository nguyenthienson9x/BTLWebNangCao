using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Hoc
    {
        int iId;
        int fk_HocVienID;
        int fk_iKhoaHocID;
        int iDuyet;

		String sTenHocVien;
		String sTenKhoaHoc;

        public Hoc(int iId, int fk_HocVienID, int fk_iKhoaHocID, int iDuyet)
        {
            this.iId = iId;
            this.fk_HocVienID = fk_HocVienID;
            this.fk_iKhoaHocID = fk_iKhoaHocID;
            this.iDuyet = iDuyet;
        }

		public Hoc(int iId, int fk_HocVienID, int fk_iKhoaHocID, int iDuyet, string sTenHocVien, string sTenKhoaHoc)
		{
			this.iId = iId;
			this.fk_HocVienID = fk_HocVienID;
			this.fk_iKhoaHocID = fk_iKhoaHocID;
			this.iDuyet = iDuyet;
			this.sTenHocVien = sTenHocVien;
			this.sTenKhoaHoc = sTenKhoaHoc;
		}

		public Hoc(int iId, int iDuyet, string sTenHocVien, string sTenKhoaHoc)
		{
			this.iId = iId;
			this.iDuyet = iDuyet;
			this.sTenHocVien = sTenHocVien;
			this.sTenKhoaHoc = sTenKhoaHoc;
		}

		public int IId { get => iId; set => iId = value; }
        public int Fk_HocVienID { get => fk_HocVienID; set => fk_HocVienID = value; }
        public int Fk_iKhoaHocID { get => fk_iKhoaHocID; set => fk_iKhoaHocID = value; }
        public int IDuyet { get => iDuyet; set => iDuyet = value; }
		public string STenHocVien { get => sTenHocVien; set => sTenHocVien = value; }
		public string STenKhoaHoc { get => sTenKhoaHoc; set => sTenKhoaHoc = value; }
	}
}

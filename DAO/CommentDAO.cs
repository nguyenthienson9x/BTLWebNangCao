using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CommentDAO
    {
        DataProvider dataProvider = new DataProvider();
        HocVienDAO hocVienDAO = new HocVienDAO();
        GiangVienDAO giangVienDAO = new GiangVienDAO();
        AdminDAO adminDAO = new AdminDAO();

        public List<Comment> GetData(object[] param, List<string> listParam)
        {
            List<Comment> lsComment = new List<Comment>();
            DataTable dt = dataProvider.ExecuteQuery("sp_Comment_GetData", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                {
                    int ID = 0, fk_iVideoID = 0, fk_iKHID = 0, fk_iUserID = 0, fk_iGVID = 0, fk_iAdminID = 0;
                    String sHoTen = "", sNoiDung = "";
                    DateTime dNgay;

                    ID = int.Parse(row["PK_iCommentID"].ToString());
                    if (row["FK_iKHID"].ToString() != "")
                    {
                        fk_iKHID = int.Parse(row["FK_iKHID"].ToString());
                    }
                    else
                    {
                        fk_iVideoID = int.Parse(row["FK_iVideoID"].ToString());
                    }
                    if (row["FK_iUserID"].ToString() != "")
                    {
                        fk_iUserID = int.Parse(row["FK_iUserID"].ToString());
                        sHoTen = hocVienDAO.GetTen(fk_iUserID);
                    }
                    else if (row["FK_iGVID"].ToString() != "")
                    {
                        fk_iGVID = int.Parse(row["FK_iGVID"].ToString());
                        sHoTen = giangVienDAO.GetTen(fk_iGVID);
                    }
                    else
                    {
                        fk_iAdminID = int.Parse(row["FK_iAdminID"].ToString());
                    }

                    sNoiDung = row["sNoiDung"].ToString();
                    dNgay = Convert.ToDateTime(row["dNgay"].ToString());

                    lsComment.Add(new Comment(ID, fk_iVideoID, fk_iKHID, fk_iUserID, fk_iGVID, fk_iAdminID, sHoTen, sNoiDung, dNgay));
                }
            return lsComment;
        }

        public bool Insert(object[] param, List<string> listParam)
        {
            int kq = dataProvider.ExecuteNonQuery("sp_Comment_Insert", param, listParam);
            if (kq > 0)
                return true;
            else return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SubCategoryDAO
    {
        DataProvider dataProvider = new DataProvider();
        public List<SubCategory> GetData(object[] param, List<string> listParam)
        {
            List<SubCategory> lsSubCategories = new List<SubCategory>();
            DataTable dt = dataProvider.ExecuteQuery("sp_SubCategory_GetData", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int ID = int.Parse(row["PK_iID"].ToString());
                    String Category = row["sSubCategory"].ToString();
                    int IDCategory = int.Parse(row["FK_iCategoryID"].ToString());
                    lsSubCategories.Add(new SubCategory(ID, Category, IDCategory));
                }
            }
            return lsSubCategories;
        }
    }
}

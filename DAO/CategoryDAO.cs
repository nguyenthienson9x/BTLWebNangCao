using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CategoryDAO
    {
        DataProvider dataProvider = new DataProvider();
        public List<Category> GetData(object[] param, List<string> listParam)
        {
            List<Category> lsCategories = new List<Category>();
            DataTable dt = dataProvider.ExecuteQuery("sp_Category_GetData", param, listParam);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int ID = int.Parse(row["PK_iID"].ToString());
                    String Category = row["sCategory"].ToString();
                    lsCategories.Add(new Category(ID, Category));
                }
            }
            return lsCategories;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SubCategory
    {
        int iID;
        String sSubCategory;
        int iID_Category;

        public SubCategory()
        {
        }

        public SubCategory(int iID, string sSubCategory, int iID_Category)
        {
            this.iID = iID;
            this.sSubCategory = sSubCategory;
            this.iID_Category = iID_Category;
        }

        public int IID { get => iID; set => iID = value; }
        public string SSubCategory { get => sSubCategory; set => sSubCategory = value; }
        public int IID_Category { get => iID_Category; set => iID_Category = value; }
    }
}

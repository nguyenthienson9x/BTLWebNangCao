using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Category
    {
        int iID;
        String sCategory;

        public Category()
        {
        }

        public Category(int iID, string sCategory)
        {
            this.iID = iID;
            this.sCategory = sCategory;
        }

        public int IID { get => iID; set => iID = value; }
        public string SCategory { get => sCategory; set => sCategory = value; }
    }
}

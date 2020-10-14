using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Admin
    {
        int ID;
        String sHoTen;
        String sEmail;

        public Admin(int iD, string sHoTen, string sEmail)
        {
            ID1 = iD;
            this.SHoTen = sHoTen;
            this.SEmail = sEmail;
        }

        public Admin()
        {
        }

        public int ID1 { get => ID; set => ID = value; }
        public string SHoTen { get => sHoTen; set => sHoTen = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
    }
}

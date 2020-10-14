using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SKH_Learning
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            HttpCookie hocVienCookie = Request.Cookies["HocVienCookie"];
            HttpCookie giangVienCookie = Request.Cookies["GiangVienCookie"];
            HttpCookie adminCookie = Request.Cookies["AdminCookie"];

            if (hocVienCookie == null)
            {
                Session["HocVien"] = "";
            }
            else
            {
                Session["HocVien"] = hocVienCookie.Value.ToString();
            }

            if (giangVienCookie == null)
            {
                Session["GiangVien"] = "";
            }
            else
            {
                Session["GiangVien"] = giangVienCookie.Value.ToString();
            }

            if (adminCookie == null)
            {
                Session["Admin"] = "";
            }
            else
            {
                Session["Admin"] = adminCookie.Value.ToString();
            }


        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
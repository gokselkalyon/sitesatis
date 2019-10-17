using sitesatis.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sitesatis.business.helper
{
    public class Login
    {
        public string login_successfull(string username,string password)
        {
            using (satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                user _user = DB.users.Where(x => x.user_name == username && x.user_password == password).FirstOrDefault();
                if (_user != null)
                {
                    return "basarili_giris";
                }
                return "bulunamadi";
            }
        }
    }
}
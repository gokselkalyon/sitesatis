using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace sitesatis.business.helper
{
    public class filehelper
    {
        public static string[] sitepagecreate(string path,sitepage _sitepage)
        {
            sitepagemanager spm = new sitepagemanager();

            var folderurl = Directory.GetDirectories(path);

            List<string> tr = new List<string>();
            List<string> td = new List<string>();
            char d = '\\';
            for (int i = 0; i < folderurl.Length; i++)
            {
                tr.AddRange(Directory.GetFiles(folderurl[i]));
            }

            for (int k = 0; k < tr.Count; k++)
            {
                string[] sds = tr[k].Split(d).Reverse().ToArray();
                td.Add("" + sds[1] + "\\" + sds[0].Split('.')[0].ToString() + "");
                spm.create(new sitepage
                {
                    site_name = _sitepage.site_name,
                    sitemaster = _sitepage.sitemaster,
                    site_control = sds[1],
                    site_link = sds[0].Split('.')[0].ToString()
                    });
            }
            
            return td.ToArray();
        }
    }
}
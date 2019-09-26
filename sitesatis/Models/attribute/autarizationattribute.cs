using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitesatis.Models.attribute
{
    public class autarizationAttribute : AuthorizeAttribute
    {
        public autarizationAttribute(params string[] role):base()
        {
            Roles = string.Join("Administrator", role);

        }
    }
    
}
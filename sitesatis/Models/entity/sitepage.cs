//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sitesatis.Models.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class sitepage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sitepage()
        {
            this.menus = new HashSet<menu>();
        }
    
        public int id { get; set; }
        public Nullable<int> site_master_id { get; set; }
        public string site_name { get; set; }
        public string site_control { get; set; }
        public string site_link { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menu> menus { get; set; }
        public virtual sitemaster sitemaster { get; set; }
    }
}

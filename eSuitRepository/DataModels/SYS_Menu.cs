//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSuitRepository.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class SYS_Menu
    {
        public SYS_Menu()
        {
            this.SECURITY_MenuAccess = new HashSet<SECURITY_MenuAccess>();
        }
    
        public int Menu_Id { get; set; }
        public string Menu_Code { get; set; }
        public Nullable<int> Comp_Id { get; set; }
        public string Menu_Desc { get; set; }
        public string Menu_ShortDesc { get; set; }
        public Nullable<int> Menu_Status { get; set; }
        public Nullable<int> Menu_SortOrder { get; set; }
        public Nullable<int> Menu_Level { get; set; }
        public string Menu_Module { get; set; }
    
        public virtual ICollection<SECURITY_MenuAccess> SECURITY_MenuAccess { get; set; }
        public virtual SETUP_Company SETUP_Company { get; set; }
    }
}

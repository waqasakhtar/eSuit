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
    
    public partial class SECURITY_MenuAccess
    {
        public int MenuAcs_Id { get; set; }
        public Nullable<int> Comp_Id { get; set; }
        public Nullable<int> Usr_Id { get; set; }
        public Nullable<int> Menu_Id { get; set; }
    
        public virtual SETUP_Company SETUP_Company { get; set; }
        public virtual SYS_Menu SYS_Menu { get; set; }
        public virtual SECURITY_User SECURITY_User { get; set; }
    }
}
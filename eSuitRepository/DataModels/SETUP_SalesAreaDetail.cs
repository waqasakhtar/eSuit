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
    
    public partial class SETUP_SalesAreaDetail
    {
        public int SalArDtl_Id { get; set; }
        public Nullable<int> SalAr_Id { get; set; }
        public Nullable<int> City_Id { get; set; }
        public Nullable<int> SalArDtl_Status { get; set; }
    
        public virtual SETUP_SalesArea SETUP_SalesArea { get; set; }
        public virtual SETUP_City SETUP_City { get; set; }
    }
}

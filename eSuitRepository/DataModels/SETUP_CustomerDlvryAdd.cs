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
    
    public partial class SETUP_CustomerDlvryAdd
    {
        public int CstDlAd_Id { get; set; }
        public string CstDlAd_Code { get; set; }
        public Nullable<int> Comp_Id { get; set; }
        public Nullable<int> Cst_Id { get; set; }
        public string CstDlAd_Desc { get; set; }
        public string CstDlAd_Address1 { get; set; }
        public string CstDlAd_Address2 { get; set; }
        public string CstDlAd_Address3 { get; set; }
        public string CstDlAd_Address4 { get; set; }
        public string CstDlAd_Phone1 { get; set; }
        public string CstDlAd_Phone2 { get; set; }
        public string CstDlAd_Phone3 { get; set; }
        public string CstDlAd_Mobile1 { get; set; }
        public string CstDlAd_Mobile2 { get; set; }
        public string CstDlAd_Fax { get; set; }
        public string CstDlAd_EMail { get; set; }
        public string CstDlAd_ContactPerson { get; set; }
        public Nullable<int> CstDlAd_Status { get; set; }
    
        public virtual SETUP_Company SETUP_Company { get; set; }
        public virtual SETUP_Customer SETUP_Customer { get; set; }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eSuitRepository.DataModels;
using eSuitRepository.DataProviders;
namespace eSuit.Tests.eSuitRepositoryTest
{
    [TestClass]
    public class Company_Ut
    {
        [TestMethod]
        public void Add_Ut()
        {
            Company dpCompany = new Company();
            SETUP_Company mdlCompany = new SETUP_Company();
            mdlCompany.Comp_Desc = "Demo Company4";
            mdlCompany.Comp_Code = "0004";
            mdlCompany.Comp_EMail = "waqas_viki@yahoo.com";
            mdlCompany.Comp_Mobile1 = "03346024022";
            mdlCompany.Comp_Address1 = "Test Address4";
            dpCompany.Add(mdlCompany);
        }

        [TestMethod]
        public void Update_Ut()
        {
            Company dpCompany = new Company();
            SETUP_Company mdlCompany = new SETUP_Company();
            mdlCompany.Comp_Id = 3;
            mdlCompany.Comp_Desc = "Demo Company7";
            mdlCompany.Comp_Code = "0003";
            mdlCompany.Comp_EMail = "waqas@icaremanager.com";
            mdlCompany.Comp_Mobile1 = "03104423653";
            mdlCompany.Comp_Address1 = "Test Address3";
            mdlCompany.Comp_Fax = "0000000003";
            dpCompany.Updated(mdlCompany);
        }

        [TestMethod]
        public void Delete_Ut()
        {
            Company dpCompany = new Company();
            dpCompany.Delete(0);
        }

        [TestMethod]
        public void Get_Ut()
        {
            Company dpCompany = new Company();
            Console.WriteLine(dpCompany.Get(1).Comp_Desc);
        }

        [TestMethod]
        public void List_Ut()
        {
            Company dpCompany = new Company();
            Console.WriteLine(dpCompany.List().Count);
        }
    }
}

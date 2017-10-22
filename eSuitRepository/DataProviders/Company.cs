using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSuitRepository.DataModels;

namespace eSuitRepository.DataProviders
{
    /// <summary>
    /// This class provides methods for add/update/delete and all company related database operations......
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Adds new company to the database....
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Returns new company id if saved successfully else returns 0</returns>
        public int Add(SETUP_Company company)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(company).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return company.Comp_Id;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Updates modified values of company to the database....
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Returns true if updated successfully else returns false.</returns>
        public bool Update(SETUP_Company company)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Deletes company based on company id from database....
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if delted successfully else returns false...</returns>
        public bool Delete(int comp_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(db.SETUP_Company.Find(comp_Id)).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets company from database by company id
        /// </summary>
        /// <param name="comp_Id"></param>
        /// <returns>Returns SETUP_Company object</returns>
        public SETUP_Company Get(int comp_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    return db.SETUP_Company.Find(comp_Id);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a list of all companies from database
        /// </summary>
        /// <param name="comp_Id"></param>
        /// <returns>Returns a list of SETUP_Company object</returns>
        public List<SETUP_Company> List()
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    var companyList = db.SETUP_Company.ToList();
                    return companyList.OrderBy(c => Convert.ToInt32(c.Comp_SortOrder == null ? 0 : c.Comp_SortOrder)).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a list of all companies from database for dropdowns
        /// </summary>
        /// <param name="comp_Id"></param>
        /// <returns>Returns a list of SETUP_Company object with only comp-id and description</returns>
        public List<SETUP_Company> Dropdown()
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    var companyList = db.SETUP_Company.ToList().Select(c => new SETUP_Company() { Comp_Id = c.Comp_Id, Comp_ShortDesc = c.Comp_ShortDesc, Comp_SortOrder = c.Comp_SortOrder }).ToList();
                    return companyList.OrderBy(c => Convert.ToInt32(c.Comp_SortOrder == null ? 0 : c.Comp_SortOrder)).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

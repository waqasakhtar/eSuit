using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSuitRepository.DataModels;

namespace eSuitRepository.DataProviders
{
    /// <summary>
    /// This class provides methods for add/update/delete and all country related database operations......
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Adds new country to the database....
        /// </summary>
        /// <param name="department"></param>
        /// <returns>Returns new country id if saved successfully else returns 0</returns>
        public int Add(SETUP_Country country)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(country).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return country.Cont_Id;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Updates modified values of country to the database....
        /// </summary>
        /// <param name="department"></param>
        /// <returns>Returns true if updated successfully else returns false.</returns>
        public bool Update(SETUP_Country country)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(country).State = System.Data.Entity.EntityState.Modified;
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
        /// Deletes country based on country id from database....
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if delted successfully else returns false...</returns>
        public bool Delete(int cont_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(db.SETUP_Country.Find(cont_Id)).State = System.Data.Entity.EntityState.Deleted;
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
        /// Gets country from database by country id
        /// </summary>
        /// <param name="cont_Id"></param>
        /// <returns>Returns SETUP_Country object</returns>
        public SETUP_Country Get(int cont_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    return db.SETUP_Country.Include("SETUP_Company").Where(d => d.Cont_Id == cont_Id).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a list of all country / country based on company id from database
        /// </summary>
        /// <param name="comp_Id"></param>
        /// <returns>Returns a list of SETUP_Country object</returns>
        public List<SETUP_Country> List(int? comp_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    var countryList = db.SETUP_Country.Include("SETUP_Company").ToList();
                    if (comp_Id != null && comp_Id > 0)
                    {
                        countryList = countryList.Where(d => d.Comp_Id == comp_Id).ToList();
                    }
                    return countryList.OrderBy(c => Convert.ToInt32(c.Cont_SortOrder == null ? 0 : c.Cont_SortOrder)).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// Gets a list of all countries from database for dropdowns
        /// </summary>
        /// <param name="comp_Id"></param>
        /// <returns>Returns a list of SETUP_Country object with only comp-id and description</returns>
        public List<SETUP_Country> Dropdown(int? comp_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    var countryList = db.SETUP_Country.ToList().Select(c => new SETUP_Country() { Comp_Id = c.Comp_Id, Cont_Id = c.Cont_Id, Cont_ShortDesc = c.Cont_ShortDesc, Cont_SortOrder = c.Cont_SortOrder }).ToList();
                    if (comp_Id != null && comp_Id > 0)
                    {
                        countryList = countryList.Where(d => d.Comp_Id == comp_Id).ToList();
                    }
                    return countryList.OrderBy(c => Convert.ToInt32(c.Cont_SortOrder == null ? 0 : c.Cont_SortOrder)).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}

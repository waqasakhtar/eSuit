using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSuitRepository.DataModels;

namespace eSuitRepository.DataProviders
{
    /// <summary>
    /// This class provides methods for add/update/delete and all city related database operations......
    /// </summary>
    public class City
    {
        /// <summary>
        /// Adds new city to the database....
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Returns new city id if saved successfully else returns 0</returns>
        public int Add(SETUP_City city)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(city).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return city.City_Id;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Updates modified values of city to the database....
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Returns true if updated successfully else returns false.</returns>
        public bool Update(SETUP_City city)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(city).State = System.Data.Entity.EntityState.Modified;
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
        /// Deletes city based on city id from database....
        /// </summary>
        /// <param name="city_Id"></param>
        /// <returns>Returns true if delted successfully else returns false...</returns>
        public bool Delete(int city_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(db.SETUP_City.Find(city_Id)).State = System.Data.Entity.EntityState.Deleted;
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
        /// Gets city from database by city id
        /// </summary>
        /// <param name="City_Id"></param>
        /// <returns>Returns SETUP_City object</returns>
        public SETUP_City Get(int city_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    return db.SETUP_City.Include("SETUP_Company").Include("SETUP_Country").Where(d => d.City_Id == city_Id).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a list of all city / city based on company id & country id from database
        /// </summary>
        /// <param name="comp_Id"></param>
        /// <param name="cont_Id"></param>
        /// <returns>Returns a list of SETUP_City object</returns>
        public List<SETUP_City> List(int? comp_Id, int? cont_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    var CityList = db.SETUP_City.Include("SETUP_Company").Include("SETUP_Country").ToList();
                    if (comp_Id != null && comp_Id > 0)
                    {
                        CityList = CityList.Where(d => d.Comp_Id == comp_Id).ToList();
                    }
                    if (cont_Id != null && cont_Id > 0)
                    {
                        CityList = CityList.Where(d => d.Cont_Id == cont_Id).ToList();
                    }
                    return CityList.OrderBy(c => Convert.ToInt32(c.City_SortOrder == null ? 0 : c.City_SortOrder)).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

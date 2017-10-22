using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSuitRepository.DataModels;

namespace eSuitRepository.DataProviders
{
    /// <summary>
    /// This class provides methods for add/update/delete and all departments related database operations......
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Adds new department to the database....
        /// </summary>
        /// <param name="department"></param>
        /// <returns>Returns new department id if saved successfully else returns 0</returns>
        public int Add(SETUP_Department department)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(department).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return department.Dep_Id;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Updates modified values of department to the database....
        /// </summary>
        /// <param name="department"></param>
        /// <returns>Returns true if updated successfully else returns false.</returns>
        public bool Update(SETUP_Department department)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(department).State = System.Data.Entity.EntityState.Modified;
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
        /// Deletes department based on department id from database....
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if delted successfully else returns false...</returns>
        public bool Delete(int dep_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    db.Entry(db.SETUP_Department.Find(dep_Id)).State = System.Data.Entity.EntityState.Deleted;
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
        /// Gets department from database by department id
        /// </summary>
        /// <param name="dep_Id"></param>
        /// <returns>Returns SETUP_Department object</returns>
        public SETUP_Department Get(int dep_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    return db.SETUP_Department.Include("SETUP_Company").Where(d => d.Dep_Id == dep_Id).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a list of all departments / department based on department id from database
        /// </summary>
        /// <param name="comp_Id"></param>
        /// <returns>Returns a list of SETUP_Department object</returns>
        public List<SETUP_Department> List(int? comp_Id)
        {
            using (eSuiteEntities db = new eSuiteEntities())
            {
                try
                {
                    var departmentList = db.SETUP_Department.Include("SETUP_Company").ToList();
                    if (comp_Id != null && comp_Id > 0)
                    {
                        departmentList = departmentList.Where(d => d.Comp_Id == comp_Id).ToList();
                    }
                    return departmentList.OrderBy(c => Convert.ToInt32(c.Dep_SortOrder == null ? 0 : c.Dep_SortOrder)).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

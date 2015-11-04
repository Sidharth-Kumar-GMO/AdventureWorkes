﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Common;

namespace AdventureWorks.Data.EntityFramework.HumanResources
{
    using System.Linq;
    using System.Data.Entity;
    using Interfaces;

    public class EmployeeDA : IEmployeeDA
    {
        #region Private Fields

        private AdventureWorks2012Entities db;

        #endregion

        #region Constructors

        public EmployeeDA()
        {
            db = new AdventureWorks2012Entities();
        }

        #endregion

        #region Public Methods

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees;
        }

        public Employee GetEmployeeByBusinessEntityId(int id)
        {
            return db.Employees.Find(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesToEntities()
        {
            db.SaveChanges();
        }

        #endregion
    }
}

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

    public class EmployeeDA
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

        public Employee GetEmployeeByBusinessEntityId(int id)
        {
            var employee = db.Employees.Find(id);

            return employee;
        }

        public string GetJobTitleByBusinessEntityId(int id)
        {
            return db.Employees.Find(id).JobTitle;
        }

        #endregion
    }
}
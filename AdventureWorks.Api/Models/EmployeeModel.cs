﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Api.Models
{
    public class EmployeeModel
    {
        #region Public Properties

        public int BusinessEntityId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string OrganizationNode { get; set; }

        #endregion
    }
}
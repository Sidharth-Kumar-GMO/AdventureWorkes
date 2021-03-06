using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BusinessObjects
{
    using AdventureWorks.Enumerations;

    public class PersonPhone
    {
        #region Public Properties

        public int BusinessEntityId { get; set; }

        public string PhoneNumber { get; set; }

        public PhoneNumberTypeEnum PhoneNumberType { get; set; }

        #endregion

        #region Public Methods

        public bool Equals(PersonPhone obj)
        {
            return BusinessEntityId == obj.BusinessEntityId
                && PhoneNumber == obj.PhoneNumber
                && PhoneNumberType == obj.PhoneNumberType;
        }

        #endregion
    }
}

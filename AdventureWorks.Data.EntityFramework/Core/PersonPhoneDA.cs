using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.EntityFramework.Core
{
    using Extensions;
    using Data.Interfaces;

    public class PersonPhoneDA : BaseDA, IPersonPhoneDA
    {
        #region Constructors

        public PersonPhoneDA() : base()
        {
        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.PersonPhone> GetEmployeePersonPhonesByBusinessEntityId(int id)
        {
            return Db.Employees.Find(id).Person.PersonPhones.MapToBusinessLayer();
        }

        public Task<BusinessObjects.PersonPhone> GetPhoneNumberAsync(int businessEntityId, string phoneNumber, int phoneNumberType)
        {
            return Task.Run(() => Db.PersonPhones.Find(businessEntityId, phoneNumber, phoneNumberType).MapToBusinessLayer());
        }

        public void AddPhoneNumber(BusinessObjects.PersonPhone phoneNumber)
        {
            // Create new entity to add
            var newNumber = new PersonPhone();

            // Map the BO data onto this new entity
            phoneNumber.MapOntoEntity(newNumber);

            // Add this entity to the context
            Db.PersonPhones.Add(newNumber);

            // Save the changes
            Db.SaveChanges();
        }

        public void DeletePhoneNumber(BusinessObjects.PersonPhone phoneNumber)
        {
            // Find the desired entity using the composite primary key
            var phoneEntity = Db.PersonPhones.Find(
                phoneNumber.BusinessEntityId, 
                phoneNumber.PhoneNumber, 
                (int)phoneNumber.PhoneNumberType);

            // Delete the entity from the context
            Db.PersonPhones.Remove(phoneEntity);

            // Save the changes
            Db.SaveChanges();
        }

        #endregion
    }
}

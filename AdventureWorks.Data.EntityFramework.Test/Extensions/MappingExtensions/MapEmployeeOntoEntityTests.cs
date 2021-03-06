using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.EntityFramework.Test.Extensions.MappingExtensions
{
    using NUnit.Framework;
    using EntityFramework.Extensions;
    using TestData;

    [TestFixture]
    public class MapEmployeeOntoEntityTests
    {
        private BusinessObjects.Employee employeeBo;

        private EntityFramework.Employee employeeEntity;

        [SetUp]
        public void SetUp()
        {
            employeeBo = new BusinessObjects.Employee();
            employeeEntity = new EntityFramework.Employee { Person = new Person() };
        }

        [Test]
        public void MapOntoEntity_EmployeeBusinessObjectMappedOntoEmployeeEntity_ModifiedFieldsChanged()
        {
            // Arrange
            AddValidDataToEmployeeBo();

            // Act
            employeeBo.MapOntoEntity(employeeEntity);

            // Assert
            Assert.AreEqual(employeeEntity.Person.FirstName, TestData.CeoFirstName);
            Assert.AreEqual(employeeEntity.Person.MiddleName, TestData.CeoMiddleName);
            Assert.AreEqual(employeeEntity.Person.LastName, TestData.CeoLastName);
            Assert.AreEqual(employeeEntity.JobTitle, TestData.CeoJobTitle);
        }

        [Test]
        public void MapOntoEntity_EmployeeBusinessObjectMappedOntoEmployeeEntity_BusinessEntityUnchanged()
        {
            // Arrange
            AddValidDataToEmployeeBo();

            // Act
            employeeBo.MapOntoEntity(employeeEntity);

            // Assert
            Assert.AreEqual(employeeEntity.BusinessEntityID, 0);
        }

        [Test]
        public void MapOntoEntity_NullEmployeeBusinessObject_NullReferenceExceptionThrown()
        {
            // Arrange
            BusinessObjects.Employee nullEmployeeBo = null;

            // Act/Assert
            Assert.Throws<NullReferenceException>(() => nullEmployeeBo.MapOntoEntity(employeeEntity));
        }

        [Test]
        public void MapOntoEntity_NullEmployeeEntity_NullReferenceExceptionThrown()
        {
            // Arrange
            EntityFramework.Employee nullEmployeeEntity = null;
            AddValidDataToEmployeeBo();

            // Act/Assert
            Assert.Throws<NullReferenceException>(() => employeeBo.MapOntoEntity(nullEmployeeEntity));
        }

        private void AddValidDataToEmployeeBo()
        {
            employeeBo.FirstName = TestData.CeoFirstName;
            employeeBo.MiddleName = TestData.CeoMiddleName;
            employeeBo.LastName = TestData.CeoLastName;
            employeeBo.JobTitle = TestData.CeoJobTitle;
        }
    }
}

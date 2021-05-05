using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.ApplicationService.Implementation;
using Events.Core.DomainService;
using Events.Core.Entites;
using Moq;
using Xunit;

namespace Events.Core.Test
{
    public class PersonTest
    {
        [Fact]
        public void PassNullAsIPersonRepository_ThrowsNullRefException()
        {
            IPersonRepository pRepo = null;
            Assert.Throws<NullReferenceException>(() => new PersonService(pRepo));
        }

        [Fact]
        public void TestCreatePersonBehaviour()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();

            PersonService pService = new PersonService(mock.Object);

            Person p = new Person
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Uncle",
                IdNumber = 123,
                isCash = false,
                EventId = 3,
                AdditionalInfo = "Uncle Bob"
            };
            pService.CreatePerson(p);

            mock.Verify(mock => mock.CreatePerson(p), Times.Once);
        }

        [Fact]
        public void TestGetAllPersonsBehaviour()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();

            Person[] returnValue = {new Person
                        {
                            FirstName = "Bob",
                            LastName = "Uncle",
                            IdNumber = 123,
                            isCash = false,
                            EventId = 3,
                            AdditionalInfo = "Uncle Bob"
                        },
                        new Person
                        {
                            FirstName = "Rob",
                            LastName = "Daddy",
                            IdNumber = 12356,
                            isCash = false,
                            EventId = 3,
                            AdditionalInfo = "Daddy Rob"
                        }}; 

            mock.Setup(mock => mock.GetAllPersons()).Returns(() => returnValue.ToList());

            PersonService pService = new PersonService(mock.Object);

            pService.GetAllPersons();

            mock.Verify(mock => mock.GetAllPersons(), Times.Once);
        }

        [Fact]
        public void TestGetPersonByIdBehaviour()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();

            Person[] personList = {new Person
                        {
                            Id = 2,
                            FirstName = "Bob",
                            LastName = "Uncle",
                            IdNumber = 123,
                            isCash = false,
                            EventId = 3,
                            AdditionalInfo = "Uncle Bob"
                        },
                        new Person
                        {
                            Id = 3,
                            FirstName = "Rob",
                            LastName = "Daddy",
                            IdNumber = 12356,
                            isCash = false,
                            EventId = 3,
                            AdditionalInfo = "Daddy Rob"
                        }};

            mock.Setup(mock => mock.GetPersonById(2)).Returns(() => personList[0]);

            PersonService pService = new PersonService(mock.Object);

            pService.GetPersonById(2);

            mock.Verify(mock => mock.GetPersonById(2), Times.Once);
        }

        [Fact]
        public void TestDeletePersonBehaviour()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();

            Person[] personList = {new Person
                        {
                            Id = 2,
                            FirstName = "Bob",
                            LastName = "Uncle",
                            IdNumber = 123,
                            isCash = false,
                            EventId = 3,
                            AdditionalInfo = "Uncle Bob"
                        },
                        new Person
                        {
                            Id = 3,
                            FirstName = "Rob",
                            LastName = "Daddy",
                            IdNumber = 12356,
                            isCash = false,
                            EventId = 3,
                            AdditionalInfo = "Daddy Rob"
                        }};

            mock.Setup(mock => mock.DeletePerson(2)).Returns(() => personList[0]);

            PersonService pService = new PersonService(mock.Object);

            Person personToDelete = pService.DeletePerson(2);

            mock.Verify(mock => mock.DeletePerson(2), Times.Once);
        }
    }
}

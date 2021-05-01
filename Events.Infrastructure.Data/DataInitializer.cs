using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.DomainService;
using Events.Core.Entites;

namespace Events.Infrastructure.Data
{
    public class DataInitializer : IDataInitializer
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IEventRepository _eventRepo;

        public DataInitializer(ICompanyRepository companyRepository, IPersonRepository personRepository
                                    , IEventRepository eventRepository){
            _companyRepo = companyRepository;
            _personRepo = personRepository;
            _eventRepo = eventRepository;
        }

        public void SeedDB(EventAppDBContext _ctx)
        {
            #region Events
            Event event1 = new Event()
            {
                EventName = "Shopping Trip",
                EventDate = new DateTime(2021, 04, 18),
                Place = "Milan",
                AdditionalInfo = "Shopping tour to Milan for a weekend"
            };
            _eventRepo.CreateEvent(event1);

            Event event2 = new Event()
            {
                EventName = "Ida-Virumaa food fairy",
                EventDate = new DateTime(2021, 06, 01),
                Place = "Narva",
                AdditionalInfo = "Famous food fairy festival"
            };
            _eventRepo.CreateEvent(event2);

            Event event3 = new Event()
            {
                EventName = "Baltic Festival",
                EventDate = new DateTime(2021, 05, 28),
                Place = "Parnu",
                AdditionalInfo = "Biggest music and art festival in baltic region"
            };
            _eventRepo.CreateEvent(event3);
            #endregion
            #region Companies
            Company company1 = new Company()
            {
                CompanyName = "Novel OU",
                CompanyCode = 344223,
                isCash = true,
                EventId = 1,
                AdditionalInfo = "Book Store company"
            };
            _companyRepo.CreateCompany(company1);
            Company company2 = new Company()
            {
                CompanyName = "Water OU",
                CompanyCode = 356723,
                isCash = false,
                EventId = 2,
                AdditionalInfo = "Clean water supplier"
            };
            _companyRepo.CreateCompany(company2);
            Company company3 = new Company()
            {
                CompanyName = "Travel OU",
                CompanyCode = 348921,
                isCash = true,
                EventId = 1,
                AdditionalInfo = "Travel agency"
            };
            _companyRepo.CreateCompany(company3);
            #endregion
            #region Persons
            Person person1 = new Person()
            {
                FirstName = "Andres",
                LastName = "Ilves",
                IdNumber = 39152321,
                EventId = 1,
                isCash = true,
                AdditionalInfo = "Tore mees Tartus"
            };
            _personRepo.CreatePerson(person1);
            Person person2 = new Person()
            {
                FirstName = "Anton",
                LastName = "Kingisepp",
                IdNumber = 39151991,
                EventId = 2,
                isCash = false,
                AdditionalInfo = "Noor jalgpallur"
            };
            _personRepo.CreatePerson(person2);
            Person person3 = new Person()
            {
                FirstName = "Tarmo",
                LastName = "Lasikovits",
                IdNumber = 391525321,
                isCash = false,
                EventId = 3,
                AdditionalInfo = "Kasvataja 'Lepatrinu' lasteajas"
            };
            _personRepo.CreatePerson(person3);
            #endregion
            
        }
    }
}

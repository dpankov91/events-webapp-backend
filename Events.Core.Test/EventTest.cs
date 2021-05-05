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
    public class EventTest
    {
        [Fact]
        public void PassNullAsIEventRepository_ThrowsNullRefException()
        {
            IEventRepository eRepo = null;
            Assert.Throws<NullReferenceException>(() => new EventService(eRepo));
        }

        [Fact]
        public void TestCreateEventBehaviour()
        {
            Mock<IEventRepository> mock = new Mock<IEventRepository>();

            EventService eService = new EventService(mock.Object);

            Event e = new Event
            {
                EventName = "Test Event",
                EventDate = new DateTime(2021, 05, 20),
                Place = "Tln",
                AdditionalInfo = "Test Event Rules"
            };
            eService.CreateEvent(e);

            mock.Verify(mock => mock.CreateEvent(e), Times.Once);
        }

        [Fact]
        public void TestGetAllEventsBehaviour()
        {
            Mock<IEventRepository> mock = new Mock<IEventRepository>();

            Event[] returnValue = {new Event
                        {
                            EventName = "Test Event",
                            EventDate = new DateTime(2021, 05, 20),
                            Place = "Tln",
                            AdditionalInfo = "Test Event Rules"
                        },
                        new Event
                        {
                            EventName = "Second Event",
                            EventDate = new DateTime(2021, 05, 20),
                            Place = "Parnu",
                            AdditionalInfo = "Test Event Rules second one"
                        }};

            mock.Setup(mock => mock.GetAllEvents()).Returns(() => returnValue.ToList());

            EventService eService = new EventService(mock.Object);

            eService.GetAllEvents();

            mock.Verify(mock => mock.GetAllEvents(), Times.Once);
        }

        [Fact]
        public void TestGetEventByIdBehaviour()
        {
            Mock<IEventRepository> mock = new Mock<IEventRepository>();

            Event[] eventList = {new Event
                        {
                            Id = 2,
                            EventName = "Test Event",
                            EventDate = new DateTime(2021, 05, 20),
                            Place = "Tln",
                            AdditionalInfo = "Test Event Rules"
                        },
                        new Event
                        {
                            Id = 3,
                            EventName = "Second Event",
                            EventDate = new DateTime(2021, 05, 20),
                            Place = "Parnu",
                            AdditionalInfo = "Test Event Rules second one"
                        }};

            mock.Setup(mock => mock.GetEventById(2)).Returns(() => eventList[0]);

            EventService eService = new EventService(mock.Object);

            eService.GetEventById(2);

            mock.Verify(mock => mock.GetEventById(2), Times.Once);
        }

        [Fact]
        public void TestDeleteEventBehaviour()
        {
            Mock<IEventRepository> mock = new Mock<IEventRepository>();

            Event[] eventList = {new Event
                        {
                            Id = 2,
                            EventName = "Test Event",
                            EventDate = new DateTime(2021, 05, 20),
                            Place = "Tln",
                            AdditionalInfo = "Test Event Rules"
                        },
                        new Event
                        {
                            Id = 3,
                            EventName = "Second Event",
                            EventDate = new DateTime(2021, 05, 20),
                            Place = "Parnu",
                            AdditionalInfo = "Test Event Rules second one"
                        }};

            mock.Setup(mock => mock.DeleteEvent(2)).Returns(() => eventList[0]);

            EventService eService = new EventService(mock.Object);

            Event eventToDelete = eService.DeleteEvent(2);

            mock.Verify(mock => mock.DeleteEvent(2), Times.Once);
        }
    }
}

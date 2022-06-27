using EventManagement.Models;
using EventManagement.ServiceLayer;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EventManagementNUnitProject
{ 
public class Tests
{
    private Mock<IRepository> mock;
    public IRepository service;

    List<VenueDetails> Venue_List;
    VenueDetails venue = new VenueDetails() { Id = 1, Event_Place = "Marriage", DJ_Cost = 3000, Mike_Speaker_Cost = 2000, Stage_Cost = 5000 };

    [SetUp]
    public void Setup()
    {
        Venue_List = new List<VenueDetails> {
           new VenueDetails() { Id = 1, Event_Place = "Marriage", DJ_Cost = 3000, Mike_Speaker_Cost = 2000, Stage_Cost = 5000 },
           new VenueDetails() { Id = 2, Event_Place = "Party Hall", DJ_Cost = 4000, Mike_Speaker_Cost = 6000, Stage_Cost = 8000 },
           new VenueDetails() { Id = 3, Event_Place = "Fest", DJ_Cost = 6000, Mike_Speaker_Cost = 5000, Stage_Cost = 15000 },
           new VenueDetails() { Id = 4, Event_Place = "Marriage", DJ_Cost = 6000, Mike_Speaker_Cost = 3000, Stage_Cost = 10000 }

        };

        mock = new Mock<IRepository>();
        mock.Setup(x => x.Details("1")).Returns(venue);

    }

    [Test]
    public void GetVenueDetails_ValidInput_ReturnsOkRequest()
    {
        service = mock.Object;
        string id = "1";
        VenueDetails result = service.Details(id);
        Assert.AreEqual(venue, result);
    }

    [Test]
    public void GetVenueDetails_ValidInput_ReturnsNull_InValidOutput()
    {
        service = mock.Object;
        string id = "1";
        VenueDetails result = service.Details(id);
        Assert.AreNotEqual(null, result);
    }

    [Test]
    public void GetVenueDetails_InvalidInput_ReturnsNotFoundResult()
    {
        service = mock.Object;
        string id = "2";
        VenueDetails result = service.Details(id);
        Assert.AreNotEqual(venue, result);
    }

    [Test]
    public void GetVenueDetails_ValidInput_ReturnsInValidOutput()
    {
        service = mock.Object;
        string id = "1";
            VenueDetails result = service.Details(id);
        Assert.AreNotEqual(Venue_List[1], result);
    }

    
}
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using Scooch.Controllers;
using Scooch.Interfaces;
using Scooch.Models;
using Scooch.Repositories;
using System;
using System.Collections.Generic;
using Xunit;


namespace Scooch.Tests
{
    public class ControllerTests
    {      

        [Fact]
        public void IndexViewHas3Events()
        {
            using (var context = new ScoochDBContext(DbOptionsFactory.DbContextOptions))
            {
                // Instantiate Class with DbContext parameter
                var mockEventRepo = new Mock<IEventRepo>();

                var controller = new ScoochController(context, mockEventRepo.Object);

                var result = Assert.IsType<ViewResult>(controller.Index());

                // Check that the model returned to the view is 'List<Product>'.
                var model = Assert.IsType<List<EventEntity>>(result.Model);
 

                // Ensure count of objects is 3.
                int expected = 3;
                int actual = model.Count;
                Assert.Equal(expected, actual);

            }
        }

        [Fact]
        public void UnitTestEventList()
        {
            using (var context = new ScoochDBContext(DbOptionsFactory.DbContextOptions))
            {
                // Instantiate Class with DbContext parameter
                var mockEventRepo = new Mock<IEventRepo>();

                mockEventRepo.Setup(mpr => mpr.EventList())
                .Returns(new List<EventEntity>{
                    new EventEntity(), new EventEntity(), new EventEntity()
                });

                // Ensure count of objects is 3.
                int expected = 3;
                int actual = mockEventRepo.Object.EventList().Count;
                Assert.Equal(expected, actual);

            }
        }
    }

}

using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Dyrehage;
using bacit_dotnet.MVC.Repositories;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bacit_dotnet.MVC.Tests.Controllers
{
    public class DyrehageControllerUnitTests
    {

        private IDyrRepository dyrRepository;
        private ILogger<DyrehageController> logger;
        private void InitializeFakes()
        {
            dyrRepository = Substitute.For<IDyrRepository>();
            dyrRepository.GetAll().Returns(new List<Dyr> { new Dyr { Id = 1, Name = "Pumba" } });

        }

        private DyrehageController GetUnitUnderTest()
        {
            InitializeFakes();
            return new DyrehageController(dyrRepository, logger);
        }

        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<DyrFullViewModel>(result.Model);
        }
        [Fact]
        public async Task PostSendsCorrectValuesToRepository() 
        {
            var unitUnderTest = GetUnitUnderTest();
            unitUnderTest.Post(new DyrFullViewModel
            {
                UpsertModel = new DyrViewModel
                {
                    Id = 7,
                    Name = "Foo"
                }
            });
            var sp = dyrRepository.ReceivedCalls().First().GetArguments().First() as Dyr;
            Assert.Equal(7, sp.Id);
        }
    }
}

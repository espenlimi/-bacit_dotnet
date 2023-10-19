using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Dyrehage;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bacit_dotnet.MVC.Tests.Controllers
{
    public class DyrehageControllerUnitTests
    {
        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var dyrRepository = Substitute.For<IDyrRepository>();

            dyrRepository.GetAll().Returns(new List<Dyr> { new Dyr {Id = 1, Name = "Pumba" } });

            var unitUnderTest = new DyrehageController(dyrRepository);
            
            var result = unitUnderTest.Index() as ViewResult;
            
            Assert.IsType<DyrFullViewModel>(result.Model);
        }
    }
}

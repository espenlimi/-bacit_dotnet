using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bacit_dotnet.MVC.Tests.Controllers
{
#pragma warning disable CS8602 //Disable null reference warnings, if something is null the test should fail. 

    public class MVCControllerUnitTests
    {

        [Fact]
        public void IndexReturnsCorrectContent() 
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.Same("Index", result.ViewName);
        }

        [Fact]
        public void UsingRazorReturnsCorrectModel()
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<RazorViewModel>(result.Model);
        }

        [Fact]
        public void UsingRazorReturnsCorrectModelContent()  
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            var model = result.Model as RazorViewModel;
            Assert.Same("En time til ørsta rådhus", model.Content);
        }

        private static HomeController SetupUnitUnderTest()
        {
            var fakeLogger = Substitute.For<ILogger<HomeController>>(); //Set up a fake for dependency (this works with all interfaces)
            var unitUnderTest = new HomeController(fakeLogger); //Create the class we want to test
            return unitUnderTest;
        }
    }
}

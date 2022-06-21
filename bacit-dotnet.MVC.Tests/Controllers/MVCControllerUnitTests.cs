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
            var result = unitUnderTest.Index() as ContentResult; //Safe casting, result will be null if unitUnderTest.Index() returns another type than ContentResult
            Assert.Same("<html><head><title>BACIT</title></head><body><h1>En time til ørsta rådhus</h1></body> </html>", result.Content); //Check if expected is the same as the returned value
        }

        [Fact]
        public void UsingRazorReturnsCorrectView() 
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.UsingRazor() as ViewResult;
            Assert.Same("UsingRazor", result.ViewName);
        }

        [Fact]
        public void UsingRazorReturnsCorrectModel()
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.UsingRazor() as ViewResult;
            Assert.IsType<RazorViewModel>(result.Model);
        }

        [Fact]
        public void UsingRazorReturnsCorrectModelContent()
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.UsingRazor() as ViewResult;
            var model = result.Model as RazorViewModel;
            Assert.Same("En time til ørsta rådhus", model.Content);
        }

        private static MVCController SetupUnitUnderTest()
        {
            var fakeLogger = Substitute.For<ILogger<MVCController>>(); //Set up a fake for dependency (this works with all interfaces)
            var unitUnderTest = new MVCController(fakeLogger); //Create the class we want to test
            return unitUnderTest;
        }
    }
}

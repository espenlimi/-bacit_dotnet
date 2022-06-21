using bacit_dotnet.MVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Tests.Controllers
{
    public class RESTControllerUnitTests
    {
        [Fact]
        public void GetReturnsCorrectContent() 
        {
            var unitUnderTest = new RESTController();
            var result = unitUnderTest.Get() as OkObjectResult;
            Assert.Same("Det tar en time å gå til ørsta rådhus", result.Value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void PostReturns400OnFaultyInput(int value)
        {
            var unitUnderTest = new RESTController();
            var result = unitUnderTest.Post(value);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostReturnsCorrectContentOnFaultyInput()
        {
            var unitUnderTest = new RESTController();
            var result = unitUnderTest.Post(10) as BadRequestObjectResult;
            Assert.Same("Det skal ta en time å gå til ørsta rådhus", result.Value);
        }

        [Fact]
        public void PostReturnsCorrectContentOnCorrectInput()
        {
            var unitUnderTest = new RESTController();
            var result = unitUnderTest.Post(1) as OkObjectResult;
            Assert.Same("Ikkje at eg he noko der å gjer", result.Value);
        }
    }
}

using FluentAssertions;
using Xunit;
using Moq;
using FakeItEasy;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Controllers;
using Microsoft.Extensions.Logging;
using webSITE.Domain;
using Microsoft.AspNetCore.Mvc;
using webSITE.Models.Home;

namespace webSITE.Test.Controllers
{
    public class HomeControllerTests
    {
        private readonly Mock<IRepositoriKegiatan> _repositoriKegiatan;
        private readonly Mock<ILogger<HomeController>> _logger;

        private readonly HomeController _homeController;

        public HomeControllerTests()
        {
            //Depedencies
            _repositoriKegiatan = new Mock<IRepositoriKegiatan>();
            _logger = new Mock<ILogger<HomeController>>();

            //SUT
            _homeController = new HomeController(_logger.Object, _repositoriKegiatan.Object);
        }

        [Fact]
        public async Task Index_Should_ReturnViewResultObject()
        {
            //Arrange
            var daftarKegiatan = new List<Kegiatan>();
            _repositoriKegiatan.Setup(r => r.GetAllWithDetail()).ReturnsAsync(daftarKegiatan);

            //Act
            var result = await _homeController.Index();

            //Assert
            result.Should().NotBeNull();
            var viewResult = result.Should().BeOfType<ViewResult>().Subject;

            viewResult.Should().NotBeNull();
            viewResult.Model.Should().NotBeNull();
            viewResult.Model.Should().BeOfType<IndexVM>();
        }
    }
}

using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using webSITE.Controllers;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;

namespace webSITE.Test.Controllers
{
    public class FileControllerTests
    {
        private readonly Mock<IRepositoriMahasiswa> _repositoriMahasiswa;
        private readonly Mock<IRepositoriFoto> _repositoriFoto;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironment;

        private readonly FileController _fileController;

        public FileControllerTests()
        {
            //Dependencies
            _repositoriMahasiswa = new Mock<IRepositoriMahasiswa>();
            _repositoriFoto = new Mock<IRepositoriFoto>();
            _webHostEnvironment = new Mock<IWebHostEnvironment>();

            //SUT
            _fileController = new FileController(_repositoriMahasiswa.Object,
                _repositoriFoto.Object, _webHostEnvironment.Object);
        }

        [Fact]
        public async Task FotoProfil_Should_ReturnFileContentResult_WhenMahasiswaWithIdFound()
        {
            //Arrange
            string id = "1";
            var mahasiswa = new Mahasiswa() { Id = id };
            _repositoriMahasiswa.Setup(r => r.Get(id)).ReturnsAsync(mahasiswa);

            //Act
            var result = await _fileController.FotoProfil(id);

            //Assert
            result.Should().NotBeNull();
            var fileContentResult = result.Should().BeOfType<FileContentResult>().Subject;

            fileContentResult.Should().NotBeNull();
            fileContentResult.ContentType.Should().StartWith("image");
        }

        [Fact]
        public async Task FotoProfil_Should_ReturnNotFound_Result_WhenMahasiswaWithIdNotFound()
        {
            //Arrange
            Mahasiswa? mahasiswa = null;
            _repositoriMahasiswa.Setup(r => r.Get(It.IsAny<string>()))
                .ReturnsAsync(mahasiswa);

            //Act
            var result = await _fileController.FotoProfil(It.IsAny<string>());

            //Arrange
            result.Should().NotBeNull();
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Foto_Should_ReturnPhysicalFileResult_WhenFotoWithIdFound()
        {
            //Arrange
            int id = 1;
            string path = "image.jpg";
            Foto foto = new Foto() { Id = id, Path = path };
            _repositoriFoto.Setup(r => r.Get(id)).ReturnsAsync(foto);

            //Act
            var result = await _fileController.Foto(id);

            //Assert
            result.Should().NotBeNull();
            var physicalFileResult = result.Should().BeOfType<PhysicalFileResult>().Subject;

            physicalFileResult.Should().NotBeNull();
            physicalFileResult.ContentType.Should().Be($"image/{Path.GetExtension(path)}");
        }

        [Fact]
        public async Task Foto_Should_ReturnNotFoundResult_WhenFotoWithIdNotFound()
        {
            //Arrange
            Foto? foto = null;
            _repositoriFoto.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(foto);

            //Act
            var result = await _fileController.Foto(It.IsAny<int>());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}

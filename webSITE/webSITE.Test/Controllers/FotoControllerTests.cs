using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using webSITE.Controllers;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Models.FotoController;

namespace webSITE.Test.Controllers
{
    public class FotoControllerTests
    {
        private readonly Mock<IRepositoriKegiatan> _repositoriKegiatan;
        private readonly Mock<IRepositoriFoto> _repositoriFoto;

        private readonly FotoController _fotoController;

        public FotoControllerTests()
        {
            _repositoriKegiatan = new Mock<IRepositoriKegiatan>();
            _repositoriFoto = new Mock<IRepositoriFoto>();

            _fotoController = new FotoController(_repositoriFoto.Object, _repositoriKegiatan.Object);
        }

        [Fact]
        public async Task Index_Should_ReturnViewResultObject()
        {
            //Arrange
            var daftarFoto = new List<Foto>();
            var daftarKegiatan = new List<Kegiatan>();

            _repositoriFoto.Setup(r => r.GetAllWithKegiatan()).ReturnsAsync(daftarFoto);
            _repositoriKegiatan.Setup(r => r.GetAllWithDetail()).ReturnsAsync(daftarKegiatan);

            //Act
            var result = await _fotoController.Index();

            //Assert
            result.Should().NotBeNull();
            var viewResult = result.Should().BeOfType<ViewResult>().Subject;

            viewResult.Should().NotBeNull();
            viewResult.Model.Should().BeOfType<List<AlbumVM>>();
        }

        [Fact]
        public async Task Album_Should_ReturnViewResultObject_WhenIdKegiatanIsNotNull()
        {
            //Arrange
            int idKegiatan = 1;
            string namaKegiatan = "Kegiatan";
            var kegiatan = new Kegiatan { Id = idKegiatan, NamaKegiatan = namaKegiatan };

            _repositoriKegiatan.Setup(r => r.GetWithDetail(idKegiatan))
                .ReturnsAsync(kegiatan);

            //Act
            var result = await _fotoController.Album(idKegiatan, "");

            //Assert
            result.Should().NotBeNull();
            var viewResult = result.Should().BeOfType<ViewResult>().Subject;

            viewResult.Should().NotBeNull();
            var albumVM = viewResult.Model.Should().BeOfType<AlbumVM>().Subject;

            albumVM.IdKegiatan.Should().Be(idKegiatan);
            albumVM.NamaKegiatan.Should().Be(namaKegiatan);
        }

        [Fact]
        public async Task Album_Should_ReturnViewResultObject_WhenIdKegiatanIsNull()
        {
            //Arrange
            int? idKegiatan = null;
            string namaAlbum = "Lain - Lain";
            var daftarFoto = new List<Foto>();

            _repositoriFoto.Setup(r => r.GetAllWithKegiatan()).ReturnsAsync(daftarFoto);

            //Act
            var result = await _fotoController.Album(idKegiatan, "");

            //Assert
            result.Should().NotBeNull();
            var viewResult = result.Should().BeOfType<ViewResult>().Subject;

            viewResult.Should().NotBeNull();
            var albumVM = viewResult.Model.Should().BeOfType<AlbumVM>().Subject;

            albumVM.IdKegiatan.Should().Be(idKegiatan);
            albumVM.NamaKegiatan.Should().Be(namaAlbum);
        }

        [Fact]
        public async Task Album_Should_ReturnNotFoundResultObject_WhenIdKegiatanIsNotNullAndKegiatanIsNotFound()
        {
            //Arrange
            Kegiatan? kegiatan = null;

            _repositoriKegiatan.Setup(r => r.GetWithDetail(It.IsAny<int>()))
                .ReturnsAsync(kegiatan);

            //Act
            var result = await _fotoController.Album(It.IsAny<int>(), "");

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}

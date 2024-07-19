using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;
using webSITE.DataAccess.Data;
using webSITE.Domain;
using webSITE.Repositori.Implementasi;

namespace webSITE.Test.DataAccess.Repositori
{
    public class RepositoriFotoTests
    {
        private readonly Mock<AppDbContext> _appDbContext;

        private readonly RepositoriFoto _repositoriFoto;

        public RepositoriFotoTests()
        {
            //Dependencies
            _appDbContext = new Mock<AppDbContext>();

            //SUT
            _repositoriFoto = new RepositoriFoto(_appDbContext.Object);
        }

        [Fact]
        public async Task Get_Should_ReturnFoto_When_FotoWithFound()
        {
            //Arrange
            int id = 1;
            var foto = new Foto() { Id = id };

            _appDbContext.Setup(a => a.TblFoto)
                .ReturnsDbSet(new Foto[] { foto });

            //Act
            var result = await _repositoriFoto.Get(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Foto>();
        }
    }
}

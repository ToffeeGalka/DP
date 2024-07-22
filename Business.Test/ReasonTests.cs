using Business.Models;
using Business.Mappers;
using Business.Services;
using Moq;

namespace Business.Test
{
    public class ReasonTests
    {
        private Reason _reason;
        private Mock<IReasonMapper> _mapperMock;
        private ReasonService _underTest;
        private Mock<WebData.AppDbContext> _appDbContextMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IReasonMapper>();
            _appDbContextMock = new Mock<WebData.AppDbContext>();
            _underTest = new ReasonService(_appDbContextMock.Object, _mapperMock.Object);
        }
        [Test]
        public void AddReason_ValidateNameReasonIsNullOrEmpty()
        {
            //Arrange
            _reason = new Reason()
            {
                Id = 0,
                ReasonName = ""
            };
            //Act
            var act = _underTest.AddReason(_reason);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);

            //Arrange
            _reason = new Reason()
            {
                Id = 0,
                ReasonName = null
            };
            //Act
            act = _underTest.AddReason(_reason);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
    }
}

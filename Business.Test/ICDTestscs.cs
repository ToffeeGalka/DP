using Business.Models;
using Business.Mappers;
using Business.Services;
using Moq;

namespace Business.Test
{
    public class ICDTestscs
    {
        private ICD10 _icd;
        private Mock<IICDMapper> _mapperMock;
        private ICDService _underTest;
        private Mock<WebData.AppDbContext> _appDbContextMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IICDMapper>();
            _appDbContextMock = new Mock<WebData.AppDbContext>();
            _underTest = new ICDService(_appDbContextMock.Object, _mapperMock.Object);
        }
        [Test]
        public void AddICD_ValidateICDCodeIsNullOrEmpty()
        {
            //Arrange
            _icd = new ICD10()
            {
                Id = 0,
                ParentId = 0,
                ICDCode = "",
                NameCode ="111"          
            };
            //Act
            var act = _underTest.AddICD(_icd);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);

            //Arrange
            _icd = new ICD10()
            {
                Id = 0,
                ParentId = 0,
                ICDCode = null,
                NameCode = "111"
            };
            //Act
            act = _underTest.AddICD(_icd);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
        [Test]
        public void AddICD_ValidateNameCodeIsNullOrEmpty()
        {
            //Arrange
            _icd = new ICD10()
            {
                Id = 0,
                ParentId = 0,
                ICDCode = "111",
                NameCode = ""
            };
            //Act
            var act = _underTest.AddICD(_icd);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);

            //Arrange
            _icd = new ICD10()
            {
                Id = 0,
                ParentId = 0,
                ICDCode = "111",
                NameCode = null
            };
            //Act
            act = _underTest.AddICD(_icd);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
    }
}

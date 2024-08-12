using Business.Models;
using Business.Mappers;
using Business.Services;
using Moq;
using Business.Validators;

namespace Business.Test
{
    [TestFixture]
    public class ICDTestscs
    {
        private ICD10 _icd;
        private Mock<IICDMapper> _mapperMock;
        private ICDService _underTest;
        private Mock<WebData.AppDbContext> _appDbContextMock;
        private ICDValidator _icdValidatorMock;
      
        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IICDMapper>();
            _appDbContextMock = new Mock<WebData.AppDbContext>();
            _icdValidatorMock = new ICDValidator();
            _underTest = new ICDService(_appDbContextMock.Object, _mapperMock.Object, _icdValidatorMock);
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

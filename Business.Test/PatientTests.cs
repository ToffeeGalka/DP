using Business.Models;
using Business.Mappers;
using Business.Services;
using Moq;
using Business.Validators;

namespace Business.Test
{
    public class PatientTests
    { 
        private Patient _patient;
        private Mock<IPatientMapper> _mapperMock;
        private PatientService _underTest;
        private Mock<WebData.AppDbContext> _appDbContextMock;   
        private PatientValidator _validatorMock;
 
        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IPatientMapper>();
            _appDbContextMock = new Mock<WebData.AppDbContext>();
            _validatorMock = new PatientValidator();
            _underTest = new PatientService(_appDbContextMock.Object, _mapperMock.Object, _validatorMock);         
        }

        [Test]
        public void AddPatient_ValidateGenderIsInvalid()
        {
            //Arrange
            _patient = new Patient()
            {
                Id = 0,
                SurName = "111",
                Name = "111",
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Sex = "ò",
                Address = "",
                Phone = ""
            };

            //Act
             var act = _underTest.AddPatient(_patient);
            //Assert
             Assert.ThrowsAsync<Exception>(() => act);
        }

        [Test]
        public void AddPatient_ValidateSurNameIsNullOrEmpty()
        {
            //Arrange
            _patient = new Patient()
            {
                Id = 0,
                SurName = "",
                Name = "111",
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Sex = "ì",
                Address = "",
                Phone = ""
            };
            //Act
            var act = _underTest.AddPatient(_patient);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);

            _patient = new Patient()
            {
                Id = 0,
                SurName = null,
                Name = "111",
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Sex = "ì",
                Address = "",
                Phone = ""
            };
            //Act
            act = _underTest.AddPatient(_patient);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
        [Test]
        public void AddPatient_ValidateNameIsNullOrEmpty()
        {
            //Arrange
            _patient = new Patient()
            {
                Id = 0,
                SurName = "111",
                Name = "",
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Sex = "ì",
                Address = "",
                Phone = ""
            };
            //Act
            var act = _underTest.AddPatient(_patient);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);

            _patient = new Patient()
            {
                Id = 0,
                SurName = "111",
                Name = null,
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Sex = "ì",
                Address = "",
                Phone = ""
            };
            //Act
            act = _underTest.AddPatient(_patient);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
        [Test]
        public void AddPatient_ValidateAddressIsNullOrEmpty()
        {
            //Arrange
            _patient = new Patient()
            {
                Id = 0,
                SurName = "111",
                Name = "111",
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Sex = "ì",
                Address = "",
                Phone = ""
            };
            //Act
            var act = _underTest.AddPatient(_patient);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);

            _patient = new Patient()
            {
                Id = 0,
                SurName = "111",
                Name = "111",
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Sex = "ì",
                Address = null,
                Phone = ""
            };
            //Act
            act = _underTest.AddPatient(_patient);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }

        [Test]
        public void AddPatient_ValidateDateOfBirthIsInvalid()
        {
            //Arrange
            _patient = new Patient()
            {
                Id = 0,
                SurName = "111",
                Name = "111",
                SecName = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today).AddDays(1),
                Sex = "ì",
                Address = "111",
                Phone = ""
            };

            //Act
            var act = _underTest.AddPatient(_patient);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
    }
}
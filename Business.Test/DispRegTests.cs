using Business.Models;
using Business.Mappers;
using Business.Services;
using Moq;
using System;

namespace Business.Test
{
    public class DispRegTests
    { 
        private DispReg _dispReg;
        private Mock<IDispRegMapper> _mapperMock;
        private DispRegService _underTest;
        private Mock<WebData.AppDbContext> _appDbContextMock;       
 
        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IDispRegMapper>();
            _appDbContextMock = new Mock<WebData.AppDbContext>();
            _underTest = new DispRegService(_appDbContextMock.Object, _mapperMock.Object);         
        }

        [Test]
        public void AddDispReg_ValidateDateTakenIsInvalid()
        {
            //Arrange
            _dispReg = new DispReg()
            {
                Id = 0,
                IdPatient = 0,
                DateTaken = DateOnly.FromDateTime(DateTime.Today).AddDays(1),
                IdICD = 0,
                IdDoctor = 0,
                DateNotTaken = DateOnly.FromDateTime(DateTime.Today),
                IdReason = 0           
            };
            //Act
            var act = _underTest.AddDispReg(_dispReg);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }

        [Test]
        public void AddDispReg_ValidateDateNotTakenIsInvalid()
        {
            //Arrange
            _dispReg = new DispReg()
            {
                Id = 0,
                IdPatient = 1,
                DateTaken = DateOnly.FromDateTime(DateTime.Today),
                IdICD = 1,
                IdDoctor = 1,
                DateNotTaken = DateOnly.FromDateTime(DateTime.Today).AddDays(1),
                IdReason = 1
            };
            //Act
            var act = _underTest.AddDispReg(_dispReg);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
    }
}
﻿using Business.Models;
using Business.Mappers;
using Business.Services;
using Moq;
using Business.Validators;

namespace Business.Test
{
    [TestFixture]
    public class PostTests
    {
        private Post _post;
        private Mock<IPostMapper> _mapperMock;
        private PostService _underTest;
        private Mock<WebData.AppDbContext> _appDbContextMock;
        private PostValidator _validatorMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IPostMapper>();
            _appDbContextMock = new Mock<WebData.AppDbContext>();
            _validatorMock = new PostValidator();
            _underTest = new PostService(_appDbContextMock.Object, _mapperMock.Object, _validatorMock);
        }
        [Test]
        public void AddPost_ValidateNamePostIsNullOrEmpty()
        {
            //Arrange
            _post = new Post()
            {
                Id = 0,
                PostName = ""
            };
            //Act
            var act = _underTest.AddPost(_post);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);

            //Arrange
            _post = new Post()
            {
                Id = 0,
                PostName = null
            };
            //Act
            act = _underTest.AddPost(_post);
            //Assert
            Assert.ThrowsAsync<Exception>(() => act);
        }
    }
}

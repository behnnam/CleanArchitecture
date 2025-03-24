using Blog.Api.Command.DtoOut;
using BlogApi.Application.Services.implementation;
using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogTest
{
    [TestFixture]
    public class GetPostTest
    {
        private Mock<IGetPostRepository> _mockRepository;
        private GetPostService _service;


        [Test]
        public async Task GetAllPostAsync_WhenNoPosts_ReturnsNotFoundResult()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAllPostAsync()).ReturnsAsync(new List<Posts>());

            // Act
            var result = await _service.GetAllPostAsync();

            // Assert
            Assert.AreEqual(0, result.ResultCode);
            Assert.AreEqual("اطلاعات یافت نشد", result.ResultMessage);
            Assert.IsNull(result.Obj);
        }

        [Test]
        public async Task GetAllPostAsync_WhenPostsExist_ReturnsSuccessResult()
        {
            // Arrange
            var posts = new List<Posts>
            {
                new Posts { /* Initialize properties */ },
                new Posts { /* Initialize properties */ }
            };
            _mockRepository.Setup(repo => repo.GetAllPostAsync()).ReturnsAsync(posts);

            // Act
            var result = await _service.GetAllPostAsync();

            // Assert
            Assert.AreEqual(200, result.ResultCode);
            Assert.AreEqual("موفق", result.ResultMessage);
            Assert.AreEqual(posts, result.Obj);
        }
    }
}

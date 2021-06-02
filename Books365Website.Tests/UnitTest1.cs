using Books365WebSite.Controllers;
using Books365WebSite.Models;
using Books365WebSite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Books365Website.Tests
{
    public class UnitTest1: IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;
        private UserManager<User> _userManager;

        public UnitTest1(DbFixture fixture)
        {
            var store = new Mock<IUserStore<User>>();
            _userManager = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void IndexGetBooksControllerTest()
        {
            //Arrange
            var context = _serviceProvider.GetService<Context>();

            //Act
            HomeController controller = new HomeController(_userManager, context);
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetBooksHomeControllerTest()
        {
            //Arrange
            var context = _serviceProvider.GetService<Context>();

            //Act
            HomeController controller = new HomeController(_userManager, context);
            ViewResult result = await controller.GetBooks() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public  void GetUserBooksHomeControllerTest()
        {
            //Arrange
            var context = _serviceProvider.GetService<Context>();

            //Act
            HomeController controller = new HomeController(_userManager, context);
            ViewResult result = controller.Index() as ViewResult;
            
            
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void UpsertHomeControllerTest()
        {

            //Arrange
            var context = _serviceProvider.GetService<Context>();
            Book fakeBook = new()
            {
                Author = "Kyryl Halmiz",
                Genre = "Fiction",
                Pages = 500,
                Title = "Robots war"
            };

            await context.AddAsync(fakeBook);
            await context.SaveChangesAsync();

            //Act
            HomeController controller = new HomeController(_userManager, context);

            ViewResult result = await controller.Upsert(fakeBook.Isbn) as ViewResult;
            CreatingViewModel model = (CreatingViewModel)result.Model;

            context.Remove(fakeBook);
            await context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(model.Book.Author, fakeBook.Author);
            Assert.Equal(model.Book.Title, fakeBook.Title);
            Assert.Equal(model.Book.Genre, fakeBook.Genre);
            Assert.Null(model.Status);
        }
    }
}

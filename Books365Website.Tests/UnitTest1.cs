using Books365WebSite.Controllers;
using Books365WebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Xunit;

namespace Books365Website.Tests
{
    public class UnitTest1: IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;
        public UnitTest1(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }
        [Fact]
        public void IndexGetBooksControllerTest()
        {
            var store = new Mock<IUserStore<User>>();

            UserManager<User> _userManager = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var context = _serviceProvider.GetService<Context>();
            HomeController controller = new HomeController(_userManager, context);
            ViewResult result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void GetUserBooksControllerTest()
        {
            var store = new Mock<IUserStore<User>>();

            UserManager<User> _userManager = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var context = _serviceProvider.GetService<Context>();
            HomeController controller = new HomeController(_userManager, context);
            ViewResult result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void IndexUserBooks()
        {
            var store = new Mock<IUserStore<User>>();

            UserManager<User> _userManager = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var context = _serviceProvider.GetService<Context>();
            HomeController controller = new HomeController(_userManager, context);
            ViewResult result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }
    }
}

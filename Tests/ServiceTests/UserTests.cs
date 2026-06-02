using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Services;
using Data.Data;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Tests.Helpers;

namespace Tests.ServiceTests
{
    public class UserTests
    {
        [Test]
        public async Task CreateUserAsync_ShouldAddUser()
        {
            using var context = TestDBShop.CreateContext();

            var service = new UserService(context);

            var user = new User
            {
                Username = "testuser",
                Email = "test@test.com",
                PasswordHash = "123",
                Role = Roles.Buyer
            };

            await service.CreateUserAsync(user);

            var saved = await context.Users.FirstOrDefaultAsync();

            Assert.That(saved, Is.Not.Null);
            Assert.That(saved!.Username, Is.EqualTo("testuser"));
            Assert.That(saved.Email, Is.EqualTo("test@test.com"));
        }

        [Test]
        public async Task GetAllUsersAsync_ShouldReturnUsersWithProductsAndOrders()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store { Name = "Store" };

            var seller = new User
            {
                Username = "seller",
                Email = "seller@test.com",
                PasswordHash = "123",
                Role = Roles.Seller
            };

            var buyer = new User
            {
                Username = "buyer",
                Email = "buyer@test.com",
                PasswordHash = "123",
                Role = Roles.Buyer
            };

            var product = new Product
            {
                Name = "Laptop",
                Description = "Gaming laptop",
                Price = 2000m,
                Quantity = 1,
                Seller = seller,
                Store = store
            };

            context.AddRange(store, seller, buyer, product);
            await context.SaveChangesAsync();

            var order = new Order
            {
                Buyer = buyer,
                Product = product,
                TotalPrice = 2000m
            };

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            var result = await service.GetAllUsersAsync();

            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result.Any(u => u.Products.Any()), Is.True);
            Assert.That(result.Any(u => u.Orders.Any()), Is.True);
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnUserWithRelations()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store { Name = "Store" };

            var user = new User
            {
                Username = "john",
                Email = "john@test.com",
                PasswordHash = "123",
                Role = Roles.Buyer
            };

            var product = new Product
            {
                Name = "Phone",
                Description = "Smartphone",
                Price = 1000m,
                Quantity = 1,
                Seller = user,
                Store = store
            };

            context.AddRange(store, user, product);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            var result = await service.GetUserByIdAsync(user.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Username, Is.EqualTo("john"));
            Assert.That(result.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteUserAsync_ShouldRemoveUser()
        {
            using var context = TestDBShop.CreateContext();

            var user = new User
            {
                Username = "deleteMe",
                Email = "delete@test.com",
                PasswordHash = "123",
                Role = Roles.Buyer
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            await service.DeleteUserAsync(user.Id);

            var exists = await context.Users.AnyAsync(u => u.Id == user.Id);

            Assert.That(exists, Is.False);
        }

        [Test]
        public async Task Login_ShouldReturnUser_WhenCredentialsAreCorrect()
        {
            using var context = TestDBShop.CreateContext();

            var user = new User
            {
                Username = "loginUser",
                Email = "login@test.com",
                PasswordHash = "pass123",
                Role = Roles.Buyer
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            var result = await service.Login("loginUser", "pass123");

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Username, Is.EqualTo("loginUser"));
        }

        [Test]
        public async Task Login_ShouldReturnNull_WhenCredentialsAreWrong()
        {
            using var context = TestDBShop.CreateContext();

            var user = new User
            {
                Username = "loginUser",
                Email = "login@test.com",
                PasswordHash = "pass123",
                Role = Roles.Buyer
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            var result = await service.Login("loginUser", "wrongPassword");

            Assert.That(result, Is.Null);
        }
    }
}

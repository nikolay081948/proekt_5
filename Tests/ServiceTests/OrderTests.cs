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
    public class OrderTests
    {
        [Test]
        public async Task CreateOrderAsync_ShouldCreateOrderAndCalculateTotalPrice()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store
            {
                Name = "Tech Store"
            };

            var seller = new User
            {
                Username = "seller1",
                Email = "seller@test.com",
                PasswordHash = "hashed-password",
                Role = Roles.Seller
            };

            var buyer = new User
            {
                Username = "buyer1",
                Email = "buyer@test.com",
                PasswordHash = "hashed-password",
                Role = Roles.Buyer
            };

            var product = new Product
            {
                Name = "Gaming Mouse",
                Description = "RGB Gaming Mouse",
                Price = 50m,
                Quantity = 2,
                Seller = seller,
                Store = store
            };

            context.Stores.Add(store);
            context.Users.AddRange(seller, buyer);
            context.Products.Add(product);

            await context.SaveChangesAsync();

            var service = new OrderService(context);

            var order = new Order
            {
                Buyer = buyer,
                BuyerId = buyer.Id,
                Product = product,
                ProductId = product.Id
            };

            await service.CreateOrderAsync(order);

            var savedOrder = await context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Product)
                .FirstOrDefaultAsync();

            await context.SaveChangesAsync();


            Assert.That(savedOrder, Is.Not.Null);
            Assert.That(savedOrder.TotalPrice, Is.EqualTo(100m));
            Assert.That(savedOrder.Buyer.Role, Is.EqualTo(Roles.Buyer));
            Assert.That(savedOrder.Product.Name, Is.EqualTo("Gaming Mouse"));

        }
        [Test]
        public async Task GetAllOrdersAsync_ShouldReturnAllOrdersWithBuyerAndProduct()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store
            {
                Name = "Tech Store"
            };

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
                Description = "Gaming Laptop",
                Price = 1500m,
                Quantity = 1,
                Seller = seller,
                Store = store
            };

            context.AddRange(store, seller, buyer, product);

            await context.SaveChangesAsync();

            context.Orders.AddRange(
                new Order
                {
                    Buyer = buyer,
                    Product = product,
                    TotalPrice = 1500m
                },
                new Order
                {
                    Buyer = buyer,
                    Product = product,
                    TotalPrice = 1500m
                });

            await context.SaveChangesAsync();

            var service = new OrderService(context);

            var result = await service.GetAllOrdersAsync();

            Assert.That(result.Count, Is.EqualTo(2));

            foreach (var order in result)
            {
                Assert.That(order.Buyer, Is.Not.Null);
                Assert.That(order.Product, Is.Not.Null);
            }
        }
        [Test]
        public async Task GetOrderByIdAsync_ShouldReturnCorrectOrder()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store
            {
                Name = "Book Store"
            };

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
                Name = "Book",
                Description = "C# Fundamentals",
                Price = 40m,
                Quantity = 1,
                Seller = seller,
                Store = store
            };

            var order = new Order
            {
                Buyer = buyer,
                Product = product,
                TotalPrice = 40m
            };

            context.Add(order);

            await context.SaveChangesAsync();

            var service = new OrderService(context);

            var result = await service.GetOrderByIdAsync(order.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Buyer.Username, Is.EqualTo("buyer"));
            Assert.That(result.Product.Name, Is.EqualTo("Book"));
            Assert.That(result.TotalPrice, Is.EqualTo(40m));
        }
        [Test]
        public async Task GetOrderByIdAsync_ShouldReturnNull_WhenOrderDoesNotExist()
        {
            using var context = TestDBShop.CreateContext();

            var service = new OrderService(context);

            var result = await service.GetOrderByIdAsync(999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task DeleteOrderAsync_ShouldRemoveOrder()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store
            {
                Name = "Store"
            };

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
                Name = "Keyboard",
                Description = "Mechanical Keyboard",
                Price = 100m,
                Quantity = 1,
                Seller = seller,
                Store = store
            };

            var order = new Order
            {
                Buyer = buyer,
                Product = product,
                TotalPrice = 100m
            };

            context.Add(order);

            await context.SaveChangesAsync();

            var service = new OrderService(context);

            await service.DeleteOrderAsync(order.Id);

            Assert.That(context.Orders.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteOrderAsync_ShouldDoNothing_WhenOrderDoesNotExist()
        {
            using var context = TestDBShop.CreateContext();

            var service = new OrderService(context);

            await service.DeleteOrderAsync(999);

            Assert.That(context.Orders.Count(), Is.EqualTo(0));
        }
    }

}


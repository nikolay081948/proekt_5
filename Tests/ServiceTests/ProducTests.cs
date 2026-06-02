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
    public class ProducTests
    {
        [Test]
        public async Task AddProductAsync_ShouldAddProduct()
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

            context.AddRange(store, seller);
            await context.SaveChangesAsync();

            var service = new ProductService(context);

            var product = new Product
            {
                Name = "Laptop",
                Description = "Gaming Laptop",
                Price = 2000m,
                Quantity = 2,
                Seller = seller,
                Store = store
            };

            await service.AddProductAsync(product);

            var saved = await context.Products.FirstOrDefaultAsync();

            Assert.That(saved, Is.Not.Null);
            Assert.That(saved!.Name, Is.EqualTo("Laptop"));
            Assert.That(saved.Price, Is.EqualTo(2000m));
        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
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

            context.AddRange(store, seller);
            await context.SaveChangesAsync();

            context.Products.AddRange(
                new Product
                {
                    Name = "Mouse",
                    Description = "Gaming mouse",
                    Price = 50m,
                    Quantity = 1,
                    Seller = seller,
                    Store = store
                },
                new Product
                {
                    Name = "Keyboard",
                    Description = "Gaming Keyboard",
                    Price = 100m,
                    Quantity = 1,
                    Seller = seller,
                    Store = store
                });

            await context.SaveChangesAsync();

            var service = new ProductService(context);

            var result = await service.GetAllProductsAsync();

            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result.All(p => p.Seller != null), Is.True);
            Assert.That(result.All(p => p.Store != null), Is.True);
            Assert.That(result.All(p => p.Orders != null), Is.True);
        }

        [Test]
        public async Task GetProductByIdAsync_ShouldReturnProduct()
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

            var product = new Product
            {
                Name = "Monitor",
                Description = "Gaming Monitor",

                Price = 300m,
                Quantity = 1,
                Seller = seller,
                Store = store
            };

            context.Add(product);
            await context.SaveChangesAsync();

            var service = new ProductService(context);

            var result = await service.GetProductByIdAsync(product.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("Monitor"));
            Assert.That(result.Price, Is.EqualTo(300m));
            Assert.That(result.Seller, Is.Not.Null);
            Assert.That(result.Store, Is.Not.Null);
        }

        [Test]
        public async Task GetAllProductsByStoreIdAsync_ShouldReturnOnlyStoreProducts()
        {
            using var context = TestDBShop.CreateContext();

            var store1 = new Store { Name = "Store1" };
            var store2 = new Store { Name = "Store2" };

            var seller = new User
            {
                Username = "seller",
                Email = "seller@test.com",
                PasswordHash = "123",
                Role = Roles.Seller
            };

            context.AddRange(store1, store2, seller);
            await context.SaveChangesAsync();

            context.Products.AddRange(
                new Product
                {
                    Name = "A",
                    Description = "Gaming Keyboard",
                    Price = 10m,
                    Quantity = 1,
                    Seller = seller,
                    Store = store1
                },
                new Product
                {
                    Name = "B",
                    Description = "Gaming Keyboard",
                    Price = 20m,
                    Quantity = 1,
                    Seller = seller,
                    Store = store1
                },
                new Product
                {
                    Name = "C",
                    Description = "Gaming Keyboard",
                    Price = 30m,
                    Quantity = 1,
                    Seller = seller,
                    Store = store2
                });

            await context.SaveChangesAsync();

            var service = new ProductService(context);

            var result = await service.GetAllProductsByStoreIdAsync(store1.Id);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(p => p.Store.Id == store1.Id), Is.True);
        }

        [Test]
        public async Task DeleteProductAsync_ShouldRemoveProduct()
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

            var product = new Product
            {
                Name = "Tablet",
                Description = "Gaming Tablet",
                Price = 500m,
                Quantity = 1,
                Seller = seller,
                Store = store
            };

            context.Add(product);
            await context.SaveChangesAsync();

            var service = new ProductService(context);

            await service.DeleteProductAsync(product.Id);

            var exists = await context.Products.AnyAsync();

            Assert.That(exists, Is.False);
        }

        [Test]
        public async Task DeleteProductAsync_ShouldDoNothing_WhenProductDoesNotExist()
        {
            using var context = TestDBShop.CreateContext();

            var service = new ProductService(context);

            await service.DeleteProductAsync(999);

            Assert.That(await context.Products.CountAsync(), Is.EqualTo(0));
        }
    }
}

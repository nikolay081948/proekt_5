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
    public class StoreTests
    {
        [Test]
        public async Task CreateStoreAsync_ShouldAddStore()
        {
            using var context = TestDBShop.CreateContext();

            var service = new StoreService(context);

            var store = new Store
            {
                Name = "Tech Store"
            };

            await service.CreateStoreAsync(store);

            var saved = await context.Stores.FirstOrDefaultAsync();

            Assert.That(saved, Is.Not.Null);
            Assert.That(saved!.Name, Is.EqualTo("Tech Store"));
        }

        [Test]
        public async Task GetAllStoresAsync_ShouldReturnAllStoresWithProducts()
        {
            using var context = TestDBShop.CreateContext();

            var store1 = new Store { Name = "Store 1" };
            var store2 = new Store { Name = "Store 2" };

            var seller = new User
            {
                Username = "seller",
                Email = "seller@test.com",
                PasswordHash = "123",
                Role = Roles.Seller
            };

            context.AddRange(store1, store2, seller);
            await context.SaveChangesAsync();

            var product = new Product
            {
                Name = "Laptop",
                Description = "Gaming laptop",
                Price = 2000m,
                Quantity = 1,
                Seller = seller,
                Store = store1
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            var service = new StoreService(context);

            var result = await service.GetAllStoresAsync();

            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result.Any(s => s.Products.Any()), Is.True);
        }

        [Test]
        public async Task GetStoreByIdAsync_ShouldReturnStoreWithProducts()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store
            {
                Name = "My Store"
            };

            var seller = new User
            {
                Username = "seller",
                Email = "seller@test.com",
                PasswordHash = "123",
                Role = Roles.Seller
            };

            var product = new Product
            {
                Name = "Mouse",
                Description = "Gaming mouse",
                Price = 50m,
                Quantity = 2,
                Seller = seller,
                Store = store
            };

            context.AddRange(store, seller, product);
            await context.SaveChangesAsync();

            var service = new StoreService(context);

            var result = await service.GetStoreByIdAsync(store.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("My Store"));
            Assert.That(result.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteStoreAsync_ShouldRemoveStore()
        {
            using var context = TestDBShop.CreateContext();

            var store = new Store
            {
                Name = "Delete Store"
            };

            context.Stores.Add(store);
            await context.SaveChangesAsync();

            var service = new StoreService(context);

            await service.DeleteStoreAsync(store.Id);

            var exists = await context.Stores.AnyAsync(s => s.Id == store.Id);

            Assert.That(exists, Is.False);
        }

        [Test]
        public async Task DeleteStoreAsync_ShouldDoNothing_WhenStoreDoesNotExist()
        {
            using var context = TestDBShop.CreateContext();

            var service = new StoreService(context);

            await service.DeleteStoreAsync(999);

            Assert.That(await context.Stores.CountAsync(), Is.EqualTo(0));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Tests.Helpers
{
    public class TestDBShop
    {
        public static StoreContext CreateContext()
        {
            var options=new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            StoreContext context = new StoreContext(options);
            context.Database.EnsureCreated();
            return context;
        } 
    }
}

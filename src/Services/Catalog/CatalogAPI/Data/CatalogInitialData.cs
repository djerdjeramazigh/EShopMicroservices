﻿using Marten.Schema;

namespace CatalogAPI.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProduct());
            await session.SaveChangesAsync();

        }

        private static IEnumerable<Product> GetPreconfiguredProduct() => new List<Product>{
            new Product()
            {
                Id =new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                Name="IPhone X",
                Description="This phone is the company's biggest change to its ",
                ImageFile= "product-1.png",
                Price = 950.00M,
                Category= new List<string>{"Smart Phone"}
            },
            new Product()
            {
                Id =new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                Name="Samsung 10",
                Description="This phone is the company's biggest change to its",
                ImageFile= "product-2.png",
                Price = 840.00M,
                Category= new List<string>{"Smart Phone" }
            }
            };
    }
}

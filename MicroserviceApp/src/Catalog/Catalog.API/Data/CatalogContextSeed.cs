using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProduct());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProduct()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "product1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "product1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "product1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "product1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "product1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}
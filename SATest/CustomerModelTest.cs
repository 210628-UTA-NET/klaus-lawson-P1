using Microsoft.EntityFrameworkCore;
using SADL;
using SAModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace SATest
{
    public class CustomerModelTest
    {
        private readonly DbContextOptions<SADBContext> _options;
        public CustomerModelTest()
        {
            _options = new DbContextOptionsBuilder<SADBContext>().UseSqlite("Filename = test1.db").Options;
            this.Seed();
        }
        [Fact]
        public void GetStoreProductShouldreturnProducts()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Product listP= new Product();

                //Act
                listP = repo.GetProductById(1);

                //Assert
                Assert.NotNull(listP);
            }
        }
        [Fact]
        public void GetListProductByStoreId()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                List<Product> listP= new List<Product>();

                //Act
                listP = repo.GetProductsByStoreId(1);

                //Assert
                Assert.NotNull(listP);
            }
        }

        private void Seed()
        {
            using (var context = new SADBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Products.AddRange(
                    new Product()
                    {
                        ProductName = "Tshirt",
                        ProductDescription= "blablabla",
                        ProductAvailableQty=50,
                        ProductUnitPrice=39,
                        Category = new Category()
                        {
                            CategoryName="scholing",
                            CategoryDescription="hjqwfxgsduif",
                        },
                        Store = new Store()
                        {
                            StoreName = "Store A",
                            StorePhone = "6122050000",
                            StoreAddress = new Address()
                            {
                                Street = "2630 9th st",
                                City = "Anoko",
                                State = "Minnesota",
                                Country = "us",
                            },
                        },
                    });
                context.Stores.AddRange(
                    new Store()
                    {
                        StoreName = "Store A",
                        StorePhone = "6122050000",
                        StoreAddress = new Address()
                        {
                            Street = "2630 9th st",
                            City = "Anoko",
                            State = "Minnesota",
                            Country = "us",
                        },
                    },
                    new Store()
                    {
                        StoreName = "Store B",
                        StorePhone = "6122050000",
                        StoreAddress = new Address()
                        {
                            Street = "2630 9th st",
                            City = "Anoko",
                            State = "Minnesota",
                            Country = "us",
                        },
                    });

                context.SaveChanges();
            }

        }
    }
}

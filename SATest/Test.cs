using Microsoft.EntityFrameworkCore;
using SADL;
using SAModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace SATest
{
    public class Test
    {
        private readonly DbContextOptions<SADBContext> _options;
        public Test()
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
                Product listP = new Product();

                //Act
                listP = repo.GetProductById(1);

                //Assert
                Assert.NotNull(listP);
            }
        }
        [Fact]
        public void UpdateProductQtyShouldChangePropertiesInDB()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Product tryUpdatePrd = new Product()
                {
                    Id = 1,
                    ProductName = "Tshirt",
                    ProductDescription = "blablabla",
                    ProductAvailableQty = 49,
                    ProductUnitPrice = 39,
                    StoreId = 1,
                    CategoryId = 1,
                }
                    ;

                //Act
                Product c = repo.UpdateProduct(tryUpdatePrd);

                //Assert
                Assert.NotNull(c);
                Assert.NotEqual(50, c.ProductAvailableQty);
            }
        }
        [Fact]
        public void GetListProductByStoreId()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                List<Product> listP = new List<Product>();

                //Act
                listP = repo.GetProductsByStoreId(1);

                //Assert
                Assert.NotNull(listP);
            }
        }
        [Fact]
        public void GetOrderByCustomerShouldReturnListOfOrder()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                List<Order> listP = new List<Order>();

                //Act
                listP = repo.GetOrdersByCustomerId(1);

                //Assert
                Assert.NotNull(listP);
            }
        }
        [Fact]
        public void GetOrderById()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Order listP = new Order();

                //Act
                listP = repo.GetOrderById(1);

                //Assert
                Assert.NotNull(listP);
            }
        }

        [Fact]
        public void GetOrdersByStoreIdShouldreturnListOfOrders()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Order listP = new Order();

                //Act
                listP = repo.GetOrderById(1);

                //Assert
                Assert.NotNull(listP);
            }
        }
        [Fact]
        public void GetOrders()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Order listP = new Order();

                //Act
                listP = repo.GetOrderById(1);

                //Assert
                Assert.NotNull(listP);
            }
        }
        [Fact]
        public void DeleteOrderShouldDelete()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                bool deleted = false;

                //Act
                deleted = repo.DeleteOrderById(1);

                //Assert
                Assert.True(deleted);
            }
        }

        [Fact]
        public void DeleteProductShouldDelete()
        {

            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                bool deleted = false;

                //Act
                deleted = repo.DeleteProductById(1);

                //Assert
                Assert.True(deleted);
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
                context.Orders.AddRange(
                    new Order()
                    {
                        Location = "store K",
                        OrderTotalPrice = 120,
                        OrderDate = DateTime.Now,
                        OrderStatus = "PLACED",
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
                        Customer = new Customer()
                        {
                            CustomerFirstName = "klaus",
                            CustomerLastName = "lawson",
                            CustomerEmail = "klaus@gmail.com",
                            CustomerPhone = "6122298552",
                            CustomerPassword = "12587",
                            CustomerAddressId = 2,
                            CustomerAddress = new Address()
                            {
                                Street = "2630 9th st",
                                City = "Anoka",
                                State = "Minnesota",
                                Country = "us",
                            },
                        },
                    }
                    );
                context.SaveChanges();
            }

        }
    }
}

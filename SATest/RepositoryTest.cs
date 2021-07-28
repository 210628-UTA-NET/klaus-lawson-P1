using Microsoft.EntityFrameworkCore;
using SADL;
using SAModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SATest
{
   
    public class RepositoryTest
    {
        private readonly DbContextOptions<SADBContext> _options;
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<SADBContext>().UseSqlite("Filename = test.db").Options;
            this.Seed();
        }

        [Fact]
        public void GetAllCustomerShouldGetAllCustomer()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                List<Customer> allCustomer;

                //Act
                allCustomer = repo.GetAllCustomers();

                //Assert
                Assert.NotNull(allCustomer);
                Assert.Equal(2, allCustomer.Count);
            }
        }
        [Fact]
        public void FindSpecificCustomer()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Customer trytoFindCustomer = new Customer()
                {
                    CustomerEmail = "klaus@gmail.com",
                    CustomerPassword = "12587",
                };

                //Act
                Customer foundCustomer = repo.FindCustomerLogin(trytoFindCustomer.CustomerEmail,trytoFindCustomer.CustomerPassword);

                //Assert
                Assert.NotNull(foundCustomer);
                Assert.Equal(foundCustomer.CustomerEmail, trytoFindCustomer.CustomerEmail);
            }
        }
        [Fact]
        public void UpdateCustomerShouldChangePropertiesInDB()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Customer tryUpdateCustomer = repo.FindCustomerById(1);

                //Act
                tryUpdateCustomer.CustomerLastName = "Djecky";
                Customer c = repo.UpdateCustomer(tryUpdateCustomer);

                //Assert
                Assert.NotNull(tryUpdateCustomer);
                Assert.Equal("Djecky", c.CustomerLastName);
            }
        }

        [Fact]
        public void AddCustomerShouldIncreaseCustomerList()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                int count;
                //act
                Customer addCustomer = repo.AddCustomer(new Customer()
                {
                    CustomerFirstName = "toto",
                    CustomerLastName = "lawson",
                    CustomerEmail = "toto@gmail.com",
                    CustomerPhone = "6122298551",
                    CustomerPassword = "12584",
                    CustomerAddressId = 3,
                    CustomerAddress = new Address()
                    {
                        Street = "2630 9th st",
                        City = "Anoka",
                        State = "Minnesota",
                        Country = "us",
                    },
                });
                count = repo.GetAllCustomers().Count;
                


                //Assert
                Assert.NotNull(addCustomer);
                Assert.Equal(3, count);
            }
        }

        [Fact]
        public void SearchCustomerByName()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                string trytoFindCustomerName = "klaus";

                //Act
                List<Customer> listFoundCustomer = repo.FindCustomerByName(trytoFindCustomerName);

                //Assert
                Assert.NotNull(listFoundCustomer);
                Assert.Equal(1, listFoundCustomer.Count);
            }
        }

        [Fact]
        public void GetAllStoreShouldGetAllStore()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                List<Store> allStores;

                //Act
                allStores = repo.GetAllStores();

                //Assert
                Assert.NotNull(allStores);
                Assert.Equal(2, allStores.Count);
            }
        }
        [Fact]
        public void FindStoreByIdShouldReturnStore()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                int trytoFindStoreId = 1;

                //Act
                Store foundStore = repo.GetStoreById(trytoFindStoreId);

                //Assert
                Assert.NotNull(foundStore);
                Assert.Equal("Store A", foundStore.StoreName);
            }
        }
        [Fact]
        public void GetStoreWithAddressShouldReturnStoreAddress()
        {
            using (var context = new SADBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Address storeAddress = new Address();

                //Act
                storeAddress = repo.GetStoreWithAddressById(1).StoreAddress;

                //Assert
                Assert.NotNull(storeAddress);
                Assert.Equal("Anoko", storeAddress.City);
            }
        }

        private void Seed()
        {
            using (var context = new SADBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer()
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
                    new Customer()
                    {
                        CustomerFirstName = "tim",
                        CustomerLastName = "Von",
                        CustomerEmail = "tim@gmail.com",
                        CustomerPhone = "6122298551",
                        CustomerPassword = "14785",
                        CustomerAddressId = 1,
                        CustomerAddress = new Address()
                        {
                            Street = "0362 6th st",
                            City = "robbinson",
                            State = "Minnesota",
                            Country = "us",
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

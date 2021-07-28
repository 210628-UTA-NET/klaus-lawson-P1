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
                    }) ;
                context.SaveChanges();
            }
           
        }
    }
}

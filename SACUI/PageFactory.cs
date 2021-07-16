using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SACBL;
using SACDL;
using SACDL.Entities;

namespace SACUI{
    public class PageFactory :IPageFactory
    {
        public IPage GetPage(MenuType p_page){
            
            // Get the configuration from our appsetting.JSON file
              var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"C:\Users\klaus\Documents\Revature\StoreAppConsole\SACUI\appsetting.json")
                .Build();

            //Grabs our connectionString from our appsetting.json
            string connectionString = configuration.GetConnectionString("Reference2DB");

            DbContextOptions<AppStoreDbContext> options = new DbContextOptionsBuilder<AppStoreDbContext>()
                .UseSqlServer(connectionString)
                .Options;


            switch (p_page){
             // Page related to customer menu
                case MenuType.AddNewCustomer:
                    return new AddNewCustomer(new CustomerBL(new Repository(new AppStoreDbContext(options))));   
                case MenuType.SearchCustomer:
                    return new SearchCustomer(new CustomerBL(new Repository(new AppStoreDbContext(options))));    

            // Pages related to Store Front menu    
                case MenuType.ViewSFInventory:
                    return new ViewStoreFrontInventory(new CustomerBL(new Repository(new AppStoreDbContext(options))));  
                case MenuType.ReplenishInventory:
                    return new ReplenishInventory(new CustomerBL(new Repository(new AppStoreDbContext(options))));
                    
            //Pages related to Order menu
                case MenuType.PlaceOrder:
                    return new PlaceOrder(new CustomerBL(new Repository(new AppStoreDbContext(options))));
                case MenuType.ViewOrderHistory:
                    return new ViewOrderHistory(new CustomerBL(new Repository(new AppStoreDbContext(options))));

                default:
                    return null;
             }

        }
    }
}
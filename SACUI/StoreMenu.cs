using System;
namespace SACUI
{
    public class StoreMenu : IMenu
    {
         IPage StorePage ;
        IMenu mainMenu;
        bool repeat = true;
        string userChoice;
        MenuType currentMenu = MenuType.CustomerMenu;
        PageFactory pageFactory = new PageFactory();
        MenuFactory menuFactory = new MenuFactory();
        ResponseMessage responseMessage;
        
        /// <summary>
        /// StoreMenu(): Constructor of OrderMenu class. It initialize all the variable needed.
        /// </summary>
        public StoreMenu(){
            repeat = true;
            mainMenu = null;
            userChoice ="";
            currentMenu = MenuType.CustomerMenu;
            pageFactory = new PageFactory();
            menuFactory = new MenuFactory();
            responseMessage =new ResponseMessage();
        }
        
        /// <summary>
        /// DisplayMenu(): Display the StoreFront Menu
        /// </summary>
         public void DisplayMenu(){   
             Console.Clear();     
             MyConsole.WriteTitle(@"  
                                     _____ _                   __  __                  
                                    / ____| |                 |  \/  |                 
                                   | (___ | |_ ___  _ __ ___  | \  / | ___ _ __  _   _ 
                                    \___ \| __/ _ \| '__/ _ \ | |\/| |/ _ \ '_ \| | | |
                                    ____) | || (_) | | |  __/ | |  | |  __/ | | | |_| |
                                   |_____/ \__\___/|_|  \___| |_|  |_|\___|_| |_|\__,_|                                
                                
                                "); 
            MyConsole.WriteNormal("What will you like to do? (Please press the number key corresponding)");            
            MyConsole.WriteNormal("[2] View Store Front Inventory");
            MyConsole.WriteNormal("[1] replenish Inventory");
            MyConsole.WriteNormal("[0] Back to Main Menu");
            // call the local method Operation
            operation();
        }
        
         /// <summary>
        /// Operation(): Get the user choice and render the desired page or menu
        /// </summary>
        public void operation()
        {
            while (repeat)
            {
                 // get the MenuType (Contains just name of Menu and Page) that the user choose
                // we are using the local method GetUserChoice()
                currentMenu = GetUserChoice();
                // evaluates the case of the user choice , creates the corresponded Page/MainMenu, and display that page/MainMenu
                switch (currentMenu)
                {
                    case MenuType.ViewSFInventory:
                        StorePage = pageFactory.GetPage(MenuType.ViewSFInventory);
                        StorePage.DisplayPage();                        
                        break;
                   case MenuType.ReplenishInventory:
                        StorePage = pageFactory.GetPage(MenuType.ReplenishInventory);
                        StorePage.DisplayPage();
                        break;                    
                    case MenuType.MainMenu:
                        mainMenu =  menuFactory.GetMenu(MenuType.MainMenu);
                        mainMenu.DisplayMenu();
                        repeat = false;
                        break;
                    default:
                        MyConsole.WriteError(" SM !!! 404 Page not Found");
                        repeat = false;
                        break;
                }
            }
        }

        /// <summary>
        /// GetUserChoice(): Get the choice of the user and control the input using our Static class InpuValidation
        /// </summary>
        /// <returns>MenuType</returns>
        public MenuType GetUserChoice(){
            // loop do_while to control the choice of the user
            // using the static method InputValidation.IsInRange()
            do{
                MyConsole.WriteNormalOneLine("SM Your Choice : ");
                userChoice = Console.ReadLine();
                responseMessage = InputValidation.IsInRangeInt(userChoice,0,2);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);
            // follow the choice of the user, the return will be a MenuType(PlaceOrder/ViewOrderHistory/MainMenu)
            switch (userChoice){
                case "2":
                    return MenuType.ViewSFInventory;
                case "1":
                    return MenuType.ReplenishInventory;
                case "0":
                    return MenuType.MainMenu;
                default:
                    MyConsole.WriteError(" SM Undefined Error!");
                    Console.ReadLine();
                    return MenuType.StoreMenu;
            }
        }        
    }
}
using System;
namespace SACUI
{
    public class OrderMenu: IMenu
    {
        IPage OrderPage ;
        IMenu mainMenu;
        bool repeat;
        MenuType currentMenu;
        PageFactory pageFactory;
        MenuFactory menuFactory;
        string userChoice;
        ResponseMessage responseMessage;

        /// <summary>
        /// OrderMenu(): Constructor of OrderMenu class. It initialize all the variable needed.
        /// </summary>
        public OrderMenu(){
            repeat = true;
            mainMenu = null;
            currentMenu = MenuType.CustomerMenu;
            pageFactory = new PageFactory();
            menuFactory = new MenuFactory();
            responseMessage =new ResponseMessage();
        }
        
        /// <summary>
        /// DisplayMenu(): Display the Order Menu
        /// </summary>
        public void DisplayMenu(){  
            Console.Clear();     
            MyConsole.WriteTitle(@"  
                                  ____          _             __  __                  
                                 / __ \        | |           |  \/  |                 
                                | |  | |_ __ __| | ___ _ __  | \  / | ___ _ __  _   _ 
                                | |  | | '__/ _` |/ _ \ '__| | |\/| |/ _ \ '_ \| | | |
                                | |__| | | | (_| |  __/ |    | |  | |  __/ | | | |_| |
                                 \____/|_|  \__,_|\___|_|    |_|  |_|\___|_| |_|\__,_|                                                                                    
                                                                                    
                                                                                    "); 
            MyConsole.WriteNormal("What will you like to do? (Please press the number key corresponding)");            
            MyConsole.WriteNormal("[2] Place Order");
            MyConsole.WriteNormal("[1] View Order History");
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
                    case MenuType.PlaceOrder:
                        OrderPage = pageFactory.GetPage(MenuType.PlaceOrder);
                        OrderPage.DisplayPage();                        
                        break;
                   case MenuType.ViewOrderHistory:
                        OrderPage = pageFactory.GetPage(MenuType.ViewOrderHistory);
                        OrderPage.DisplayPage();
                        break;                    
                    case MenuType.MainMenu:
                        mainMenu =  menuFactory.GetMenu(MenuType.MainMenu);
                        mainMenu.DisplayMenu();
                        repeat = false;
                        break;
                    default:
                        MyConsole.WriteError(" OM !!! 404 Page not Found");
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
                MyConsole.WriteNormalOneLine("OM Your Choice : ");
                userChoice = Console.ReadLine();
                responseMessage = InputValidation.IsInRangeInt(userChoice,0,2);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);
            // follow the choice of the user, the return will be a MenuType(PlaceOrder/ViewOrderHistory/MainMenu)
            switch (userChoice){
                case "2":
                    return MenuType.PlaceOrder;
                case "1":
                    return MenuType.ViewOrderHistory;
                case "0":
                    return MenuType.MainMenu;
                default:
                    MyConsole.WriteError(" OM Undefined Error!");
                    Console.ReadLine();
                    return MenuType.StoreMenu;
            }
        }
    }
}
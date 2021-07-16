using System;
using SACBL;
using SACDL;

namespace SACUI
{
    public class CustomerMenu : IMenu
    {
        string userChoice;
        bool repeat;
        IPage custPage ;
        IMenu mainMenu;        
        MenuType currentMenu;
        PageFactory pageFactory;
        MenuFactory menuFactory;
        ResponseMessage responseMessage;

        /// <summary>
        /// Constructor of CustomerMenu class. It initialize all the variable needed.
        /// </summary>
        public CustomerMenu(){
            repeat = true;
            mainMenu = null;
            currentMenu = MenuType.CustomerMenu;
            pageFactory = new PageFactory();
            menuFactory = new MenuFactory();
            userChoice = "";
            responseMessage =new ResponseMessage();
        }
        
        /// <summary>
        /// DisplayMenu(): Display the Customer Menu
        /// </summary>
        public void DisplayMenu(){  
            Console.Clear();          
            MyConsole.WriteTitle(@"             
                                 _____           _                             ___  ___                 
                                /  __ \         | |                            |  \/  |                 
                                | /  \/_   _ ___| |_ ___  _ __ ___   ___ _ __  | .  . | ___ _ __  _   _ 
                                | |   | | | / __| __/ _ \| '_ ` _ \ / _ \ '__| | |\/| |/ _ \ '_ \| | | |
                                | \__/\ |_| \__ \ || (_) | | | | | |  __/ |    | |  | |  __/ | | | |_| |
                                 \____/\__,_|___/\__\___/|_| |_| |_|\___|_|    \_|  |_/\___|_| |_|\__,_|                                
                                 
                                 "); 
            MyConsole.WriteNormal("What will you like to do? (Please press the number key corresponding)");
            MyConsole.WriteNormal("[2] Add New Customer");
            MyConsole.WriteNormal("[1] Search a Customer");
            MyConsole.WriteNormal("[0] Back to Main Menu");
            
            operation();
        }
       
        /// <summary>
        ///  Operation(): get the user choice and render the desired page or menu
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
                    case MenuType.AddNewCustomer:
                        custPage = pageFactory.GetPage(MenuType.AddNewCustomer);
                        custPage.DisplayPage();                        
                        break;
                   case MenuType.SearchCustomer:
                        custPage = pageFactory.GetPage(MenuType.SearchCustomer);
                        custPage.DisplayPage();
                        break;
                    case MenuType.MainMenu:
                        mainMenu =  menuFactory.GetMenu(MenuType.MainMenu);
                        mainMenu.DisplayMenu();
                        repeat = false;
                        break;
                    default:
                        MyConsole.WriteError(" CM !!! 404 Page not Found");
                        repeat = false;
                        break;
                }
            }
        }
        
        /// <summary>
        /// GetUserChoice(): get the choice of the user and control the input using our Static class InpuValidation
        /// </summary>
        /// <returns>MenuType</returns>
        public MenuType GetUserChoice(){
            // loop do_while to control the choice of the user
            // using the static method InputValidation.IsInRange()
             do{
                    MyConsole.WriteNormalOneLine("CM Your Choice : ");
                    userChoice = Console.ReadLine();
                    responseMessage = InputValidation.IsInRangeInt(userChoice,0,2);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);

            // follow the choice of the user, the return will be a MenuType(AddNewCustomer/SearchCustomer/MainMenu)
             switch (userChoice){
                case "2":
                    return MenuType.AddNewCustomer;
                case "1":
                    return MenuType.SearchCustomer;
                case "0":
                    return MenuType.MainMenu;
                default:
                    MyConsole.WriteError(" CM Undefined Error!");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}
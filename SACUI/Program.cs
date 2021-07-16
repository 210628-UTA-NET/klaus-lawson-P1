using System;
using SACModels;

namespace SACUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Variable declaration
            IMenu mainMenu = new MainMenu();
            bool repeat = true;
            MenuType currentMenuType = MenuType.MainMenu;
            MenuFactory menuFactory = new MenuFactory();

            // the program begins with the Main menu DisplayMenu() method
            // followed by a while loop to decide if the user want to go to another Menu
            // the loop is controled by the variable repeat which is set at true to start 
            mainMenu.DisplayMenu();
             while (repeat)
            {
                // Each time the user come back to the main menu, new object of MainMenu is set
                // so that the mainMenu.GetUserChoice() can be executed. If not the GetUserChoice() of the previous
                // class will be
                mainMenu = new MainMenu();
                currentMenuType = mainMenu.GetUserChoice();

                switch (currentMenuType)
                {
                //     case MenuType.MainMenu:
                //         mainMenu = menuFactory.GetMenu(MenuType.MainMenu);
                //         mainMenu.DisplayMenu();
                //         break;
                    case MenuType.StoreMenu:
                        mainMenu = menuFactory.GetMenu(MenuType.StoreMenu);
                        mainMenu.DisplayMenu();
                        break;
                    case MenuType.OrderMenu:
                        mainMenu = menuFactory.GetMenu(MenuType.OrderMenu);
                        mainMenu.DisplayMenu();
                        break;
                    case MenuType.CustomerMenu:
                        mainMenu = menuFactory.GetMenu(MenuType.CustomerMenu);
                        mainMenu.DisplayMenu();
                        break;
                    case MenuType.Exit:
                        repeat = false;
                        break;
                    default:
                        MyConsole.WriteError("MM !!!404 Menu Not Found");
                        break;
                }
            }
        }
    }
}

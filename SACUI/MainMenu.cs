using System;

namespace SACUI
{
    
    public class MainMenu: IMenu
    {
        string userChoice ;
        ResponseMessage responseMessage =new ResponseMessage();
        
        /// <summary>
        /// Display the Main Menu
        /// </summary>
        public void DisplayMenu(){
            Console.Clear();            
            MyConsole.WriteTitle(@"
                                 ___ ___   ____  ____  ____       ___ ___    ___  ____   __ __ 
                                |   |   | /    ||    ||    \     |   |   |  /  _]|    \ |  |  |
                                | _   _ ||  o  | |  | |  _  |    | _   _ | /  [_ |  _  ||  |  |
                                |  \_/  ||     | |  | |  |  |    |  \_/  ||    _]|  |  ||  |  |
                                |   |   ||  _  | |  | |  |  |    |   |   ||   [_ |  |  ||  :  |
                                |   |   ||  |  | |  | |  |  |    |   |   ||     ||  |  ||     |
                                |___|___||__|__||____||__|__|    |___|___||_____||__|__| \__,_|
                                
                                ");
            MyConsole.WriteNormal("What will you like to do? (Please press the number key corresponding)");
            MyConsole.WriteNormal("[3] Customer Menu");
            MyConsole.WriteNormal("[2] Store Menu");
            MyConsole.WriteNormal("[1] Order Menu");
            MyConsole.WriteNormal("[0] Exit");
        }
        
        /// <summary>
        /// GetUserChoice() get the choice of the user and control the input using our Static class InpuValidation
        /// </summary>
        /// <returns>MenuType</returns>
        public MenuType GetUserChoice(){
            // loop do_while to control the choice of the user
            // using the static method InputValidation.IsInRange()
            do{
                MyConsole.WriteNormalOneLine("OM Your Choice : ");
                userChoice = Console.ReadLine();
                responseMessage = InputValidation.IsInRangeInt(userChoice,0,3);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);
            // follow the choice of the user, the return will be a MenuType(CustomerMenu/StoreMenu/OrderMenu/Exit)
             switch (userChoice){
                case "3":
                    return MenuType.CustomerMenu;
                case "2":
                    return MenuType.StoreMenu;
                case "1":
                    return MenuType.OrderMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    MyConsole.WriteError(" MM undefined Error !");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
        
        
    }
}

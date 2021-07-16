using System;
using System.Collections.Generic;
using SACModels;
using SACBL;
namespace SACUI
{
    public class ViewOrderHistory : IPage
    {
        ICustomerBL _custBL;
        int _YesNo;
        string _customerSearchKey;
        bool _viewOrderHistoryRepeat;
        string _choice;
        MenuFactory menuFactory ;
        StoreFront myStoreFront;
        Customer foundCustomer;
        List<Orders> listcustOrders;
        ResponseMessage responseMessage;
        IMenu orderMenu;
        public ViewOrderHistory(ICustomerBL p_custBL){
            _custBL = p_custBL;
            _customerSearchKey = "";
             _viewOrderHistoryRepeat = true;
            _choice = "N";
            menuFactory = new MenuFactory();
            responseMessage = new ResponseMessage();
            orderMenu = new OrderMenu();
        }
        public void DisplayPage()
        {
            while (_viewOrderHistoryRepeat)
            {
                _viewOrderHistoryRepeat = false;
                Console.Clear();
                MyConsole.WriteTitle(@"
                                                    
                                    \ /             _                                     
                                     V  o  _       / \ __ _| _  __   |_| o  _ _|_ _  __ \/
                                        | (/_\^/   \_/ | (_|(/_ |    | | | _>  |_(_) |  / 
                                                                                        
                                        ");
                ViewOrderHistoryOperation();
            }
            orderMenu = menuFactory.GetMenu(MenuType.OrderMenu);                 
            orderMenu.DisplayMenu();
        }
        
        public void ViewOrderHistoryOperation(){
            do{
                MyConsole.WriteNormal("Enter Customer Phone Number / Email: ");
                do{                   
                    MyConsole.WriteNormalOneLine("Phone / Email: ");
                    _customerSearchKey = Console.ReadLine();
                    responseMessage = InputValidation.IsNotNull(_customerSearchKey,30);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);

                foundCustomer = _custBL.FindCustomer(_customerSearchKey);
                if(foundCustomer!=null){
                    listcustOrders = _custBL.GetOrderOfCustomer(foundCustomer.Id);
                    Console.WriteLine($"List of orders of the customer {foundCustomer.Name}:");
                    int i = listcustOrders.Count;
                    foreach(Orders o in listcustOrders){
                        Console.WriteLine($"{i}---> {_custBL.FindStoreFrontByID(o.StoreFrontId).Name} ------ {o.TotalPrice}");
                        i--;
                    }
                }else{
                    MyConsole.WriteError("Customer not found");
                }
                
                Console.WriteLine("review Order history?");
                do{                    
                    MyConsole.WriteNormalOneLine("Y / N ? ==> ");
                    _choice = Console.ReadLine().ToUpper();
                    if (_choice == "Y"){
                        _viewOrderHistoryRepeat = true;
                        _YesNo =1;
                    }else if(_choice == "N")  {
                        _viewOrderHistoryRepeat = false;
                        _YesNo=1;
                    }  else{
                        Console.WriteLine(" Invalid input");
                        _YesNo =0;
                    }
                }while(_YesNo!=1 );
            }while(_viewOrderHistoryRepeat);               
        }
    }
}
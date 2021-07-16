using System;
using SACModels;
using SACBL;
using SACDL;
namespace SACUI
{
    public class SearchCustomer : IPage
    {
        ICustomerBL _custBL;        
        string _searchKey;        
        bool _searchCustRepeat;
        string _choice;
        int _YesNo;        
        Customer _searchCust;
        MenuFactory menuFactory;
        IMenu customerMenu;
        ResponseMessage responseMessage;

        /// <summary>
        /// SearchCustomer(ICustomerBL p_custBL): Constructor of SearchCustomer class. It initializes all the variables needed.
        /// </summary>
        /// <param name="p_custBL"></param>
        public SearchCustomer(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
            _searchKey = "";
            _searchCustRepeat = true;
            _choice="";
            _YesNo = 0;            
            _searchCust = new Customer();
            menuFactory = new MenuFactory();
            responseMessage = new ResponseMessage();
            
        }

        /// <summary>
        /// DisplayPage(): Display the Page to search existing Customer.
        /// </summary>
        public void DisplayPage()
        {            
            Console.Clear();
            MyConsole.WriteTitle(@"            
                                 __                         __                     
                                (_  _  _  __ _ |_     _    /      _ _|_ _ __  _  __
                                __)(/_(_| | (_ | |   (_|   \__|_|_>  |_(_)|||(/_ | 
                                                                                    
                                 ");            
            try{
                    SearchCustomerOperation(); 
            }catch(Exception ex){
                    MyConsole.WriteError("Something Wrooong with the customer Searching Operation! "+ex.Message);
            }  
            //Return to the Customer Menu
            customerMenu = menuFactory.GetMenu(MenuType.CustomerMenu);
            customerMenu.DisplayMenu();           
        }

        /// <summary>
        /// SearchCustomerOperation(): This is where the real operation of searching customer happens
        /// user is called to provide the phone/email wich the search is based upon.
        ///the user input is controled by our static class InputValidation
        /// </summary>
        public void SearchCustomerOperation(){
            do{
                //  get the Customer search and control it for not to be empty
                 MyConsole.WriteNormal("Enter Customer Phone Number / Email: ");
                do{                   
                    MyConsole.WriteNormalOneLine("Phone / Email: ");
                    _searchKey = Console.ReadLine();
                    responseMessage = InputValidation.IsNotNull(_searchKey,30);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);

                // searching the customer using the BL 
                try{
                    _searchCust = _custBL.FindCustomer(_searchKey);
                    // display the customer found information
                    if(_searchCust!=null){
                        MyConsole.WriteSuccess("Customer found!");
                        MyConsole.WriteNormal("Name: "+_searchCust.Name);
                        MyConsole.WriteNormal("Address: "+_searchCust.Address);
                        MyConsole.WriteNormal("Phone: "+_searchCust.Phone);
                        MyConsole.WriteNormal("Email: "+_searchCust.Email);
                    }else{
                        MyConsole.WriteError("Customer not found!");
                    }
                }catch(Exception ex){
                    MyConsole.WriteError($"Customer not found! {ex.Message}");
                }
                
                // ask the user if he wants to add another customer
                do{                    
                    MyConsole.WriteNormal("You want to search another customer?");
                    MyConsole.WriteNormalOneLine("Y / N ? ==> ");
                    _choice = Console.ReadLine().ToUpper();
                    if (_choice == "Y"){
                        _searchCustRepeat = true;
                        _YesNo=1;
                    }else if(_choice == "N")  {
                        _searchCustRepeat = false;
                        _YesNo=1;
                    }  else{
                        MyConsole.WriteError(" Invalid input!");
                        _YesNo=0;
                    }
                }while(_YesNo!=1);   
            }while (_searchCustRepeat);
        }
    }
}
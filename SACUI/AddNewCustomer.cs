using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACModels;
using SACBL;

namespace SACUI
{
    class AddNewCustomer : IPage
    {
        Customer _newCust ;
        ICustomerBL _custBL;
        bool _addCustRepeat;
        bool _phoneOrEmail;
        string _choice;
        int _YesNo;
        MenuFactory menuFactory;
        IMenu customerMenu;
        ResponseMessage responseMessage;
        
        /// <summary>
        /// AddNewCustomer(ICustomerBL p_custBL): Constructor of AddNewCustomer class. It initializes all the variables needed.
        /// </summary>
        /// <param name="p_custBL"></param>
        public AddNewCustomer(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
            _newCust = new Customer();
            _addCustRepeat = true;
            _choice = "";
            _YesNo = 0;
            responseMessage = new ResponseMessage();
            _phoneOrEmail = false;
            customerMenu = new CustomerMenu();
        }
        
        /// <summary>
        /// DisplayPage(): Display the Page to add new Customer.
        /// </summary>
        public void DisplayPage()
        {
            while (_addCustRepeat)
            {
                Console.Clear();
                MyConsole.WriteTitle(@"
                                 _                       __                     
                                |_| _| _|   __  _       /      _ _|_ _ __  _  __
                                | |(_|(_|   | |(/_\^/   \__|_|_>  |_(_)|||(/_ | 
                                                                                
                                    ");
                // call the local method AddNewCustomerOperation() 
                try{
                    AddNewCustomerOperation();
                } catch(Exception ex){
                    MyConsole.WriteError("Something Wrooong with the customer Adding Operation! "+ex.Message);
                }                               
            } 
            //Return to the Customer Menu
            customerMenu = menuFactory.GetMenu(MenuType.CustomerMenu);
            customerMenu.DisplayMenu(); 
        }

        /// <summary>
        /// AddNewCustomerOperation(): This is where the real operation of adding customer happens
        /// user is called to provide the name, phone/email, and address.
        /// all user input are controled by our static class InputValidation
        /// </summary>
        public void AddNewCustomerOperation(){
            do{
                // control on the Customer Name
                do{
                    MyConsole.WriteNormalOneLine("Name : ");
                    _newCust.Name = Console.ReadLine(); 
                    responseMessage = InputValidation.IsNotNull(_newCust.Name,30);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);

                // control on the Customer Phone/Email
                do{
                    _phoneOrEmail = false;
                    // control on the Customer Phone
                    do{
                        MyConsole.WriteNormalOneLine("Phone : ");
                        _newCust.Phone = Console.ReadLine();
                        if(string.IsNullOrEmpty(_newCust.Phone)){
                            responseMessage.response = true;
                        }else{
                            responseMessage = InputValidation.IsPhone(_newCust.Phone);
                            MyConsole.WriteError (responseMessage.message);
                            _phoneOrEmail = true;
                        }                    
                    }while(responseMessage.response == false);
                    // control on the Customer Email
                    do{
                    MyConsole.WriteNormalOneLine("Email : ");
                        _newCust.Email = Console.ReadLine();
                        if(string.IsNullOrEmpty(_newCust.Email)){
                            responseMessage.response = true;
                        }else{
                            responseMessage = InputValidation.IsEmail(_newCust.Email);
                            MyConsole.WriteError (responseMessage.message);
                            _phoneOrEmail = true;
                        }                    
                    }while(responseMessage.response== false);
                    // Display a message in case the use did not provide the Phone/Email
                    if(_phoneOrEmail == false){
                        MyConsole.WriteError(" You need to provide as least a Phone/Email");
                    }
                }while(_phoneOrEmail == false);

                // control on the Customer Address
                do{
                    MyConsole.WriteNormalOneLine("Address : ");
                    _newCust.Address = Console.ReadLine(); 
                    responseMessage = InputValidation.IsNotNull(_newCust.Address,100);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);

                // using try catch to handle exception in case that the new customer cannot be added.
                try{
                    MyConsole.WriteSuccess(_custBL.AddCustomer(_newCust).Name + " is added");
                }catch(Exception ex){
                    MyConsole.WriteError("Customer Adding Unsuccessful! "+ex.Message);
                }
                
                // ask the user if he wants to add another customer
                MyConsole.WriteNormal("You want to add another customer?");
                do{                 
                    MyConsole.WriteNormalOneLine("Y / N ? ==> ");
                    _choice = Console.ReadLine().ToUpper();
                    if (_choice == "Y"){
                        _addCustRepeat = true;
                        _YesNo=1;
                    }else if(_choice == "N")  {
                        _addCustRepeat = false;
                        _YesNo=1;
                    }  else{
                        MyConsole.WriteError(" Invalid input!");
                        _YesNo=0;
                    }
                }while(_YesNo!=1);   
            }while (_addCustRepeat);                       
        }
    }
}

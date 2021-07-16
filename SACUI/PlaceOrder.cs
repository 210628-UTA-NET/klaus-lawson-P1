using System;
using System.Collections.Generic;
using SACModels;
using SACBL;
namespace SACUI
{
    public class PlaceOrder: IPage
    {        
        ICustomerBL _custBL;
        string _customerSearchKey;
        bool _PlaceOrderRepeat;
        string _userChoice;
        string _choice;
        int _YesNo;
        double _totalPrice;
        int _orderId;
        Customer _customer;
        Orders _newOrder;
        LineItems _lineItems;        
        List<Product> _listProduct;
        List<StoreFront> _listStore;
        List<LineItems> _listLineItems;
        IPage custPage ;
        MenuFactory menuFactory;        
        PageFactory pageFactory;
        ResponseMessage responseMessage;
        IMenu orderMenu;

        /// <summary>
        /// PlaceOrder(ICustomerBL p_custBL): Constructor of PlaceOrder class. It initializes all the variables needed.
        /// </summary>
        /// <param name="p_custBL"></param>
        public PlaceOrder(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
            _customerSearchKey = "";
            _PlaceOrderRepeat = true;
            _userChoice = "";
            _choice ="";
            _YesNo = 0;
            _totalPrice = 0;
            _orderId = -1;
            _customer = new Customer();
            _newOrder = new Orders();
            _lineItems = new LineItems();            
            _listProduct = new List<Product> (); 
            _listStore = new List<StoreFront>();
            _listLineItems = new List<LineItems>(); 
            menuFactory = new MenuFactory();
            pageFactory = new PageFactory();
            responseMessage = new ResponseMessage(); 
            orderMenu =new OrderMenu();    
        }

        /// <summary>
        /// DisplayPage(): Display the Page to Place an order.
        /// </summary>
        public void DisplayPage()
        {
            
                
                Console.Clear();
                MyConsole.WriteTitle(@"
                                                        
                                 _                 _             
                                |_) |  _  _  _    / \ __ _| _  __
                                |   | (_|(_ (/_   \_/ | (_|(/_ | 
                                
                                ");
                MyConsole.WriteNormal("[2] Existing Customer?");
                MyConsole.WriteNormal("[1] New Customer?");
                MyConsole.WriteNormal("[0] Back to Order Menu"); 

                // loop do_while to control the choice of the user. InputValidation.IsInRange()
            try{
                 PlaceOrderOperation(); 
            }catch(Exception ex){
                    MyConsole.WriteError("Something Wrooong with the replenish store inventory Operation! "+ex.Message);
            }   
            orderMenu = menuFactory.GetMenu(MenuType.OrderMenu);                 
            orderMenu.DisplayMenu();
        }

        private void PlaceOrderOperation(){
            do{
                // get the user choice and control it
                do{
                    MyConsole.WriteNormalOneLine("PO Your Choice : ");
                    _userChoice = Console.ReadLine();
                    responseMessage = InputValidation.IsInRangeInt(_userChoice,0,2);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);

                // evaluate the user choice and execute the right method
                switch(_userChoice){
                    case "2":
                        ExistingCustomer();
                        break;
                    case "1":
                        AddCustomer();
                        break;
                    case "0":
                        _PlaceOrderRepeat = false;
                        menuFactory.GetMenu(MenuType.OrderMenu);                        
                        break;
                }               
                 
                 // ask the user if he wants to place another order
                 MyConsole.WriteNormal("Do you want to Place another order?");
                do{                 
                    MyConsole.WriteNormalOneLine("Y / N ? ==> ");
                    _choice =Console.ReadLine().ToUpper();
                    if (_choice == "Y"){
                        _PlaceOrderRepeat = true;
                        _YesNo = 1;
                    }else if(_choice == "N")  {
                        _PlaceOrderRepeat = false;
                        _YesNo = 1;
                    }  else{
                        MyConsole.WriteError("Invalid input!");
                        _YesNo = 0;
                    }
                }while(_YesNo != 1);   
            } while (_PlaceOrderRepeat);
        }

        /// <summary>
        /// ExistingCustomer(): search for an existing customer and place the order if the customer is found
        /// </summary>
        private void ExistingCustomer(){
            //  get the Customer search and control it for not to be empty
                do{
                    MyConsole.WriteNormal("Please Provide a valid Phone/Email ");
                    MyConsole.WriteNormalOneLine("Phone/Email: ");
                    _customerSearchKey = Console.ReadLine();
                    responseMessage = InputValidation.IsNotNull(_customerSearchKey,30);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);

                // searching the customer using the BL 
                try{
                    _customer = _custBL.FindCustomer(_customerSearchKey);
                    // display the customer found information
                    if(_customer!=null){
                        MyConsole.WriteSuccess($"Customer {_customer.Name} is found ");
                        _newOrder.CustomerId = _customer.Id;
                        PlaceOrderOperation(_customer);
                    }else{
                        MyConsole.WriteError("Customer not found!");
                    }
                }catch(Exception ex){
                    MyConsole.WriteError($"Customer not found! {ex.Message}");
                }
        }

        /// <summary>
        /// AddCustomer(): not existing customer is redirected to AddNewCustomer page
        /// </summary>
        private void AddCustomer(){
            custPage = pageFactory.GetPage(MenuType.AddNewCustomer);
            custPage.DisplayPage();
        }
        
        /// <summary>
        /// PlaceOrderOperation(Customer p_customer): There is where the Order placement operation happens
        /// </summary>
        /// <param name="p_customer"></param>
        private void PlaceOrderOperation(Customer p_customer){
            int i=1;
            int k =1;
            _listStore = _custBL.GetAllStoreFront();
            int numberOfStore = _listStore.Count;
            string selectedStore;
            int selectedProduct;
            int qtyProduct = 1;
            // Display the list of all available Store
            foreach(StoreFront store in _listStore){
                Console.WriteLine($" {i} -->  {store.Name} at {store.Address})");
                i++;
            }
            MyConsole.WriteNormal("Select of Store (by typing the number that preceed the name of the product)");         
            do{
                MyConsole.WriteNormalOneLine("Select the Store: ");
                selectedStore = Console.ReadLine();
                responseMessage = InputValidation.IsInRangeInt(selectedStore,1,_listStore.Count);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);
            //
            
            for(int j=0; j<=numberOfStore; j++)
            {
                if (selectedStore==$"{j+1}")
                {
                    try{
                        _newOrder.StoreFrontId = _custBL.FindStoreFront(_listStore[j].Name).Id;
                        _newOrder.Location = _custBL.FindStoreFront(_listStore[j].Name).Address;
                        _listProduct = _custBL.GetStoreFrontProduct(_listStore[j].Name);
                    }catch(Exception ex){
                        MyConsole.WriteError("Cannot get the Store information. "+ex.Message);
                    }                    
                    break;
                }                        
            }
            // display list of product available in the store
            foreach(Product product in _listProduct){
                MyConsole.WriteNormal($" {k} -->  {product.Name} at {product.Price}");
                k++;
            } 
            MyConsole.WriteNormal("Enter the number of the product");
            do{
                MyConsole.WriteNormalOneLine("Select the product: ");
                string p = Console.ReadLine();                 
                responseMessage = InputValidation.IsInRangeInt(p,1,_listProduct.Count);
                if(responseMessage.response== true){
                    Int32.TryParse(p,out selectedProduct);
                }else{
                    selectedProduct = -1;
                }
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);
            
            //Enter new product Quantity
            MyConsole.WriteNormal("Please enter the quantity to buy");            
            do{
                MyConsole.WriteNormalOneLine("Product Quantity: ");
                string qty = Console.ReadLine(); 
                responseMessage = InputValidation.IsInt(qty);
                if(responseMessage.response==true){
                    Int32.TryParse(qty, out qtyProduct );
                }
                MyConsole.WriteError (responseMessage.message);
             }while(responseMessage.response == false);

            _lineItems.ProductId = _listProduct[selectedProduct-1].Id;
            _lineItems.Quantity = _listProduct[selectedProduct-1].Quantity;
            _totalPrice += (_listProduct[selectedProduct-1].Price * _listProduct[selectedProduct-1].Quantity);
            _listLineItems.Add(_lineItems);

            do{             
                Console.WriteLine("Do you want to another product?");
                _choice = Console.ReadLine().ToUpper();
                if (_choice == "Y"){
                    Console.WriteLine("Select of Product by typing the number that preceed the name of the product)");
                    selectedProduct = Int32.Parse(Console.ReadLine()); 
                    do{
                        MyConsole.WriteNormalOneLine("Product Quantity: ");
                        string qty = Console.ReadLine(); 
                        responseMessage = InputValidation.IsInt(qty);
                        if(responseMessage.response==true){
                            Int32.TryParse(qty, out qtyProduct );
                        }
                        MyConsole.WriteError (responseMessage.message);
                    }while(responseMessage.response == false);

                    _lineItems.ProductId = _listProduct[selectedProduct].Id;
                    _lineItems.Quantity = _listProduct[selectedProduct].Quantity;
                    _totalPrice += _listProduct[selectedProduct].Price * _listProduct[selectedProduct].Quantity;
                    _listLineItems.Add(_lineItems);
                    _YesNo =1;
                }else if(_choice == "N")  {
                    _YesNo=1;
                }  else{
                    Console.WriteLine(" Invalid input");
                    _YesNo =0;
                }
            }while(_choice=="Y");
            _newOrder.TotalPrice =  _totalPrice;
            bool placed = false;
            placed = _custBL.AddNewOrder(_newOrder);
            if(placed){
                Console.WriteLine("new order is placed! ");
                _orderId = _custBL.GetLastOrderId();
                // save the LineItem
                saveListLineItems(_listLineItems);
                Console.WriteLine($"LineItemList is added.");
            }else{
                Console.WriteLine("Unable to add new order! ");
            }
            

        }
        private void saveListLineItems(List<LineItems> listLineItems){
            foreach(LineItems li in listLineItems){
                li.orderId = _orderId;
                if(_custBL.AddLineItems(li)){
                    
                }
            }
        }            
    }
}
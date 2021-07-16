using System;
using System.Collections.Generic;
using SACModels;
using SACBL;
namespace SACUI
{
    public class ReplenishInventory : IPage
    {
        ICustomerBL _custBL;
        string _userChoice;
        string _stName;
        bool _replenishInventoryRepeat;
        string _choice;
        int _YesNo;        
        StoreFront _myStoreFront;
        Product _newProduct;
        Product _updProduct;
        List<Product> _listProduct;
        MenuFactory menuFactory;
        ResponseMessage responseMessage;
        IMenu storeMenu;

        /// <summary>
        /// ReplenishInventory(ICustomerBL p_custBL): Constructor of ReplenishInventory class. It initializes all the variables needed.
        /// </summary>
        /// <param name="p_custBL"></param>
        public ReplenishInventory(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
            _userChoice="";
            _stName = "";
            _replenishInventoryRepeat = true;
            _choice = "N";  
            _YesNo = 0;          
            _myStoreFront = new StoreFront();
            _newProduct = new Product();
            _updProduct = new Product();
            _listProduct = new List<Product>();
            menuFactory = new MenuFactory();
            responseMessage = new ResponseMessage();
            storeMenu = new StoreMenu();
        }

        /// <summary>
        /// DisplayPage(): Display the Page to Replenish store Inventory.
        /// </summary>
        public void DisplayPage()
        {
            Console.Clear();
            MyConsole.WriteTitle(@"
                                 _     _                      ___                        
                                |_) _ |_) |  _ __  o  _ |_     | __     _ __ _|_ _  __ \/
                                | \(/_|   | (/_| | | _> | |   _|_| |\_/(/_| | |_(_) |  /

                                ");  
            try{
                ReplenishStoreOperation(); 
            }catch(Exception ex){
                    MyConsole.WriteError("Something Wrooong with the replenish store inventory Operation! "+ex.Message);
            }  
            //Return to the StoreMenu         
            storeMenu = menuFactory.GetMenu(MenuType.StoreMenu);
            storeMenu.DisplayMenu();  
        }

        /// <summary>
        /// ReplenishStoreOperation(): This is where the real operation of replenish Store happens
        /// user is called to provide the store name wich the search is based upon.
        /// the user input is controled by our static class InputValidation
        /// </summary>
        private void ReplenishStoreOperation(){
            do 
            {
                //  get the StoreFront name and control it for not to be empty
                do{                    
                    MyConsole.WriteNormal("Enter the Store Name Please");
                    MyConsole.WriteNormalOneLine("Store Name :  ");
                    _stName = Console.ReadLine(); 
                    responseMessage = InputValidation.IsNotNull(_stName,30);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false); 

                // getting the store has using the BL. if store found, the method StoreFound is execute
                // if store not found error message is displayed
                try{
                     _myStoreFront = _custBL.FindStoreFront(_stName); 
                     if(_myStoreFront!=null){
                        MyConsole.WriteSuccess($"Store {_stName} found !!!");
                        //call of the local StoreFound()
                        StoreFound();
                     }else{
                        MyConsole.WriteError($"Store {_stName} not found !!!");
                     }
                } catch(Exception ex){
                    MyConsole.WriteError($"Store {_stName} not found !!! {ex.Message}");
                }

                // ask the user if he wants to add another customer
                do{                    
                    MyConsole.WriteNormal("Do you want to Replenish another Store Inventory?");
                    MyConsole.WriteNormalOneLine("Y / N ? ==> ");
                    _choice = Console.ReadLine().ToUpper();
                    if (_choice == "Y"){
                        _replenishInventoryRepeat = true;
                        _YesNo=1;
                    }else if(_choice == "N")  {
                        _replenishInventoryRepeat = false;
                        _YesNo=1;
                    }  else{
                        MyConsole.WriteError("Invalid input!");
                        _YesNo=0;
                    }
                }while(_YesNo!=1);   
            }while (_replenishInventoryRepeat);
        }

        /// <summary>
        /// StoreFound() is called when the store is found
        /// it just display another menu for update product or add product
        /// </summary>
        private void StoreFound(){
            MyConsole.WriteNormal(" ");
            MyConsole.WriteNormal("[2] Update a product");
            MyConsole.WriteNormal("[1] Add a product ");
            MyConsole.WriteNormal("[0] Cancel");
            // loop do_while to control the choice of the user. InputValidation.IsInRange()
            do{
                MyConsole.WriteNormalOneLine("SM Your Choice : ");
                _userChoice = Console.ReadLine();
                responseMessage = InputValidation.IsInRangeInt(_userChoice,0,2);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);

            //Base upon the user choice, either updateProduct or addProduct or get StoreMenu is called
            switch(_userChoice){
                case "2":
                    updateProduct();
                    break;
                case "1":
                    AddProduct();
                    break;
                case "0":
                    menuFactory.GetMenu(MenuType.StoreMenu);
                    break;
            }                
        }

        /// <summary>
        /// updateProduct() is called to update product 
        /// </summary>
        private void updateProduct(){     
            int numProdUpdate = -1; 
            // _stName is valid already through our previous StoreFound() 
            // We are getting the list of product available in the Store
            _listProduct= _custBL.GetStoreFrontProduct(_stName);
            int i = _listProduct.Count;
            bool isChoiceConverted= false;
            string qty;
            int intQty;
            List<int> listID = new List<int>();;
            try{
                
                if(i>0){
                    // display the list of products in the selected store
                    foreach(Product item in _listProduct){
                        MyConsole.WriteNormal(item.Id+"------->"+item.Name+" : "+item.Quantity);
                        listID.Add(item.Id);
                        i--;
                    }
                    // control the choice of the product Id.
                   do{                       
                        MyConsole.WriteNormal("Enter the number of the corresponded product to update");
                        MyConsole.WriteNormalOneLine("RI Your Choice : ");
                        string c = Console.ReadLine();                        
                        responseMessage = InputValidation.IsInList(listID,c);
                        if(responseMessage.response == true){
                           numProdUpdate =  Int32.Parse(c);
                           isChoiceConverted= true; 
                        }
                        MyConsole.WriteError (responseMessage.message);
                    }while(responseMessage.response== false);

                    if(isChoiceConverted)
                    {
                        try{
                             _updProduct = _custBL.FindProduct(numProdUpdate);
                            if(_updProduct!=null){
                                // update the Product Name
                                do{
                                    MyConsole.WriteNormalOneLine("Product Name: ");
                                    _updProduct.Name = Console.ReadLine(); 
                                    responseMessage = InputValidation.IsNotNull(_updProduct.Name,30);
                                    MyConsole.WriteError (responseMessage.message);
                                }while(responseMessage.response== false);
                                //update the Product Quantity
                                do{
                                    MyConsole.WriteNormalOneLine("Product Quantity: ");
                                    qty = Console.ReadLine(); 
                                    responseMessage = InputValidation.IsInt(qty);
                                    if(Int32.TryParse(qty, out intQty )){
                                        _updProduct.Quantity = intQty;
                                    }
                                    MyConsole.WriteError (responseMessage.message);
                                }while(responseMessage.response == false);
                                // try to update the product using _custBL
                                try{
                                    bool yes =  _custBL.UpdateProduct(numProdUpdate,_updProduct);
                                    if(yes){
                                        MyConsole.WriteSuccess("Product updated successfully!");
                                    } 
                                }catch(Exception ex){
                                    MyConsole.WriteError($"Product updated unsuccessfully!{ex.Message}");
                                }
                            }else{
                                MyConsole.WriteError($"Product with ID: {numProdUpdate} doesn't exist ");
                            }
                        }catch(Exception ex){
                            MyConsole.WriteError($"Product with ID: {numProdUpdate} doesn't exist {ex.Message}");
                        }                                               
                    }                    
                }else{
                    MyConsole.WriteError($"Store {_stName} does not have any product!");
                }
            }  catch(Exception ex){
                MyConsole.WriteError($"Store {_stName} does not have any product! {ex.Message}");
            }   
        }

        /// <summary>
        /// AddProduct() is called to add product 
        /// </summary>
        private void AddProduct(){
            string price;
            double doublePrice;
            string qty;
            int intQty;
            //_myStoreFront = _custBL.FindStoreFront(_stName);

            // Enter newProduct name
            do{
                MyConsole.WriteNormalOneLine("Product Name: ");
                _updProduct.Name = Console.ReadLine(); 
                responseMessage = InputValidation.IsNotNull(_updProduct.Name,30);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);

            //Enter newProduct Price
            do{
                MyConsole.WriteNormalOneLine("Product Price:  ");
                price = Console.ReadLine(); 
                responseMessage = InputValidation.IsDouble(price);
                if(Double.TryParse(price, out doublePrice )){
                    _newProduct.Price = doublePrice;
                }
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response == false);

            //Enter new product Quantity
            do{
                MyConsole.WriteNormalOneLine("Product Quantity: ");
                qty = Console.ReadLine(); 
                responseMessage = InputValidation.IsInt(qty);
                if(Int32.TryParse(qty, out intQty )){
                    _newProduct.Quantity  = intQty;
                }
                MyConsole.WriteError (responseMessage.message);
             }while(responseMessage.response == false);

            //Enter newProduct Description
            do{
                MyConsole.WriteNormalOneLine("Product Description: ");
                _newProduct.Desciption = Console.ReadLine(); 
                responseMessage = InputValidation.IsNotNull( _newProduct.Desciption,255);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);

            //Enter newProduct Category
            do{
                MyConsole.WriteNormalOneLine("Product Category: ");
                _newProduct.Category = Console.ReadLine(); 
                responseMessage = InputValidation.IsNotNull(_newProduct.Category,40);
                MyConsole.WriteError (responseMessage.message);
            }while(responseMessage.response== false);

            // get the storeFornt Id
            _newProduct.StoreFrontId = _myStoreFront.Id;
            
            // add the new product to the DB
            try{
                bool yes =_custBL.AddProduct(_newProduct);
                if(yes){
                    MyConsole.WriteSuccess("Product Added successfully");           
                }else{
                    MyConsole.WriteError("Product Added unsuccessfully!");
                }
            }catch(Exception ex){
                MyConsole.WriteError($"Product Added unsuccessfully! {ex.Message}");
            }
            
        }
    }
}
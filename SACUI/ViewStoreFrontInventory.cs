using System;
using System.Collections.Generic;
using SACModels;
using SACBL;

namespace SACUI
{
    public class ViewStoreFrontInventory : IPage
    {       
        ICustomerBL _custBL;
        string _stName;
        bool _ViewIntoryRepeat;
        string _choice;
        int _YesNo ;        
        MenuFactory menuFactory;
        ResponseMessage responseMessage;
        List<Product> listProducts;
        IMenu storeMenu;

        /// <summary>
        /// ViewStoreFrontInventory(ICustomerBL p_custBL): Constructor of ViewStoreFrontInventory class. It initializes all the variables needed.
        /// </summary>
        /// <param name="p_custBL"></param>
        public ViewStoreFrontInventory(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
            _ViewIntoryRepeat = true;
            _stName = "";
            _choice = "N";
            _YesNo = 0;
            menuFactory = new MenuFactory();
            responseMessage = new ResponseMessage();
            listProducts = new List<Product>();
            storeMenu = new StoreMenu();
        }

        /// <summary>
        /// DisplayPage(): Display the Page to view store Inventory.
        /// </summary>
        public void DisplayPage()
        {     
            Console.Clear();
            MyConsole.WriteTitle(@"
                                \ /             __                __               ___                        
                                 V  o  _       (_ _|_ _  __ _    |_  __ _ __ _|_    | __     _ __ _|_ _  __ \/
                                    | (/_\^/   __) |_(_) | (/_   |   | (_)| | |_   _|_| |\_/(/_| | |_(_) |  / 
                                                                                                            
                                ");
            try{
                ViewStoreInventoryOperation(); 
            }catch(Exception ex){
                    MyConsole.WriteError("Something Wrooong with the view store inventory Operation! "+ex.Message);
            }  
            //Return to the StoreMenu            
            storeMenu = menuFactory.GetMenu(MenuType.StoreMenu);
            storeMenu.DisplayMenu();
        }

        /// <summary>
        /// ViewStoreInventoryOperation(): This is where the real operation of searching customer happens
        /// user is called to provide the store name wich the search is based upon.
        /// the user input is controled by our static class InputValidation
        /// </summary>
        private void ViewStoreInventoryOperation(){
            do{
                //  get the StoreFront name and control it for not to be empty
                do{
                    MyConsole.WriteNormal("Enter the Store Name Please");
                    MyConsole.WriteNormalOneLine("Store Name :  ");
                    _stName = Console.ReadLine(); 
                    responseMessage = InputValidation.IsNotNull(_stName,30);
                    MyConsole.WriteError (responseMessage.message);
                }while(responseMessage.response== false);  

                // getting all the product that the store has using the BL 
                try{
                    listProducts = _custBL.GetStoreFrontProduct(_stName);
                    if(listProducts.Count>0)
                    foreach(Product item in listProducts){
                        MyConsole.WriteNormal(item.Name+" : "+item.Quantity);
                    }else{
                        MyConsole.WriteError($@"store {_stName} does not any product or the store does not exist
                                                    \n Please review if store name is correct");
                    }
                } catch(Exception ex){
                    MyConsole.WriteError($"cannot get the list of products from the store {_stName} !!!{ex.Message}");
                }         
                
                 // ask the user if he wants to add another customer
                 MyConsole.WriteNormal("Do you want to view another Store Inventory?");
                do{                  
                    MyConsole.WriteNormalOneLine("Y / N ? ==> ");
                    _choice = Console.ReadLine().ToUpper();
                    if (_choice == "Y"){
                        _ViewIntoryRepeat = true;
                        _YesNo=1;
                    }else if(_choice == "N")  {
                        _ViewIntoryRepeat = false;
                        _YesNo=1;
                    }  else{
                        MyConsole.WriteError(" Invalid input!");
                        _YesNo=0;
                    }
                }while(_YesNo!=1);
            }while (_ViewIntoryRepeat);
        }
    }
}

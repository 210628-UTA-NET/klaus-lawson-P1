namespace SACUI
{
    
    public enum MenuType{
        MainMenu,
        CustomerMenu,
        StoreMenu,
        OrderMenu,
        AddNewCustomer,
        SearchCustomer,
        DeleteCustomer,
        UpdateCustomer,
        ViewSFInventory,
        ReplenishInventory,
        PlaceOrder,
        ViewOrderHistory,
        Exit
    }
    public interface IMenu 
    {
        /// <summary>
        /// Will display the overall menu of the class and the choices you can make in that menu class
        /// </summary>
        void DisplayMenu();
        
        /// <summary>
        /// This methog will record the user's choice and change your menu based on their input
        /// </summary>
        /// <returns>Returns a value that will dictate what menu to change to</returns>
        MenuType GetUserChoice();

    }
    
}
using SACBL;
using SACDL;
namespace SACUI
{
    public class MenuFactory : IMenuFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            switch (p_menu){
                case MenuType.MainMenu:
                    return new MainMenu();
                //Menu level 1                 
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.StoreMenu:
                    return new StoreMenu();
                case MenuType.OrderMenu:
                    return new OrderMenu();              
                default:
                    return null;
            }
        }
    }
}
using System.Linq;
using System.Collections.Generic;
using Model=SACModels;
using Entity= SACDL.Entities;

namespace SACDL
{
    public class Repository : IRepository

    {
        private Entity.AppStoreDbContext _context;

        //Repository Constructor 
        public Repository(Entity.AppStoreDbContext p_context){
            _context = p_context;
        }

        //Customer Operation
        public Model.Customer AddCustomer (Model.Customer p_customer)
        {
            _context.Customers.Add(new Entity.Customer{
                CustomerName = p_customer.Name,
                CustomerEmail = p_customer.Email,
                CustomerAddress = p_customer.Address,
                CustomerPhone = p_customer.Phone
            });
            _context.SaveChanges();
            return p_customer;
        }
       
        public Model.Customer FindCustomer(string p_searchKey)
        {
            Model.Customer mCustomer = new Model.Customer();  
            Entity.Customer eCustomer; 
            // using (_context){
               eCustomer = _context.Customers.Where (customer=>
                (customer.CustomerEmail == p_searchKey) ||  (customer.CustomerPhone == p_searchKey))
                .FirstOrDefault();
            //}
                mCustomer.Id = eCustomer.CustomerId;
                mCustomer.Name =eCustomer.CustomerName;
                mCustomer.Email = eCustomer.CustomerEmail;
                mCustomer.Address = eCustomer.CustomerAddress;
                mCustomer.Phone = eCustomer.CustomerPhone;
            return mCustomer;
        }
             public Model.Customer DeleteCustomer(int p_id)
        {
            throw new System.NotImplementedException();
        }

        public Model.Customer UpdateCustomer(int p_id)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Customer> GetAllCustomer()
        {
            List<Model.Customer>  mCustomer =new List<Model.Customer>();
            
            // using (_context){
              var eCustomer = _context.Customers.ToList();            
            foreach(Entity.Customer eCust in eCustomer){
                Model.Customer mCust = new Model.Customer();
                mCust.Name = eCust.CustomerName;
                mCust.Address = eCust.CustomerAddress;
                mCust.Email = eCust.CustomerEmail;
                mCust.Phone = eCust.CustomerPhone;
                mCustomer.Add(mCust);
            //}
            }
            return mCustomer;
        } 
        
        //StoreFront operations
        public Model.StoreFront FindStoreFront(string p_searchKey)
        {
            Model.StoreFront mStf = new Model.StoreFront();  
            // using (_context){
            Entity.StoreFront eStf=_context.StoreFronts.Where (stf=>
                (stf.StoreFrontName == p_searchKey) 
                ||  (stf.StoreFrontAddress == p_searchKey)
                )
                .FirstOrDefault();
            
            mStf.Name =eStf.StoreFrontName;
            mStf.Address = eStf.StoreFrontAddress;
            mStf.Id = eStf.StoreFrontId;
            //}
            return mStf;
        }
        public Model.StoreFront FindStoreFrontByID(int p_stfID)
        {
            Model.StoreFront mStf = new Model.StoreFront();  
            // using (_context){
            Entity.StoreFront eStf=_context.StoreFronts.Where (stf=>
                stf.StoreFrontId == p_stfID)
                .FirstOrDefault();
            
            mStf.Name =eStf.StoreFrontName;
            mStf.Address = eStf.StoreFrontAddress;
            mStf.Id = eStf.StoreFrontId;
            //}
            return mStf;
        }
        public List<Model.StoreFront> GetAllStoreFront()
        {
            List<Model.StoreFront>  mStoreFront =new List<Model.StoreFront>();
            
            // using (_context){
                var eStoreFront = _context.StoreFronts.ToList();            
                foreach(Entity.StoreFront eStore in eStoreFront){
                    Model.StoreFront mStore = new Model.StoreFront();
                    mStore.Name = eStore.StoreFrontName;
                    mStore.Id = eStore.StoreFrontId;
                    mStore.Address = eStore.StoreFrontAddress;
                    mStoreFront.Add(mStore);
            }
            //}
            return mStoreFront;
        } 

        public List<Model.Product> GetStoreFrontProducts(string p_storeName){
           List<Model.Product> SFProducts = new List<Model.Product>();
           Model.StoreFront mystf = FindStoreFront(p_storeName);
            // using (_context){
                IEnumerable<Entity.Product> EntitySFProducts = _context.Products
                                        .Where(store => store.StoreFrontId == mystf.Id)
                                        .ToList();
                                        
                foreach(Entity.Product item in EntitySFProducts)
                {
                    Model.Product SfProduct = new Model.Product();
                    SfProduct.Quantity = item.ProductQuantity;
                    SfProduct.Name = item.ProductName;
                    SfProduct.Category = item.Productcategory;
                    SfProduct.Desciption = item.Productdescription;    
                    SfProduct.Id = item.ProductId;  
                    SfProduct.Price = (double)item.ProductPrice;   
                    SFProducts.Add(SfProduct);                
                }
            //}
            return SFProducts;
        
            //  var EntitySfProductntory = _context.StoreFronts.
            //                 Join(_context.Orders,
            //                 stf => stf.Id,
            //                 order => order.StoreFrontId,
            //                 (stf, order)=>new{stf,order}
                            
            //             ).Where(n=> n.order.StoreFrontId == mystf.Id)
            //             .Join(_context.LineItems,
            //                 order => order.order.Id,
            //                 lineItem => lineItem.OrdersId,
            //                 (order, lineItem) => new{order,lineItem}
                            
            //             )
            //             .Join(_context.Products,
            //                 lineItem => lineItem.lineItem.ProductId,
            //                 product => product.Id,
            //                 (lineItem, product) => new{
            //                     sName = lineItem.lineItem.Orders.StoreFront.Name,
            //                     qty = lineItem.lineItem.ProductQuantity,
            //                     pName = product.Name,}
            //             )                        
            //             .Select(g => new{
            //                 g.pName,g.qty,g.sName                           
            //             });
                        // foreach(var item in EntitySfProductntory){
                        //     SfProduct.ProductQuantity = (int)item.qty;
                        //     SfProduct.ProductName = item.pName.ToString();
                        //     Console.WriteLine(SfProduct.ToString());
                        //     SFProducts.Add(SfProduct);
                        // }
               
        }

        //Product Operations
        public Model.Product FindProduct(int p_id){
            Model.Product mProduct = new Model.Product();
            // using (_context){
                Entity.Product eProduct = (Entity.Product)_context.Products.Where (p=>p.ProductId == p_id).FirstOrDefault();;
                mProduct.Quantity = eProduct.ProductQuantity;
                mProduct.Name = eProduct.ProductName; 
                mProduct.StoreFrontId = (int)eProduct.StoreFrontId; 
                mProduct.Id = eProduct.ProductId;
                mProduct.Desciption = eProduct.Productdescription;
                mProduct.Category = eProduct.Productcategory;
            //}
            return mProduct;
        }

        public bool UpdateProduct(int p_id, Model.Product p_Product){
            // using (_context){
                Entity.Product eProducts =_context.Products.FirstOrDefault(inv=>inv.ProductId == p_id);
                eProducts.ProductName = p_Product.Name;
                eProducts.ProductQuantity = p_Product.Quantity;
                _context.Products.Update(eProducts);
                _context.SaveChanges();
            //}
            return true;
        }
        public bool AddProduct (Model.Product p_product)
        {
            // using (_context){
                _context.Products.Add(new Entity.Product{
                    ProductName = p_product.Name,
                    ProductPrice = (decimal)p_product.Price,
                    ProductQuantity = p_product.Quantity,
                    Productcategory = p_product.Category,
                    Productdescription = p_product.Desciption,
                    StoreFrontId = p_product.StoreFrontId
                });            
            _context.SaveChanges();
            //}
            return true;
        }
        public bool AddNewOrder(Model.Orders p_orders){
            // using (_context){
                _context.Orders.Add(new Entity.Order{
                    OrdersLocation = p_orders.Location,
                    OrdersTotalPrice =(decimal) p_orders.TotalPrice,
                    StoreFrontId = p_orders.StoreFrontId,
                    CustomerId = p_orders.CustomerId,
                });
                _context.SaveChanges();
            //}
            return  true;
        }
        public int GetLastOrderId(){
            int lastOrderId;
            // using (_context){
                lastOrderId = _context.Orders.ToList().LastOrDefault().OrdersId;
           // }
            return lastOrderId;
        }
        public bool AddLineItems(Model.LineItems p_lineItems){
            // using (_context){
                _context.LineItems.Add(new Entity.LineItem{
                    LineItemsProductQuantity = (int)p_lineItems.Quantity,
                    ProductId =(int) p_lineItems.ProductId,
                    OrdersId = (int)p_lineItems.orderId
                });
                _context.SaveChanges();
           // }
            return true;
        }
        public List<Model.Orders> GetOrderOfCustomer(int p_customerID){
             List<Model.Orders> mcustOrders = new List<Model.Orders>();
             var eCustOrders = _context.Orders
                                        .Where(o => o.CustomerId == p_customerID)
                                        .ToList();
                                        
                foreach(Entity.Order item in eCustOrders)
                {
                    Model.Orders custOrder = new Model.Orders();
                    custOrder.Id = item.OrdersId;
                    custOrder.Location = item.OrdersLocation;
                    custOrder.TotalPrice = (double)item.OrdersTotalPrice;
                    custOrder.StoreFrontId = (int)item.StoreFrontId;    
                    custOrder.CustomerId = (int)item.CustomerId;  
                    mcustOrders .Add(custOrder);                
                }
            //}
            return mcustOrders ;
        }
    }
}
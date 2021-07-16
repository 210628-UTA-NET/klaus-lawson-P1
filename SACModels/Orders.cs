using System;
using System.Collections.Generic;


namespace SACModels
{
    public class Orders
    {
        /// <summary> 
        /// creation of the properties for the Orders class with the private Access Modifier
        /// this class has 3 properties: OrderLineItems, Location, and TotalPrice. 
        /// Order model contains information about customer orders
        /// </summary>
        private int _id;
        private string _location;
        private double _totalPrice;
        private int _customerId;
        private int _storeFrontId;
        private List<LineItems> _orderLineItems;


        public int Id { 
            get{
                return _id;
            } 
            set{
                _id =value;
            }
        }
        
        /// <summary>
        /// getter and setter method for the _location property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an string value type representing the location where the order was placed</value>
        public string Location { 
            get{
                return _location;
            } 
            set{
                _location = value;
            } 
        }
        /// <summary>
        /// getter and setter method for the _orderLineItems property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return a list of Line Items which is reference type. A line Item is has product and the quantity of that product</value>
        public List<LineItems> OrderlineItems{
            get{
                return _orderLineItems;
            } 
            set{
                _orderLineItems = value;
            } 
        }

        /// <summary>
        /// getter and setter method for the _totalPrice property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return a double value type representing the total price of the orders</value>
        public double TotalPrice{
            get{
                return _totalPrice;
            } 
            set{
                _totalPrice = value;
            } 
        }
        
        public int CustomerId{
            get{
                return _customerId;
            } 
            set{
                _customerId = value;
            } 
        }

        public int StoreFrontId{
            get{
                return _storeFrontId;
            } 
            set{
                _storeFrontId = value;
            } 
        }
    }
}
using System;
using System.Collections.Generic;

namespace SACModels
{
    public class StoreFront
    {
        /// <summary>
        /// creation of the properties for the StoreFront class with the private Access Modifier
        /// this class has 4 properites: Name, Address,inventory, and ListOfOrders.
        /// The store front contains information pertaining the various store locations..
        /// </summary>
        private int _id;
        private string _name;
        private string _address;
        private List<Orders> _listOfOrders;
        
        public int Id { 
            get{
                return _id;
            } 
            set{
                _id =value;
            }            
        }
        public string Name { 
            get{
                return _name;
            }
            set{
                _name = value;
            } 
        }

        public string Address { 
            get{
                return _address;
            }
            set{
                _address = value;
            } 
        }

        public List<Orders> ListOfOrders { 
            get{
                return _listOfOrders;
            }
            set{
                _listOfOrders = value;
            } 
        }
    
    }
    
}

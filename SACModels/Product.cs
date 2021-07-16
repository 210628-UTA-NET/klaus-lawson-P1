using System.Collections.Generic;

namespace SACModels
{
    public class Product
    {
        /// <summary>
        /// creation of the properties for the Product class with the private Access Modifier
        /// this class has 4 properites: Name, Price, Description, and Category.
        /// Product model is supposed to hold the data concerning a customer.
        /// </summary>
        private int _id;
        
        private string _name;
        private double _price;
        private int _quantity;
        private string _desciption;
        private string _category;
        private int _storeFrontId;
        private List<LineItems> _lineItems;
       
        public int Id { 
            get{
                return _id;
            } 
            set{
                _id =value;
            }
        }
         /// <summary>
        /// getter and setter method for the _name property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an string value type representing the name of the product</value>
        public string Name { 
            get{
                return _name;
            }
            set{
                _name = value;
            } 
        }
        /// <summary>
        /// getter and setter method for the _price property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an double value type representing the price of the product</value>
        public double Price { 
            get{
                return _price;
            }
            set{
                _price = value;
            } 
        }
        /// <summary>
        /// getter and setter method for the _quantity property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an int value type representing the quantity of the product</value>
        public int Quantity { 
            get{
                return _quantity;
            }
            set{
                _quantity = value;
            } 
        }
        /// <summary>
        /// getter and setter method for the _description property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an string value type representing the description of the product</value>
        public string Desciption { 
            get{
                return _desciption;
            }
            set{
                _desciption = value;
            } 
        }
        /// <summary>
        /// getter and setter method for the _category property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an string value type representing the category of the product</value>
        public string Category { 
            get{
                return _category;
            }
            set{
                _category = value;
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
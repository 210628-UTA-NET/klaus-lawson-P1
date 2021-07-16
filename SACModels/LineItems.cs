namespace SACModels
{
    public class LineItems
    {
        /// <summary>
        /// creation of the properties for the LineItem class with the private Access Modifier
        /// this has 2 properties: Product and Quantity
        /// the line items contains information about a particular product and its quantity
        /// </summary>
        private int _id;
        private int _quantity;
        private int _productId;
        private int _orderId;
       
        /// <summary>
        /// getter and setter method for the _product property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return a reference value of a product</value>
        public int Id { 
            get{
                return _id;
            }     
            set{
                _id =value;
            }        
        }
        
        /// <summary>
        /// getter and setter method for the _quantity property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an integer value type representing the quanti</value>
        public int Quantity { 
            get{
                return _quantity;
            }
            set{
                _quantity = value;
            } 
        }
        public int ProductId { 
            get{
                return _productId;
            }
            set{
                _productId = value;
            } 
        }
        public int orderId { 
            get{
                return _orderId;
            }
            set{
                _orderId = value;
            } 
        }
        
    }
}
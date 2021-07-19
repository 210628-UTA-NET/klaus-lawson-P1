using System;
using System.Collections.Generic;


namespace SAModels
{
    public class Customer
    {
        /// <summary>
        /// creation of the properties for the customer class with the private Access Modifier
        /// this class has 5 properites: Name, Address, Email, Phone, and ListOfOrders.
        /// the Customer model is supposed to hold the data concerning a customer.
        /// </summary>

        private int _id;
        private string _name;
        private string _address;
        private string _email;
        private string _phone;

        /// <summary>
        /// getter and setter method for the _name property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an string value type representing the name of the customer</value>


        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        /// <summary>
        /// getter and setter method for the _address property.
        /// We will further implement the validation in the setter
        /// </summary>
        /// <value>the get return an string value type representing the address of the customer</value>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        /// <summary>
        /// getter and setter method for the _email property.
        /// We will further implement the validation in the setter: using regex() functionality
        /// </summary>
        /// <value>the get return an string value type representing the email of the customer</value>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        /// <summary>
        /// getter and setter method for the _phone property.
        /// We will further implement the validation in the setter: using regex() functionality
        /// </summary>
        /// <value>the get return an string value type representing the phone of the customer</value>
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

    }
}

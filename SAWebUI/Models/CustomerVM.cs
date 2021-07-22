using SAModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SAWebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM()
        {

        }
        public CustomerVM(Customer p_customer)
        {
            Id = p_customer.Id;
            CustomerFirstName = p_customer.CustomerFirstName;
            CustomerLastName = p_customer.CustomerLastName;
            CustomerEmail = p_customer.CustomerEmail;
            CustomerPhone = p_customer.CustomerPhone;
            CustomerAddressId = p_customer.CustomerAddressId;
            CustomerPassword = p_customer.CustomerPassword;
        }

        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPassword { get; set; }
        public int CustomerAddressId { get; set; }

    }
}

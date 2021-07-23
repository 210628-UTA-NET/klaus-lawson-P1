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
            Street = p_customer.CustomerAddress.Street;
            City = p_customer.CustomerAddress.City;
            State = p_customer.CustomerAddress.State;
            Country = p_customer.CustomerAddress.Country;
        }

        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPassword { get; set; }
        public int CustomerAddressId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }

    }
}

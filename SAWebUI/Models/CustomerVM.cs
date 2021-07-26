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
            addressVM = new AddressVM(p_customer.CustomerAddress);
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        [Required]
        public string CustomerPassword { get; set; }
        [Compare("CustomerPassword", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string CustomerConfirmPassword { get; set; }
        public int CustomerAddressId { get; set; }
        public AddressVM addressVM { get; set; }
        public Customer ConvertToCustomer()
        {
            return new Customer()
            {
                CustomerFirstName = this.CustomerFirstName,
                CustomerLastName = this.CustomerLastName,
                CustomerEmail = this.CustomerEmail,
                CustomerPhone = this.CustomerPhone,
                CustomerPassword = this.CustomerPassword,
            };
        }
    }
}

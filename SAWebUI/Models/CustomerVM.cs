using SAModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            CustomerRole = p_customer.CustomerRole;
            CustomerEmail = p_customer.CustomerEmail;
            CustomerPhone = p_customer.CustomerPhone;
            CustomerAddressId = p_customer.CustomerAddressId;
            addressVM = new AddressVM(p_customer.CustomerAddress);
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string CustomerFirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string CustomerLastName { get; set; }
        
        [DisplayName("Role")]
        [DefaultValue("User")]
        public string CustomerRole { get; set; }
        [Required]
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
        [Required]
        [DisplayName("Phone")]
        public string CustomerPhone { get; set; }
        [Required]
        [DisplayName("Password")]
        public string CustomerPassword { get; set; }
        [Compare("CustomerPassword", ErrorMessage = "Confirm password doesn't match the password!")]
        [DisplayName("Confirm Password")]
        public string CustomerConfirmPassword { get; set; }
        public int CustomerAddressId { get; set; }
        public AddressVM addressVM { get; set; }
        public Customer ConvertToCustomer()
        {
            return new Customer()
            {
                Id = this.Id,
                CustomerFirstName = this.CustomerFirstName,
                CustomerLastName = this.CustomerLastName,
                CustomerRole = this.CustomerRole,
                CustomerEmail = this.CustomerEmail,
                CustomerPhone = this.CustomerPhone,
                CustomerPassword = this.CustomerPassword,
            };
        }
    }
}

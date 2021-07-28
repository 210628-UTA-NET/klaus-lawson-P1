using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SAModels;
using System.ComponentModel;

namespace SAWebUI.Models
{
    public class AddressVM
    {
        public AddressVM()
        {

        }
        public AddressVM(Address p_address)
        {
            Id = p_address.Id;
            Street = p_address.Street;
            City = p_address.City;
            State = p_address.State;
            Country = p_address.Country;
        }
        
        public int Id { get; set; }
        [Required]
        [DisplayName("Street")]
        public string Street { get; set; }
        [Required]
        [DisplayName("City")]
        public string City { get; set; }
        [Required]
        [DisplayName("State")]
        public string State { get; set; }
        [DefaultValue("USA")]
        public string Country { get; set; }
        public int Zip { get; set; }
        public Address ConvertToAddress()
        {
            return new Address()
            {
                Id = this.Id,
                Street = this.Street,
                City = this.City,
                State = this.State,
                Country = this.Country,
                Zip = this.Zip,
                
            };
        }
    }
}

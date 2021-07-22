using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAModels;

namespace SAWebUI.Models
{
    public class StoreVM
    {
        public StoreVM()
        {

        }
        public StoreVM(Store p_store,Address p_address)
        {
            Id = p_store.Id;
            StoreName = p_store.StoreName;
            StorePhone = p_store.StorePhone;
            StoreAddressId = p_store.StoreAddressId;
            Street = p_address.Street;
            City = p_address.City;
            State = p_address.City;
            Country = p_address.Country;
        }

        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StorePhone { get; set; }
        public int StoreAddressId { get; set; }
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public StoreVM(Store p_store)
        {
            Id = p_store.Id;
            StoreName = p_store.StoreName;
            StorePhone = p_store.StorePhone;
            StoreAddressId = p_store.StoreAddressId;
            addressVM = new AddressVM(p_store.StoreAddress);
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Store Name")]
        public string StoreName { get; set; }
        [Required]
        [DisplayName("Store Phone")]
        public string StorePhone { get; set; }
        public int StoreAddressId { get; set; }
        public AddressVM addressVM { get; set; }

        public Store ConvertToStore()
        {
            return new Store()
            {
                Id = this.Id,
                StoreName = this.StoreName,
                StorePhone = this.StorePhone,
                StoreAddressId = this.StoreAddressId
            };
        }
    }
}

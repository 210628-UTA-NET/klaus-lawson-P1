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
        public StoreVM(Store p_store)
        {
            Id = p_store.Id;
            StoreName = p_store.StoreName;
            StorePhone = p_store.StorePhone;
            StoreAddressId = p_store.StoreAddressId;
            addressVM = new AddressVM(p_store.StoreAddress);
        }

        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StorePhone { get; set; }
        public int StoreAddressId { get; set; }
        public AddressVM addressVM { get; set; }
    }
}

using System;
using SAModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SAWebUI.Models
{
    public class OrderVM
    {
        public OrderVM() { }
        public OrderVM(Order p_order)
        {
            Id = p_order.Id;
            Location = p_order.Location;
            OrderTotalPrice = p_order.OrderTotalPrice;
            OrderDate = p_order.OrderDate;
            OrderStatus = p_order.OrderStatus;
            StoreId = p_order.StoreId;
            CustomerId = p_order.CustomerId;
            OrderStore = p_order.Store;
        }
        [Key]
        public int Id { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("Total Price")]
        public double OrderTotalPrice { get; set; }
        [DisplayName("Order date")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Status")]
        public string OrderStatus { get; set; }
        public int StoreId { get; set; }
        public Store OrderStore { get; set; }
        public int CustomerId { get; set; }

        public Order ConvertToOrder()
        {
            return new Order()
            {
                Location = this.Location,
                OrderTotalPrice = this.OrderTotalPrice,
                OrderDate = this.OrderDate,
                OrderStatus = this.OrderStatus,
                StoreId = this.StoreId,
                CustomerId = this.CustomerId
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAModels;
using System.ComponentModel.DataAnnotations;

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
        }
        public int Id { get; set; }
        public string Location { get; set; }
        public double OrderTotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
    }
}

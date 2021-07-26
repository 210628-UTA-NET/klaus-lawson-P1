using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAModels;
using System.ComponentModel.DataAnnotations;

namespace SAWebUI.Models
{
    public class LineItemVM
    {
       /* public LineItemVM() { }
        public LineItemVM(LineItem p_lineItem) 
        {
            ProductId = p_lineItem.ProductId;
            OrderId = p_lineItem.OrderId;
            QuantityToBuy = p_lineItem.QuantityToBuy;
        }*/
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int QuantityToBuy { get; set; }
        /*public ProductVM ProductVM { get; set; }

        public LineItem ConvertToStore()
        {
            return new LineItem()
            {
                ProductId = this.ProductId,
                OrderId = this.OrderId,
                QuantityToBuy = this.QuantityToBuy
            };
        }*/
    }
}

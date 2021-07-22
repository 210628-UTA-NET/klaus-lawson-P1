using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAModels;
using System.ComponentModel.DataAnnotations;

namespace SAWebUI.Models
{
    public class ProductVM
    {
        public ProductVM() { }
        public ProductVM(Product p_product)
        {
            Id = p_product.Id;
            ProductName = p_product.ProductName;
            ProductDescription = p_product.ProductDescription;
            ProductAvailableQty = p_product.ProductAvailableQty;
            ProductDescription = p_product.ProductDescription;
            CategoryId = p_product.CategoryId;
            StoreId = p_product.StoreId;
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductAvailableQty { get; set; }
        public double ProductUnitPrice { get; set; }
        public int CategoryId { get; set; }
        public int StoreId { get; set; }
    }
}

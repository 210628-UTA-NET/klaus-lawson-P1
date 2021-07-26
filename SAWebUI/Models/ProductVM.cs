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
            ProductUnitPrice = p_product.ProductUnitPrice;
            CategoryId = p_product.CategoryId;
            StoreId = p_product.StoreId;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductAvailableQty { get; set; }
        [Required]
        public double ProductUnitPrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int StoreId { get; set; }
        public Product ConvertToProduct()
        {
            return new Product()
            {
                ProductName = this.ProductName,        
                ProductDescription = this.ProductDescription,
                ProductAvailableQty = this.ProductAvailableQty,
                ProductUnitPrice= this.ProductUnitPrice,
                CategoryId = this.CategoryId,
                StoreId =this.StoreId
            };
        }
    }
}

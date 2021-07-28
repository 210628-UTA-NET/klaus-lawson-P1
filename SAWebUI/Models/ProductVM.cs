using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        [DisplayName("Product Name")]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(255)]
        public string ProductDescription { get; set; }

        [Required]
        [DisplayName("Quantity")]
        [Range(1,int.MaxValue,ErrorMessage ="Quantity must be greater than 0!")]
        public int ProductAvailableQty { get; set; }

        [Required]
        [DisplayName("Unit Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0!")]
        public double ProductUnitPrice { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Store")]
        public int StoreId { get; set; }

        public Product ConvertToProduct()
        {
            return new Product()
            {
                Id = this.Id,
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

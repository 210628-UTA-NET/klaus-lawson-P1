using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAModels;
using System.ComponentModel.DataAnnotations;

namespace SAWebUI.Models
{
    public class CategoryVM
    {
        public CategoryVM()
        {
            
        }
        public CategoryVM(Category p_category)
        {
            Id = p_category.Id;
            CategoryName = p_category.CategoryName;
            CategoryDescription = p_category.CategoryDescription;
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}

using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Display(Name ="Category")]
        [ForeignKey("Category")]
        public Nullable<int> CategoryId { get; set; }
    }
}

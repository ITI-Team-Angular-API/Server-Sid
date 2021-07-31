using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public  class OrderViewModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public double totalPrice { get; set; }
        public string userId { get; set; }
        public virtual PaymentMethodViewModel PaymentMethod { get; set; }
        public virtual ApplicationUserIDentity appUser { get; set; }
        public virtual ICollection<OrderedProducts> OrderedProducts { get; set; }
    }
}

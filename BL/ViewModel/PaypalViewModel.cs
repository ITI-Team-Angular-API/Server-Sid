using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class PaypalViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Account { get; set; }
    }
}

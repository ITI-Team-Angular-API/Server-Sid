using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class VisaViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(16,ErrorMessage = "Length must be 16 numbers")]
        public string Number { get; set; }
        [Required]
        [MaxLength(5, ErrorMessage = "Length must be 5 characters")]
        public string Expire { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Length must be 3 numbers")]
        public string SequreCode { get; set; }
    }
}

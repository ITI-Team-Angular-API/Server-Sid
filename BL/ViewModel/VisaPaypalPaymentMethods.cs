using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
   public class VisaPaypalPaymentMethods
    {
        public VisaViewModel visa { get; set; }
        public PaypalViewModel paypal { get; set; }
        public string PaymentMethod { get; set; }
         
    }
}

using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public class GetPath
    {
        public string getFullPath(ProductViewModel product)
        {
            return product.Image;
        }
    }
}
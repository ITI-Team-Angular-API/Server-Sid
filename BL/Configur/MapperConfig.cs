using AutoMapper;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configur
{
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIDentity, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIDentity, RegisterViewodel>().ReverseMap();
                    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
                    cfg.CreateMap<Paypal, PaypalViewModel>().ReverseMap();
                    cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                    cfg.CreateMap<ShoppingCart, ShoppingCartViewModel>().ReverseMap();
                    cfg.CreateMap<Visa, VisaViewModel>().ReverseMap();
                    //cfg.CreateMap<IdentityResult, ResultStatue>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}

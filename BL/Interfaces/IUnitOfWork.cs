using BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methode
        int Commit();
        #endregion

        OrderRepository Order { get; }
        AccountRepository Account { get; }
        RoleRepository Role { get; }
        CategoryRepository Category { get; }
        FavouriteProductsRepository FavouriteProducts { get; }
        OrderedProductsRepository OrderedProducts { get; }
        PaymentMethodRepository PaymentMethod { get; }
        PaypalRepository Paypal { get; }
        ProductRepository Product { get; }
        ShoppingCartProductsRepository ShoppingCartProducts { get; }
        ShoppingCartRepository ShoppingCart { get; }
        VisaRepository Visa { get; }
        UserRepository ApplicationUserIDentity { get; }
    }

}

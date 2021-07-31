using BL.Interfaces;
using BL.Repositories;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext EC_DbContext { get; set; }

        #endregion

        #region Constructors
        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();//
            // Avoid load navigation properties
            EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Methods
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
        #endregion


        public OrderRepository order;//=> throw new NotImplementedException();
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(EC_DbContext);
                return order;
            }
        }

        public AccountRepository account;//=> throw new NotImplementedException();
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext);
                return account;
            }
        }

        public RoleRepository role;//=> throw new NotImplementedException();
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(EC_DbContext);
                return role;
            }
        }

        public CategoryRepository category;//=> throw new NotImplementedException();
        public CategoryRepository Category
        {
            get
            {
                if (category == null)
                    category = new CategoryRepository(EC_DbContext);
                return category;
            }
        }

        public FavouriteProductsRepository favouriteProducts;//=> throw new NotImplementedException();
        public FavouriteProductsRepository FavouriteProducts
        {
            get
            {
                if (favouriteProducts == null)
                    favouriteProducts = new FavouriteProductsRepository(EC_DbContext);
                return favouriteProducts;
            }
        }

        public OrderedProductsRepository orderedProducts;//=> throw new NotImplementedException();
        public OrderedProductsRepository OrderedProducts
        {
            get
            {
                if (orderedProducts == null)
                    orderedProducts = new OrderedProductsRepository(EC_DbContext);
                return orderedProducts;
            }
        }

        public PaymentMethodRepository paymentMethod;//=> throw new NotImplementedException();
        public PaymentMethodRepository PaymentMethod
        {
            get
            {
                if (paymentMethod == null)
                    paymentMethod = new PaymentMethodRepository(EC_DbContext);
                return paymentMethod;
            }
        }

        public PaypalRepository paypal;//=> throw new NotImplementedException();
        public PaypalRepository Paypal
        {
            get
            {
                if (paypal == null)
                    paypal = new PaypalRepository(EC_DbContext);
                return paypal;
            }
        }

        public ProductRepository product;//=> throw new NotImplementedException();
        public ProductRepository Product
        {
            get
            {
                if (product == null)
                    product = new ProductRepository(EC_DbContext);
                return product;
            }
        }

        public ShoppingCartProductsRepository shoppingCartProducts;//=> throw new NotImplementedException();
        public ShoppingCartProductsRepository ShoppingCartProducts
        {
            get
            {
                if (shoppingCartProducts == null)
                    shoppingCartProducts = new ShoppingCartProductsRepository(EC_DbContext);
                return shoppingCartProducts;
            }
        }

        public ShoppingCartRepository shoppingCart;//=> throw new NotImplementedException();
        public ShoppingCartRepository ShoppingCart
        {
            get
            {
                if (shoppingCart == null)
                    shoppingCart = new ShoppingCartRepository(EC_DbContext);
                return shoppingCart;
            }
        }

        public VisaRepository visa;//=> throw new NotImplementedException();
        public VisaRepository Visa
        {
            get
            {
                if (visa == null)
                    visa = new VisaRepository(EC_DbContext);
                return visa;
            }
        }

        public UserRepository applicationUserIDentity;//=> throw new NotImplementedException();
        public UserRepository ApplicationUserIDentity
        {
            get
            {
                if (applicationUserIDentity == null)
                    applicationUserIDentity = new UserRepository(EC_DbContext);
                return applicationUserIDentity;
            }
        }
    }
}

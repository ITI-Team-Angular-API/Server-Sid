using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationUserIDentity : IdentityUser
    {
        public string Address { get; set; }
        public virtual ICollection<FavouriteProducts> FavouriteProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }

    public class ApplicationUserStore : UserStore<ApplicationUserIDentity>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager() : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db) : base(new RoleStore<IdentityRole>(db))
        {

        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUserIDentity>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double totalPrice { get; set; }
        [ForeignKey("appUser")]
        public string userId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ApplicationUserIDentity appUser { get; set; }
        public virtual ICollection<OrderedProducts> OrderedProducts { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")]
        public Nullable<int> CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

    public class FavouriteProducts
    {
        public int Id { get; set; }
        [ForeignKey("appUser")]
        public string userId { get; set; }
        [ForeignKey("Product")]
        public int productId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUserIDentity appUser { get; set; }
    }

    public class OrderedProducts
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Product")]
        public int productId { get; set; }
        [ForeignKey("Order")]
        public int orderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }

    public class ShoppingCart
    {
        [Key, ForeignKey("appUser")]
        public string Id { get; set; }
        public double totalPrice { get; set; }
        public virtual ApplicationUserIDentity appUser { get; set; }
        public virtual ICollection<ShoppingCartProducts> ShoppingCartProducts { get; set; }
    }

    public class ShoppingCartProducts
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Product")]
        public int productId { get; set; }
        [ForeignKey("ShoppingCart")]
        public string shoppingCartId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }

    public class PaymentMethod
    {
        [Key, ForeignKey("Order")]
        public int Id { get; set; }
        public string Method { get; set; }
        public virtual Order Order { get; set; }
    }

    public class Paypal
    {
        [Key, ForeignKey("PaymentMethod")]
        public int Id { get; set; }
        public string Account { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }

    public class Visa
    {
        [Key, ForeignKey("PaymentMethod")]
        public int Id { get; set; }
        public long Number { get; set; }
        public string Expire { get; set; }
        public int SequreCode { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }

    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIDentity>
    {

        public ApplicationDBContext() 
            : base("name=EcommerceDBConnection"){

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderedProducts> OrderedProducts { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartProducts> ShoppingCartProducts { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Paypal> Paypals { get; set; }
        public virtual DbSet<Visa> Visas { get; set; }
        public virtual DbSet<FavouriteProducts> FavouriteProducts { get; set; }
    }
}

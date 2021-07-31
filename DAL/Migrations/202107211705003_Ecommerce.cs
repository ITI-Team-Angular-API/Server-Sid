namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ecommerce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.FavouriteProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.String(maxLength: 128),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        totalPrice = c.Double(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        orderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.orderId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Method = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        totalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCartProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        shoppingCartId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.shoppingCartId)
                .Index(t => t.productId)
                .Index(t => t.shoppingCartId);
            
            CreateTable(
                "dbo.Paypals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentMethods", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Visas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Number = c.Long(nullable: false),
                        Expire = c.String(),
                        SequreCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentMethods", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visas", "Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Paypals", "Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.FavouriteProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.FavouriteProducts", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingCartProducts", "shoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCartProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.ShoppingCarts", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaymentMethods", "Id", "dbo.Orders");
            DropForeignKey("dbo.OrderedProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "orderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Visas", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Paypals", new[] { "Id" });
            DropIndex("dbo.ShoppingCartProducts", new[] { "shoppingCartId" });
            DropIndex("dbo.ShoppingCartProducts", new[] { "productId" });
            DropIndex("dbo.ShoppingCarts", new[] { "Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.PaymentMethods", new[] { "Id" });
            DropIndex("dbo.OrderedProducts", new[] { "orderId" });
            DropIndex("dbo.OrderedProducts", new[] { "productId" });
            DropIndex("dbo.Orders", new[] { "userId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.FavouriteProducts", new[] { "productId" });
            DropIndex("dbo.FavouriteProducts", new[] { "userId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Visas");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Paypals");
            DropTable("dbo.ShoppingCartProducts");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.OrderedProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.FavouriteProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

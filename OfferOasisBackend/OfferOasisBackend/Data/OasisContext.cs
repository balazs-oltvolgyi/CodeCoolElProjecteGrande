﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Data;

public class OasisContext : IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }

    public OasisContext(DbContextOptions<OasisContext> options): base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>()
            .HasIndex(u => u.Name)
            .IsUnique();

        builder.Entity<Product>()
            .HasData(
                new Product(1, "SmartPhone X", ProductType.Phone, 499, 25,
                    "https://www.apple.com/newsroom/images/product/iphone/standard/iphonex_front_back_glass_big.jpg.large.jpg"),
                new Product(2, "Laptop Pro", ProductType.Laptop, 999, 10,
                    "https://i0.wp.com/xiaomiplanet.sk/wp-content/uploads/2021/03/mi-laptop-pro-15-cover.jpg?fit=1200%2C630&ssl=1"),
                new Product(3, "Coffe Maker Deluxe", ProductType.Misc, 89, 50,
                    "https://i5.walmartimages.com/seo/Breville-Nespresso-VertuoPlus-Deluxe-Coffee-and-Espresso-Single-Serve-Machine-in-Piano-Black_9ec47473-3f2c-4b83-b9a3-8f8fc74a8a15_1.2966b5cfa618bc87fc1a29375b857ff5.jpeg"),
                new Product(4, "Designer Watch", ProductType.Misc, 199, 30,
                    "data:image/jpeg;base64,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"),
                new Product(5, "Bluetooth Speaker", ProductType.Speaker, 79, 20,
                    "https://fejhallgatoplaza.cdn.shoprenter.hu/custom/fejhallgatoplaza/image/cache/w800h800wt1/product/JBL/FLIP6/ESSENTIAL2/JBL_FLIP_ESSENTIAL_2_3_4_RIGHT_36370_x6.png?lastmod=1672414166.1561130024"),
                new Product(6, "HTC-M8", ProductType.Phone, 120, 20,
                    "https://purepng.com/public/uploads/large/purepng.com-htc-m8-phonesmartphoneandroidgooglephoneapplication-211519339760of8az.png"),
                new Product(7, "Football", ProductType.Misc, 20, 20,
                    "https://w7.pngwing.com/pngs/85/321/png-transparent-football-cricket-balls-ball-white-sports-equipment-sports-thumbnail.png"),
                new Product(8, "Dell PC", ProductType.Laptop, 300, 20,
                    "https://pngimg.com/uploads/computer_pc/computer_pc_PNG17489.png"),
                new Product(9, "Men's Flanel-Shirt", ProductType.Clothing, 80, 20,
                    "https://www.richa.eu/product/image/medium/2fobs_1100_1.png"),
                new Product(10, "Speaker", ProductType.Speaker, 100, 20,
                    "https://www.pngall.com/wp-content/uploads/13/Speaker-Sound-PNG-File.png"),
                new Product(11, "Women's Dress", ProductType.Clothing, 25, 20,
                    "https://w7.pngwing.com/pngs/639/359/png-transparent-dress-clothing-red-dress-fashion-vintage-clothing-desktop-wallpaper-thumbnail.png"),
                new Product(12, "Men's Shirt", ProductType.Clothing, 18, 20,
                    "https://shop.globalcyclingnetwork.com/cdn/shop/files/FR_400x.png?v=1701258835"),
                new Product(13, "Men's Sweater", ProductType.Clothing, 22, 20,
                    "https://andsons.co.uk/cdn/shop/files/CrewNeckBaseWaffleNavyFLATLAY1.png?v=1694792402&width=400"),
                new Product(14, "Apple Tablet", ProductType.Tablet, 150, 20,
                    "https://community.o2.co.uk/t5/image/serverpage/image-id/29750iF4AB0EFBDEBAF7D9/image-size/medium?v=1.0&px=-1"),
                new Product(15, "Microsoft Surface", ProductType.Laptop, 200, 20,
                    "https://ongpng.com/wp-content/uploads/2023/04/1.-Surface-Laptop-Studio-2045x1555-1.png"),
                new Product(16, "Microsoft Tablet", ProductType.Tablet, 160, 20,
                    "https://pngimg.com/uploads/tablet/tablet_PNG8567.png"),
                new Product(17, "Dell Laptop", ProductType.Laptop, 300, 20,
                    "https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTA5L3Jhd3BpeGVsX29mZmljZV8zMV9waG90b19vZl9hX2xhcHRvcF9tb2NrdXBfY2xvc2UtdXBfbWluaW1hbF9pc182M2Q2NzViOS00YjlhLTQ3OWEtOGMyMS1hYWQwMjViNWYzZDIucG5n.png"),
                new Product(18, "Samsung Laptop", ProductType.Laptop, 320, 20,
                    "https://toppng.com/uploads/preview/samsung-laptop-png-11552852081hsxubwozv3.png"),
                new Product(19, "Speaker System", ProductType.Speaker, 500, 20,
                    "https://e7.pngegg.com/pngimages/899/806/png-clipart-microphone-public-address-systems-sound-reinforcement-system-sound-system-disc-jockey-audio-cassette-electronics-speaker.png"),
                new Product(20, "HP Laptop", ProductType.Laptop, 450, 20,
                    "https://png.pngtree.com/element_our/20190528/ourmid/pngtree-physical-ultra-thin-laptop-image_1159591.jpg"),
                new Product(21, "Speaker System(2 speakers)", ProductType.Speaker, 480, 20,
                    "https://totalpng.com//public/uploads/preview/home-theater-audio-speaker-png-11657453511ximjngaa3q.png"),
                new Product(22, "Vivo Phone", ProductType.Phone, 300, 20,
                    "https://in-exstatic-vivofs.vivo.com/gdHFRinHEMrj3yPG/1692691698575/c0f180bba865685a87025f8ff514ab13.png"),
                new Product(23, "OnePlus 11", ProductType.Phone, 310, 20,
                    "https://oasis.opstatics.com/content/dam/oasis/page/2023/na/oneplus-11/specs/green-img.png"),
                new Product(24, "Redmi Note 9", ProductType.Phone, 305, 20,
                    "https://i01.appmifile.com/v1/MI_18455B3E4DA706226CF7535A58E875F0267/pms_1607399343.90816668!400x400!85.png"));
                
        
        builder.Entity<Order>()
            .HasIndex(u => u.Id)
            .IsUnique();
        
        builder.Entity<Order>()
            .HasData(new Order(1,"1","ABC","DGS",ShippingType.Delivery,4500));
        
        builder.Entity<OrderDetail>()
            .HasIndex(r => r.OrderDetailId)
            .IsUnique();

        builder.Entity<OrderDetail>()
            .HasData(
                new OrderDetail(1, 1, 1, 11, 5489));

        builder.Entity<Message>()
            .HasIndex(m => m.Id)
            .IsUnique();

        builder.Entity<User>().HasIndex(u => u.Id).IsUnique();

        builder.Entity<User>()
            .HasData(
                new User{Id = "1", UserName = "user", Email = "user@user.com",FirstName="User",LastName = "User",Address = "Budapest", PasswordHash = "AQAAAAEAACcQAAAAENK/4ok5tjNMBcxTuN+qHl/Uc3Cgbx9Uv3m7RAHcWDguVT/dQ08fNP96cMFwNx9JBA=="});
        
        builder.Entity<User>(b =>
        {
            b.HasMany<Order>().WithOne().HasForeignKey(o => o.UserId).IsRequired();
        });
        
        builder.Entity<Order>(b =>
        {
            b.HasMany<OrderDetail>().WithOne().HasForeignKey(o => o.OrderId).IsRequired();
        });
        
        builder.Entity<Product>(b =>
        {
            b.HasMany<OrderDetail>().WithOne().HasForeignKey(o => o.ProductId).IsRequired();
        });
        
        builder.Entity<CartDetail>()
            .HasIndex(c => c.Id)
            .IsUnique();
        
        builder.Entity<User>(b =>
        {
            b.HasMany<CartDetail>().WithOne().HasForeignKey(u => u.UserId).IsRequired();
        });
    }
}


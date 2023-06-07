using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FinderProject.Domian.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinderProject.Domian.IContext
{
   public interface IApplicationDbContext
    {
        
        DbSet<News> News { get; set; }
        DbSet<Favorite> Favorites { get; set; }
        DbSet<PersonalInformation> PersonalInformation { get; set; }
        DbSet<Advertising> Advertisings { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Features> Features { get; set; }
        DbSet<Images> Images { get; set; }
        DbSet<AddressInfo> AddressInfos { get; set; }
        DbSet<Possibilities> Possibilities { get; set; }
        DbSet<HotelFeature> HotelFeatures { get; set; }
        DbSet<TypeRoom> TypeRooms { get; set; }
        DbSet<SocialMedia> SocialMedias { get; set; }
        DbSet<CommentProduct> CommentProducts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }

        //DbSet<T> Set<T>() where T : class;
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

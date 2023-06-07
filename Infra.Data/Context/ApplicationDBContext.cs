using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinderProject.Infra.Data.Context
{
   public class ApplicationDBContext:IdentityDbContext<User>,IApplicationDbContext
    {
        public ApplicationDBContext() : base() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =.; Initial Catalog = TourismProjectClean; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Images> Images { get; set; }       
        public DbSet<Favorite> Favorites { get; set; }       
        public DbSet<AddressInfo> AddressInfos { get; set; }
        public DbSet<Possibilities> Possibilities { get; set; }
        public DbSet<HotelFeature> HotelFeatures { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<CommentProduct> CommentProducts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }

        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            seetData(modelBuilder);               
            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.isRemoved);
            modelBuilder.Entity<Features>().HasQueryFilter(p => !p.isRemoved);
            modelBuilder.Entity<Possibilities>().HasQueryFilter(p => !p.isRemoved);
            modelBuilder.Entity<HotelFeature>().HasQueryFilter(p => !p.isRemoved);            
            modelBuilder.Entity<SocialMedia>().HasQueryFilter(p => !p.isRemoved);
            modelBuilder.Entity<Images>().HasQueryFilter(p => !p.isRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.isRemoved);
        }
        #region SeetData
        private void seetData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category {Id=1,Name= "اقامتگاه و بوم گردی",iconCate= "fi-bed",ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=2,Name= "رستوران و کافی شاپ", iconCate= "fi-cafe", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=3,Name= "مراکز خرید", iconCate= "fi-shopping-bag", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=4,Name= "هنر و تئاتر", iconCate= "fi-museum", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=5,Name= "تفریحی و سرگرمی", iconCate= "fi-entertainment", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=6,Name= "باشگاه بدنسازی", iconCate= "fi-dumbell", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=7,Name= "تور و سفر", iconCate= "fi-disco-ball", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=8,Name= "سلامتی و پزشکی", iconCate= "fi-meds", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=9,Name= "آرایشی و زیبایی", iconCate= "fi-makeup", ParentCategoryId=null, });
            modelBuilder.Entity<Category>().HasData(new Category {Id=10,Name = "خدمات خودرو", iconCate= "fi-car", ParentCategoryId=null, });
        }
        #endregion
    }
}

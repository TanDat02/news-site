namespace DVCP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DVCPContext : DbContext
    {
        public DVCPContext()
            : base("name=DVCPContext")
        {
        }

        public virtual DbSet<WebInfo> WebInfo { get; set; }
     
        public virtual DbSet<StickyPost> StickyPosts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        //public virtual DbSet<User> Users { get; set; }

        public DbSet<systemview> systemviews { get; set; }
        public DbSet<systemgroup> systemgroups { get; set; }
        public DbSet<systemuser> systemusers { get; set; }
        public DbSet<systemlogin> systemlogins { get; set; }
        public DbSet<systemmap> systemmaps { get; set; }
        public DbSet<HethongDangky> HethongDangkys { get; set; }
        public DbSet<User1> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tbl_Series)
                .WithMany(e => e.Tbl_POST)
                .Map(m => m.ToTable("Tbl_SeriesPost").MapLeftKey("PostID").MapRightKey("seriesID"));

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tbl_Tags)
                .WithMany(e => e.Tbl_POST)
                .Map(m => m.ToTable("Tbl_PostTags").MapLeftKey("PostID").MapRightKey("TagID"));

            modelBuilder.Entity<User1>()
                .Property(e => e.EmailID)
                .IsUnicode(false);

            modelBuilder.Entity<User1>()
                .Property(e => e.EmailID)
                .IsUnicode(false);

            modelBuilder.Entity<User1>()
                .Property(e => e.userrole)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<DVCP.Models.Tinh> Tinhs { get; set; }

        public System.Data.Entity.DbSet<DVCP.Models.Xa> Xas { get; set; }

        public System.Data.Entity.DbSet<DVCP.Models.Huyen> Huyens { get; set; }

        public System.Data.Entity.DbSet<DVCP.Models.UserDetail> UserDetails { get; set; }
    }
}

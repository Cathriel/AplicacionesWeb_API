using System;
using Microsoft.EntityFrameworkCore;
using Roomies.API.Domain.Models;
using Roomies.API.Extensions;

namespace Roomies.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<FavouritePost> FavouritePosts { get; set; }
        public DbSet<Leaseholder> Landlords { get; set; }
        public DbSet<Leaseholder> Leaseholders { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserConversation> UserConversations { get; set; }
        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Conversations Entity
            builder.Entity<Conversation>().ToTable("Conversations");

            //Constraints
            builder.Entity<Conversation>().HasKey(c => c.Id);
            builder.Entity<Conversation>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Conversation>().Property(c => c.DateCreation).IsRequired();//


            // Relationships 
            builder.Entity<Conversation>()
                .HasMany(p => p.Messages)
                .WithOne(p => p.Conversation)
                .HasForeignKey(p => p.ConversationId);

            //FavouritePost Entity Intermediate Table
            builder.Entity<FavouritePost>().ToTable("FavouritePosts");

            builder.Entity<FavouritePost>().HasKey
                (p => new { p.PostId, p.LeaseholderId });

            builder.Entity<FavouritePost>()
                 .HasOne(pt => pt.Post)
                 .WithMany(p => p.FavouritePosts)
                 .HasForeignKey(pt => pt.PostId);

            builder.Entity<FavouritePost>()
                .HasOne(pt => pt.Leaseholder)
                .WithMany(t => t.FavouritePosts)
                .HasForeignKey(pt => pt.LeaseholderId);

            //Landlord Entity
            builder.Entity<Leaseholder>().ToTable("Landlords");

            builder.Entity<Leaseholder>().HasKey(p => p.IdUser);
            builder.Entity<Leaseholder>().Property(p => p.IdUser).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Leaseholder>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Leaseholder>().Property(p => p.Password).IsRequired().HasMaxLength(24);
            builder.Entity<Leaseholder>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Leaseholder>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Leaseholder>().Property(p => p.CellPhone).IsRequired().HasMaxLength(9);
            builder.Entity<Leaseholder>().Property(p => p.IdCard).IsRequired().HasMaxLength(8);
            builder.Entity<Leaseholder>().Property(p => p.Description).IsRequired().HasMaxLength(240);
            builder.Entity<Leaseholder>().Property(p => p.Birthday).IsRequired();
            builder.Entity<Leaseholder>().Property(p => p.Department).IsRequired().HasMaxLength(25);
            builder.Entity<Leaseholder>().Property(p => p.Province).IsRequired().HasMaxLength(25);
            builder.Entity<Leaseholder>().Property(p => p.District).IsRequired().HasMaxLength(25);
            builder.Entity<Leaseholder>().Property(p => p.Address).IsRequired().HasMaxLength(100);
            // Relationships 
            builder.Entity<Leaseholder>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.Leaseholder)
                .HasForeignKey(p => p.LeaseholderId);

            builder.Entity<Leaseholder>()
                .HasMany(p => p.Conversations)
                .WithOne(p => (Leaseholder)p.Receiver) ///
                .HasForeignKey(p => p.ReceiverId);


            //leaseholder Entity
            builder.Entity<Leaseholder>().ToTable("Leaseholders");

            builder.Entity<Leaseholder>().HasKey(p => p.IdUser);
            builder.Entity<Leaseholder>().Property(p => p.IdUser).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Leaseholder>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Leaseholder>().Property(p => p.Password).IsRequired().HasMaxLength(24);
            builder.Entity<Leaseholder>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Leaseholder>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Leaseholder>().Property(p => p.CellPhone).IsRequired().HasMaxLength(9);
            builder.Entity<Leaseholder>().Property(p => p.IdCard).IsRequired().HasMaxLength(8);
            builder.Entity<Leaseholder>().Property(p => p.Description).IsRequired().HasMaxLength(240);
            builder.Entity<Leaseholder>().Property(p => p.Birthday).IsRequired();
            builder.Entity<Leaseholder>().Property(p => p.Department).IsRequired().HasMaxLength(25);
            builder.Entity<Leaseholder>().Property(p => p.Province).IsRequired().HasMaxLength(25);
            builder.Entity<Leaseholder>().Property(p => p.District).IsRequired().HasMaxLength(25);
            builder.Entity<Leaseholder>().Property(p => p.Address).IsRequired().HasMaxLength(100);

            builder.Entity<Leaseholder>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.Leaseholder)
                .HasForeignKey(p => p.LeaseholderId);

            builder.Entity<Leaseholder>()
                .HasMany(p => p.Conversations)
                .WithOne(p => (Leaseholder)p.Sender) ///
                .HasForeignKey(p => p.SenderId);

            //Message Entity
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p => p.Id);
            builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.Content).IsRequired().HasMaxLength(300);
            builder.Entity<Message>().Property(p => p.SentDate).IsRequired();
            builder.Entity<Message>().Property(p => p.Seen).IsRequired();
            //-----------------

            // PaymentMethod Entity
            builder.Entity<PaymentMethod>().ToTable("PaymentMethods");

            builder.Entity<PaymentMethod>().HasKey(e => e.Id);
            builder.Entity<PaymentMethod>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentMethod>().Property(e => e.CVV).IsRequired().HasMaxLength(3);
            builder.Entity<PaymentMethod>().Property(e => e.ExpiryDate).IsRequired();
            //--------------------

            // Plan Entity
            builder.Entity<Plan>().ToTable("Plans");

            // Constraints

            builder.Entity<Plan>().HasKey(p => p.Id);
            builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Plan>().Property(p => p.Price).IsRequired();
            //builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(50).
            //builder.Entity<Plan>().Property(p => p.Description).IsRequired().HasMaxLength();

            builder.Entity<Plan>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Plan)
                .HasForeignKey(p => p.PlanId);    
            
            // Posts Entity

            builder.Entity<Post>().ToTable("Posts");

            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Entity<Post>().Property(p => p.Address).IsRequired().HasMaxLength(50);
            builder.Entity<Post>().Property(p => p.Province).IsRequired().HasMaxLength(25);
            builder.Entity<Post>().Property(p => p.District).IsRequired().HasMaxLength(25);
            builder.Entity<Post>().Property(p => p.Department).IsRequired().HasMaxLength(25);
            builder.Entity<Post>().Property(p => p.Price).IsRequired();
            builder.Entity<Post>().Property(p => p.RoomQuantity).IsRequired();
            builder.Entity<Post>().Property(p => p.PostDate).IsRequired();
            //-------------------------------------

            // Review Entity

            builder.Entity<Review>().ToTable("Reviews");

            builder.Entity<Review>().HasKey(e => e.Id);
            builder.Entity<Review>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(e => e.Content).IsRequired().HasMaxLength(300);
            builder.Entity<Review>().Property(e => e.Date).IsRequired();
            builder.Entity<Review>().Property(e => e.StarQuantity).IsRequired();

            //UserPaymentMethod Entity Intermediate Table
            builder.Entity<UserPaymentMethod>().ToTable("UserPaymentMethods");

            builder.Entity<UserPaymentMethod>().HasKey(p => new { p.UserId, p.PaymentMethodId });

            builder.Entity<UserPaymentMethod>()
                 .HasOne(pt => pt.User)
                 .WithMany(p => p.UserPaymentMethods)
                 .HasForeignKey(pt => pt.UserId);

            builder.Entity<UserPaymentMethod>()
                .HasOne(pt => pt.PaymentMethod)
                .WithMany(t => t.UserPaymentMethods)
                .HasForeignKey(pt => pt.PaymentMethodId);

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}

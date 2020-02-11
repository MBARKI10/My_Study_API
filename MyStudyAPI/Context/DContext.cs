using MyStudyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyStudyAPI.Context
{
    class DContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Like> Likes { get; set; }

        public DbSet<Subgroup> Subgroups { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<TodoComment> TodoComments { get; set; }
        public DbSet<Done> Dones { get; set; }
        public DbSet<Upsession> Upsessions { get; set; }
        public DbSet<Participate> Participates { get; set; }
        public DbSet<Report> Reports { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(p => p.Events).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.Todos).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.Posts).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.PostComments).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.TodoComments).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.EventComments).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.Likes).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.Dones).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.Joineds).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.Upsessions).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(p => p.Reports).WithRequired(t => t.User).HasForeignKey(c => c.IdUser).WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>().HasMany(p => p.Comments).WithRequired(t => t.Post).HasForeignKey(c => c.IdPost).WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>().HasMany(p => p.Likes).WithRequired(t => t.Post).HasForeignKey(c => c.IdPost).WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>().HasMany(p => p.Reports).WithRequired(t => t.Post).HasForeignKey(c => c.IdPost).WillCascadeOnDelete(false);

            modelBuilder.Entity<Like>().HasKey(p => new { p.IdPost, p.IdUser });

            modelBuilder.Entity<Participate>().HasKey(p => new { p.IdEvent, p.IdUser });

            modelBuilder.Entity<Upsession>().HasKey(p => new { p.IdHour,  p.IdUser });

            modelBuilder.Entity<Done>().HasKey(p => new { p.IdTodo, p.IdUser });

            modelBuilder.Entity<Report>().HasKey(p => new { p.IdPost, p.IdUser });
            
            modelBuilder.Entity<Subgroup>().HasMany(p => p.Posts).WithRequired(t => t.Subgroup).HasForeignKey(c => c.IdSubgroup).WillCascadeOnDelete(false);

            modelBuilder.Entity<Hour>().HasMany(p => p.Todos).WithRequired(t => t.Hour).HasForeignKey(c => c.IdHour).WillCascadeOnDelete(false);

            modelBuilder.Entity<Todo>().HasMany(p => p.Comments).WithRequired(t => t.Todo).HasForeignKey(c => c.IdTodo).WillCascadeOnDelete(false);
            modelBuilder.Entity<Todo>().HasMany(p => p.Dones).WithRequired(t => t.Todo).HasForeignKey(c => c.IdTodo).WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>().HasMany(p => p.Comments).WithRequired(t => t.Event).HasForeignKey(c => c.IdEvent).WillCascadeOnDelete(false);
            modelBuilder.Entity<Event>().HasMany(p => p.Joined).WithRequired(t => t.Event).HasForeignKey(c => c.IdEvent).WillCascadeOnDelete(false);
        }
    }
}

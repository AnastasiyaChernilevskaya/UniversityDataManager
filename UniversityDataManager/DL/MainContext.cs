using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityDataManager.DL.Entities;
using System.Data.Entity;

namespace UniversityDataManager.DL
{
    public class MainContext : DbContext
    {
        public MainContext() : base("name=MainContext")
        {
        }

        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectLog> ProjectLogs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProject> StudentProjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MainContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public static MainContext Create()
        {
            return new MainContext();
        }
    }
}
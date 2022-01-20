using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainRes.Model
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LI8CF0L\\SQLEXPRESS;database=TrainResDb;integrated security=true");
        }
        public Context(DbContextOptions<Context> options):base(options)
        {
            Database.EnsureCreated();
        }
        public Context()
        {
        }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Vagon> Vagons { get; set; }
    }
}

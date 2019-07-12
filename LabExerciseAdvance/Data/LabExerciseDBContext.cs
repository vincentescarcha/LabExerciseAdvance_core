using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExerciseAdvance
{
    public class LabExerciseDBContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }

        public DbSet<Registration> Registration { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=LabExerciseDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Adult>().ToTable("Adults");
            bldr.Entity<Infant>().ToTable("Infants");
            bldr.Entity<Child>().ToTable("Childs");
        }
    }
}

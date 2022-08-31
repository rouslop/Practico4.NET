using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Practico4Context : DbContext
    {
        public Practico4Context() { }
        public Practico4Context(DbContextOptions<Practico4Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-KHTKCC25\\SQLEXPRESS;Database=Practico3;User= sa; Password = 1234; ");
            }
        }
        public DbSet<Personas> Personas { get; set; }
    }
}

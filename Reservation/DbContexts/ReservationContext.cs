using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reservation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.DbContexts
{
    public class ReservationContext : IdentityDbContext//DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
          : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<ReservationPlace> Reservation { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
        }
        




    }
}

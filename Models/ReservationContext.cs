using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
namespace MVCProject.Models
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options): base(options)
        { 
            
        }

        public DbSet<Reservation> Reservations { get; set; }

        //public DbSet<>


        
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            


            modelbuilder.Entity<Reservation>().HasData(
                 new Reservation()
                 {
                     Id = 11,
                     FirstName = "John",
                     LastName = "Bushin",
                     email = "johnbushin@g.com",
                     persons = 3,
                     PhoneNumber = 2293331234,
                     Time = new DateTime(2022, 7, 1, 8, 00, 00)
                 },
                new Reservation()
                {
                    Id = 12,
                    FirstName = "Susan",
                    LastName = "Green",
                    email = "sgreen@y.com",
                    persons = 2,
                    PhoneNumber = 4442282193,
                    Time = new DateTime(2022, 5, 15, 2, 00, 00)
                },
                new Reservation()
                {
                    Id = 13,
                    FirstName = "James",
                    LastName = "Jones",
                    email = "JJ@g.com",
                    persons = 10,
                    PhoneNumber = 7890234586,
                    Time = new DateTime(2022, 7, 6, 6, 00, 00)
                }



                );
        }


    }
    
}

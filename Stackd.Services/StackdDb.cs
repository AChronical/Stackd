using Microsoft.EntityFrameworkCore;
using Stackd.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Stackd.Services
{
    //Anica Janjic 991799177
    //I implemented the User and Ticket Database and connected them to our application
    public class StackdDb : DbContext
    {

        public StackdDb(DbContextOptions<StackdDb> option) : base(option) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Model
{
    public class DatabaseContext: DbContext
    {
	private const string ConnectionString = "Server=127.0.0.1;Port=3306;Database=rating;Uid=root;Pwd=root;";

        public DbSet<DriverRider> driverRiders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionString);
        }
    }
}

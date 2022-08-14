using Microsoft.EntityFrameworkCore;
using MVCAPIDemo.Models;

namespace MVCAPIDemo.Common
{
    public class MyDataContext : DbContext
    {

		public DbSet<UserInfo> Users { get; set; }

		public string ConnectionString { get; set; }

		public MyDataContext(string dbFile)
		{
			ConnectionString = "Data Source=" + Path.Combine(Environment.CurrentDirectory, dbFile);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(ConnectionString);
		}

	}
}

using System.Data.Entity;
using ModelLib;

namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base(GetConnectionString())
        {
            Database.SetInitializer<Context>(null);
        }
        public DbSet<Wine> Wines { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Wine>().ToTable("Wines");
            base.OnModelCreating(modelBuilder);
        }
        private static string GetConnectionString()
        {
            string databasePath = @"C:\Users\User\Documents\GitHub\AIS_Lab1\DAL\DatabaseWines.mdf";
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databasePath};Integrated Security=True;Connect Timeout=30";
        }
    }
}

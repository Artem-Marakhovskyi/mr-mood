namespace MrMood.DataAccess.Context
{
    public class DbContextOptions
    {
        public string ConnString { get; set; }

        public DbContextOptions(string connString)
        {
            ConnString = connString;
        }
    }
}

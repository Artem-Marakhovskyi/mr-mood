using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrMood.DataAccess.Initializer
{
    public static class Program
    {
        public static void Main()
        {
            var connString = "DataSource=(localdb)\\MSSQLLocalDB;InitialCatalog=MoodDatabase;IntegratedSecurity=True;ConnectTimeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            
        }
    }
}

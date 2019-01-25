using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Scooch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Scooch.Tests
{
    public static class DbOptionsFactory
    {
        static DbOptionsFactory()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Path.GetFullPath("../../../")))
                .AddJsonFile("testsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var connectionString = config["ConnectionStrings:DefaultConnection"];

            DbContextOptions = new DbContextOptionsBuilder<ScoochDBContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public static DbContextOptions<ScoochDBContext> DbContextOptions { get; }
    }

}

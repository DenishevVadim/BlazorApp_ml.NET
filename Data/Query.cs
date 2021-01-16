using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorAppML.Data
{
    class Query
    {
        public DbContextOptions<ApplicationDbContext> options;

        public Query()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");
 
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
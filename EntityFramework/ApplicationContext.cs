using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ApplicationContext : DbContext// определяет контекст данных, используемый для взаимодействия с базой данных
    {
        public DbSet<User> Users => Set<User>();//представляет набор объектов, которые хранятся в базе данных
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//устанавливает параметры подключения
        {
            //DbContextOptionsBuilder с помощью метода UseSqlite позволяет настроить строку подключения для соединения с базой данных SQLite.
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}


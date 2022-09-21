﻿using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
// установка пути к текущему каталогу
builder.SetBasePath(Directory.GetCurrentDirectory());
// получаем конфигурацию из файла appsettings.json
builder.AddJsonFile("appsettings.json");
// создаем конфигурацию
var config = builder.Build();
// получаем строку подключения
string connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
var options = optionsBuilder.UseSqlite(connectionString).Options;
// Добавление
using (ApplicationContext db = new ApplicationContext(options))
{
    User tom = new User { Name = "Nikita",Surname = "Poljakov",LivePlace = "Eesti",email = "nikita@gmail.com", Age = 19 };
  

    // Добавление
    db.Users.Add(tom);
    db.SaveChanges();
}

// получение
using (ApplicationContext db = new ApplicationContext(options))
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Andmed pärast lisamist:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name},{u.Surname},{u.LivePlace},{u.email},{u.Age}");
    }
}

// Редактирование
using (ApplicationContext db = new ApplicationContext(options))
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        user.Name = "Bob";
        user.Age = 44;
        user.email = "bob@gmail.com";
        user.Surname = "Bobikov";
        user.LivePlace = "USA";
        //обновляем объект
        //db.Users.Update(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nAndmed pärast redigeerimist:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name},{u.Surname},{u.LivePlace},{u.email},{u.Age}");
    }
}

// Удаление
using (ApplicationContext db = new ApplicationContext(options))
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        //удаляем объект
        db.Users.Remove(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nAndmed pärast kustutamist:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name},{u.Surname},{u.LivePlace},{u.email},{u.Age}");
    }
}
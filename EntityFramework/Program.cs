using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using (ApplicationContext db = new ApplicationContext())
{
    // создаем два объекта User
    User artem = new User { Name = "Artem", Surname = "Stryzhakov", LivePlace = "Keila", email = "striz@gmail.com", Age = 18 };
    User jaan = new User { Name = "Jaan", Surname = "Krohhin", LivePlace = "Tallinn", email = "krohha@gmail.com", Age = 20 };

    // добавляем их в бд
    db.Users.Add(artem);
    db.Users.Add(jaan);
    db.SaveChanges();
    Console.WriteLine("Objektide salvestamine õnnestus");

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Objektide loend:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name},{u.Surname},{u.LivePlace},{u.email},{u.Age}");
    }
}

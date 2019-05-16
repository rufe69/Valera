using Bot.DAI.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DAI
{
    class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        DbSet<Student> Students { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }

        DbSet<User> Users { get; set; }
        DbSet<Token> Tokens { get; set; }
        DbSet<Information> Informations { get; set; }
        DbSet<Key> Keys { get; set; }
        DbSet<EventType> EventTypes { get; set; }
        DbSet<Event> Events { get; set; }
    }
}

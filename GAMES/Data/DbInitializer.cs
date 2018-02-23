using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;

namespace GAMES.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GamesContext context)

        {
            context.Database.Migrate();
            //Replace below with GAMES tables to populate if needed
            //if (context.Client.Any()) { return; }

            //var clients = new Client[]
            //{
            //    new Client{Name="NASBA"},
            //    new Client{Name="Nissan North America" },
            //    new Client{Name="Lifepoint"}
            //};
            //foreach (Client c in clients) { context.Client.Add(c); }
            context.SaveChanges();

        }
    }
}

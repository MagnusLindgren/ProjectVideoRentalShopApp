using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    class Seeding
    {
        static void Main(string[] args)
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Rentals);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Members);
                ctx.RemoveRange(ctx.Actors);

                // Några memebers för testing
                ctx.AddRange(new List<Member>
                {
                    new Member {
                                Username    = "Booken",
                                FirstName   = "Anna",
                                LastName    = "Book",
                                Address     = "Fågelgatan 5",
                                Phone       = "0701987654",
                                Email       = "booken@hotmail.com"
                                },

                    new Member {
                                Username    = "Arvid123",
                                FirstName   = "Arvid",
                                LastName    = "Svensson",
                                Address     = "Storgatan 23",
                                Phone       = "0722632717",
                                Email       = "arvidjr123@gmail.com"
                                }
                });

                API.AddNewMember("Torsten, Andersson, Traststigen 22, 0701404505, torand@rocketmail.com, Torand");

                // Ladda in från testdata från txtfil
                var movies = new List<Movie>();
                
                var readLines = File.ReadAllLines(@"..\..\..\SeedData\projektarbetefil.txt");
                for (int i = 0; i < readLines.Length; i++)
                {
                    //titel, category, year, director, actor, url
                    var actors = new List<Actor>();
                    var item = readLines[i].Split(", ");
                    var actor = ctx.Actors.FirstOrDefault(g => g.Name == item[4]) ?? new Actor { Name = item[4] }; //Gör så inga dubletter hamnar i actors
                    var url = item[5];

                    // Tagit från Björns kod. Hoppa över icke fungerande Url:er
                    try { var test = new Uri(url); } 
                    catch (Exception) { continue; }
                    
                    actors.Add(actor);
                    movies.Add(new Movie { Title = item[0], Category = item[1], Year = int.Parse(item[2]), Director = item[3], ImageUrl = url, Actors = actors  });
                    ctx.Actors.Update(actor);                  
                }

                ctx.AddRange(movies);
                ctx.SaveChanges();
            }

        }
    }
}

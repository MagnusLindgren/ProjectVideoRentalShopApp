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
                                FirstName   = "Anna",
                                LastName    = "Book",
                                Address     = "Fågelgatan 5",
                                Phone       = "0701987654",
                                Email       = "booken@hotmail.com"
                                },

                    new Member {
                                FirstName   = "Arvid",
                                LastName    = "Svensson",
                                Address     = "Storgatan 23",
                                Phone       = "0722632717",
                                Email       = "arvidjr123@gmail.com"
                                }
                });

                // Ladda in från testdata från txtfil
                var movies = new List<Movie>();
                
                var readLines = File.ReadAllLines(@"..\..\..\SeedData\projektarbetefil.txt");
                for (int i = 0; i < readLines.Length; i++)
                {
                    //titel, category, year, director, actor
                    var actors = new List<Actor>();
                    var item = readLines[i].Split(", ");
                    var actor = new Actor { Name = item[4] };

                    actors.Add(actor);
                    movies.Add(new Movie { Title = item[0], Category = item[1], Year = int.Parse(item[2]), Director = item[3], Actors = actors  });
                    ctx.Actors.Update(actor); // TODO Fixa så den inte lägger till dubbletter.                    
                }

                ctx.AddRange(movies);
                ctx.SaveChanges();
            }
           
        }
    }
}

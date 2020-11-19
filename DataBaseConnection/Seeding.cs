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
                    new Member {FirstName   = "Anna",
                                LastName    = "Book",
                                Address     = "Fågelgatan 5",
                                Phone       = "0701987654",
                                Email       = "booken@hotmail.com"
                                },

                    new Member {FirstName   = "Arvid",
                                LastName    = "Svensson",
                                Address     = "Storgatan 23",
                                Phone       = "0722632717",
                                Email       = "arvidjr123@gmail.com"
                                }
                });

                // Ladda in från testdata från txtfil
                var movies = new List<Movie>();
                var actors = new List<Actor>();
                var readLines = File.ReadAllLines(@"..\..\..\SeedData\projektarbetefil.txt");
                for (int i = 0; i < readLines.Length; i++)
                {
                    //titel, category, year, director, actor
                    var item = readLines[i].Split(", ");
                    
                    movies.Add(new Movie { Title = item[0], Category = item[1], Year = int.Parse(item[2]), Director = item[3],  });
                    ctx.Actors.Add(new Actor { Name = item[4] }); // TODO Fixa så den inte lägger till dubbletter.                    
                }
                ctx.AddRange(movies);
                ctx.SaveChanges();
            }
           
        }
    }
}

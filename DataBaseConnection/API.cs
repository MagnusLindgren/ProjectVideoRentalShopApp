using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    class API
    {
        public static List<Movie> GetMovieSlice(int a, int b)
        {
            using var ctx = new Context();
            return ctx.Movies.OrderBy(m => m.Title).Skip(a).Take(b).ToList();
        }

        public static Member GetMemberByFirstName(string name)
        {
            using var ctx = new Context();
            return ctx.Members.FirstOrDefault(m => m.FirstName.ToLower() == name.ToLower());
        }
    }
}

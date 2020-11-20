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
        public static Member GetMemberByUserName(string username)
        {
            using var ctx = new Context();
            return ctx.Members.FirstOrDefault(m => m.Username.ToLower() == username.ToLower());
        }
        public static bool RegisterSale(Member member, Movie movie)
        {
            using var ctx = new Context();
            try
            {
                // Här säger jag åt contextet att inte oroa sig över innehållet i dessa records.
                // Om jag inte gör detta så kommer den att försöka updatera databasens Id och cracha.
                ctx.Entry(member).State = EntityState.Unchanged;
                ctx.Entry(movie).State = EntityState.Unchanged;

                ctx.Add(new Rental() { StartDate = DateTime.Now, RentedBy = member, Movies = movie });
                return ctx.SaveChanges() == 1;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
    }
}

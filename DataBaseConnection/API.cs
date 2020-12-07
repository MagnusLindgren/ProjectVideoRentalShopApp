using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public class API
    {
        // Här har jag ett kontext tillgängligt för alla API metoder.
        static Context ctx;

        // Statiska konstruktorer kallas på innan den statiska klassen används.
        static API()
        {
            ctx = new Context();
        }

        public static List<Movie> GetMovieSlice(int skip_x, int take_x)
        {
            return ctx.Movies
                .OrderBy(m => m.Title)
                .Skip(skip_x)
                .Take(take_x)
                .ToList();
        }
        
        public static List<Movie> GetMovieByCategory(string category)
        {
            return ctx.Movies
                .OrderBy(m => m.Title)
                .Where(m => m.Category == category)
                .ToList();
        }

        //Hämtar på senaste tilläget i databasen (Högst id först)
        public static List<Movie> GetMovieByNew()
        {
            return ctx.Movies
                .OrderByDescending(m => m.Id)
                .ToList();
        }

        public static List<Movie> GetMovieByTitle(string titleName)
        {
            return ctx.Movies
                .OrderBy(m => m.Title)
                .Where(m => m.Title.Contains(titleName))
                .ToList();
        }
        
        public static Member GetCustomerByName(string name) // Vet inte om denna kommer fungera för oss
        {
            return ctx.Members
                .FirstOrDefault(c => c.Username.ToLower() == name.ToLower());
        }
        public static bool RegisterSale(Member customer, Movie movie)
        {
            // Försök att lägga till ett nytt sales record
            try
            {
                ctx.Add(new Rental() { StartDate = DateTime.Now, RentedBy = customer, Movies = movie });

                bool one_record_added = ctx.SaveChanges() == 1;
                return one_record_added;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }

        public static bool AddNewMember(string newMember)
        {
            try
            {
                var item = newMember.Split(", ");
                ctx.Add(new Member() { FirstName = item[0], LastName = item[1], Address = item[2], Phone = item[3], Email = item[4], Username = item[5]});

                bool newMemberAdded = ctx.SaveChanges() == 1;
                return newMemberAdded;
            }
            catch  (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
    }
}

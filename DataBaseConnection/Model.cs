using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseConnection
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Moivies { get; set; }
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public virtual List<Actor> Actors { get; set; }
    }
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
    public class Rental
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public virtual Member RentedBy { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}

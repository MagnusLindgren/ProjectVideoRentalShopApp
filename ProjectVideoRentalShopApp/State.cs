using System;
using System.Collections.Generic;
using System.Text;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;

namespace ProjectVideoRentalShopApp
{
    static class State
    {
        public static Member User { get; set; }
        public static List<Movie> Movies { get; set; }
        public static Movie Pick { get; set; }
    }
}

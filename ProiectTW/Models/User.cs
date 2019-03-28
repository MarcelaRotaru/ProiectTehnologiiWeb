namespace ProiectTW.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        private UsersStoreContext context;

        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime TurnDate { get; set; }

        public List<Locations> locationsList = new List<Locations>();

        public List<Locations> savedLocationsList = new List<Locations>();

    }
}

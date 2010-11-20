using System;

namespace ConOverConf.Core.Models
{
    public class Game
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public double Rating { get; private set; }
        public string Notes { get; private set; }
        public string Borrower { get; private set; }
        public DateTime AddedOn { get; private set; }

        protected Game() { }

        public Game(string title, double rating, string notes)
        {
            Title = title;
            Rating = rating;
            Notes = notes;
        }

    }
}
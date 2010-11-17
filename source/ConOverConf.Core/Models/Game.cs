using System;

namespace ConOverConf.Core.Models
{
    public class Game
    {
        public virtual Guid Id { get; private set; }
        public virtual string Title { get; private set; }
        public virtual double Rating { get; private set; }
        public virtual string Notes { get; private set; }
        public virtual string Borrower { get; private set; }
        public virtual DateTime AddedOn { get; private set; }

        protected Game() { }

        public Game(string title, double rating, string notes)
        {
            Title = title;
            Rating = rating;
            Notes = notes;

            AddedOn = DateTime.Now;
        }

    }
}
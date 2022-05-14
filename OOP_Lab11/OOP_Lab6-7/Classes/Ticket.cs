using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6_7.Classes
{
    public class Ticket
    {
        public Guid Id_Schedule { get; set; }
        public DateTime DateTime { get; set; }

        public Guid Id_Movie { get; set; }
        public string Title { get; set; }   
        public string Director { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
        public string Photo { get; set; }

        public Ticket() { }

        public Ticket(Guid id_sched, Guid id_movie, DateTime date, string title, string director, string genre, int duration, float rating, string photo)
        {
            Id_Schedule = id_sched;
            Id_Movie = id_movie;
            DateTime = date;
            Title = title;
            Director = director;
            Genre = genre;
            Duration = duration;
            Rating = rating;
            Photo = photo;
        }
    }
}

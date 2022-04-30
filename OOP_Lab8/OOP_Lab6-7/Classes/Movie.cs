using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace OOP_Lab6_7.Classes
{
    [Serializable]
    public class Movie
    {
        private string _title;
        private string _description;
        private string _genre;
        private int _duration;
        private string _rating;
        private string _photo;

        [XmlElement(ElementName = "Title")]
        public string Title { get => _title; set => _title = value; }
        [XmlElement(ElementName = "Description")]
        public string Director { get => _description; set => _description = value; }
        [XmlElement(ElementName = "Genre")]
        public string Genre { get => _genre; set => _genre = value; }
        [XmlElement(ElementName = "Duration")]
        public int Duration { get =>_duration; set => _duration = value; }
        [XmlElement(ElementName = "Rating")]
        public string Rating { get => _rating; set => _rating = value; }
        [XmlElement(ElementName = "Photo")]
        public string Photo { get => _photo; set => _photo = value; }


        public Movie() { }

        public Movie(string title, string dir, string genre, 
            int duration, string rating, string photo)
        {
            Title = title;
            Director = dir;
            Genre = genre;
            Duration = duration;
            Rating = rating;
            Photo = photo;
        }

    }
}

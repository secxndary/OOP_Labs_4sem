using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace OOP_Lab6_7.Classes
{
    [Serializable]
    public class Cinema
    {
        [XmlArray("FilmsList"), XmlArrayItem("Movie")]
        public List<Movie> filmsList;

        public Cinema() { filmsList = new List<Movie>(); }

        public void Add(Movie m) => filmsList.Add(m);

        
    }
}

using System.IO;
using System.Xml.Serialization;
using OOP_Lab6_7.Classes;

namespace OOP_Lab6_7
{
    public static class DataTransfer
    {
        public static void SerializeFilms(Cinema films)
        {
            var serializer = new XmlSerializer(typeof(Cinema));
            using (var fs = new FileStream(@"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab6-7\OOP_Lab6-7\Resources\films.xml", 
                FileMode.Create))
            {
                serializer.Serialize(fs, films);
            }
        }


        public static Cinema DeserializeFilms()
        {
            var serializer = new XmlSerializer(typeof(Cinema));
            Cinema deserializedFilmsList = null;

            using (var fs = new FileStream(@"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab6-7\OOP_Lab6-7\Resources\films.xml", 
                FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    deserializedFilmsList = serializer.Deserialize(fs) as Cinema;
            }

            return deserializedFilmsList;
        }





        // 8 лаба

        public static void SerializeOld(Cinema films)
        {
            var serializer = new XmlSerializer(typeof(Cinema));
            using (var fs = new FileStream(@"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab6-7\OOP_Lab6-7\Resources\filmsOld.xml",
                FileMode.Create))
            {
                serializer.Serialize(fs, films);
            }
        }


        public static Cinema DeserializeOld()
        {
            var serializer = new XmlSerializer(typeof(Cinema));
            Cinema deserializedFilmsList = null;

            using (var fs = new FileStream(@"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab6-7\OOP_Lab6-7\Resources\filmsOld.xml",
                FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    deserializedFilmsList = serializer.Deserialize(fs) as Cinema;
            }

            return deserializedFilmsList;
        }
    }
}

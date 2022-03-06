using System;

namespace OOP_Lab4
{
    [Serializable]
    public class Lector      /// агрегируемый объект, который поможет в записи инфы
    {
        public string Department { get; set; }      /// кафедра
        public string Name { get; set; }            /// фио
        public string Auditorium { get; set; }      /// аудитория

        public Lector() { }

        public Lector(string dep, string name, string aud)
        {
            Department = dep;
            Name = name;
            Auditorium = aud;
        }
    }
}

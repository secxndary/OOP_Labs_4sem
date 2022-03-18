using System;
using System.Collections.Generic;

namespace OOP_Lab4
{
    [Serializable]
    public class Discipline
    {
        public string Name { get; set; }                /// название дисциплины
        public string Semester { get; set; }            /// строка со значением семестра
        public List<string> Course { get; set; }        /// курс на котором читается (мб несколько)
        public List<string> Speciality { get; set; }    /// специальность (тоже мб несколько)
        public int NumberOfLections { get; set; }       /// кол-во лекций
        public int NumberOfLabs { get; set; }           /// кол-во лабораторных
        public string Control { get; set; }             /// экзамен\зачёт
        public Lector lector { get; set; }              /// лектор (агрегируемый объект)
        public string Type { get; set; }                /// ТИП ДИСЦИПЛИНЫ (ЛАБА 4)

        public Discipline()                             /// корректный конструктор без параметров
        {
            Course = new List<string>();
            Speciality = new List<string>();
            lector = new Lector();
        }

        /// конструктор который дальше будет использоваться для красивой записи инфы в объект
        public Discipline(string name, string sem, List<string> course, List<string> spec,
            int numLect, int numLabs, string ctrl, Lector lect)
        {
            Name = name;
            Semester = sem;
            Course = course;
            Speciality = spec;
            NumberOfLections = numLect;
            NumberOfLabs = numLabs;
            Control = ctrl;
            lector = lect;
        }

        public override string ToString()   /// вывод инфы об объекте
        {
            string course = "";
            string speciality = "";
            foreach (string c in Course)
                course += c + "; ";
            foreach (string s in Speciality)
                speciality += s + "; ";

            string res = $"\t\t\t       BUILDER\n{Type}Название: {Name}\nКурс: {course}\nСеместр: {Semester}\n" +
                $"Специальность: {speciality}\nЧасов лекций: {NumberOfLections}\n" +
                $"Часов лабораторных: {NumberOfLabs}\nТип контроля: {Control}\n" +
                $"ФИО лектора: {lector.Name}\nКафедра: {lector.Department}\n" +
                $"Аудитория: {lector.Auditorium}\n\n==============================================\n\n";
            return res;
        }
    }




    //public class ProgrammingDiscipline : Discipline
    //{
    //    public override string ToString() =>
    //        Type + "\n" + base.ToString();

    //    public ProgrammingDiscipline(string name, string sem, List<string> course,
    //        List<string> spec, int numLect, int numLabs, string ctrl, Lector lect) :
    //        base(name, sem, course, spec, numLect, numLabs, ctrl, lect) =>
    //        Type = "ДИСЦИПЛИНА ПО ПРОГРАММИРОВАНИЮ";
    //}


    //public class WebDiscipline : Discipline
    //{
    //    public override string ToString() =>
    //        Type + "\n" + base.ToString();

    //    public WebDiscipline(string name, string sem, List<string> course,
    //       List<string> spec, int numLect, int numLabs, string ctrl, Lector lect) :
    //       base(name, sem, course, spec, numLect, numLabs, ctrl, lect)
    //    {
    //        Type = "ДИСЦИПЛИНА ПО WEB/FRONT";
    //        lector.Name = "Н.А.Жиляк";
    //    }

    //}
}

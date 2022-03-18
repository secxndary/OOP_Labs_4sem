using System;
using System.Collections.Generic;

namespace OOP_Lab4
{
    public class Client
    {
        // рандомим: либо клонируем случайный объект из билдера, либо случайный объект из абстрактной фабрики
        public string CloneRandom()
        {
            Random random = new Random();
            int i = random.Next(0, 2);

            // если рандомнуло на 0 и список дисциплин из абстракной фабрики не пуст:
            if (i == 0 && AbstractFactory.listAF.Count != 0)
            {
                var prot = new PrototypeAF();       // клонируем рандом дисциплину из фабрики
                var prot1 = prot.Clone();
                string res = prot1.ToString();      // и возвращаем ее строкове представление
                return res;
            }
            // если прокнуло не 0 и список дисциплин из билдера не пуст:
            else if (Director.listOfDisciplinesBuilder.Count != 0)
            {
                var prot = new PrototypeBuilder();  // из билдера
                var prot1 = prot.Clone();
                string res = prot1.ToString();
                return res;
            }
            return "";
        }
    }



    // прототип дисциплины. абстрактный класс. смысл в том, чтобы клонировать один случайный объект
    // либо из дисциплины билдера, либо из дисциплины абстрактной фабрики. классы там разные,
    // так что надо создать в методе клонирования один общий прототип для них и подгонять потом
    // всё под этот коннкретный прототип с помощью наследования и переопределения
    abstract class Prototype
    {
        public string Name { get; set; }
        public string Semester { get; set; }
        public List<string> Course { get; set; }
        public List<string> Speciality { get; set; }
        public int NumberOfLections { get; set; }
        public int NumberOfLabs { get; set; }
        public string Control { get; set; }
        public string LectorName { get; set; }
        public string LectorDepartment { get; set; }
        public string LectorAuditorium { get; set; }
        public string Type { get; set; }


        public Prototype() { }

        // конструктор для любого прототипа дисциплины, чтобы было удобнее присваивать значения
        public Prototype(string name, string sem, List<string> course, List<string> spec, int numLect,
            int numLabs, string ctrl, string lectName, string lectAud, string lectDep, string type)
        {
            Name = name;
            Semester = sem;
            Course = course;
            Speciality = spec;
            NumberOfLabs = numLabs;
            NumberOfLections = numLect;
            Control = ctrl;
            LectorName = lectName;
            LectorDepartment = lectDep;
            LectorAuditorium = lectAud;
            Type = type;
        }


        // абстрактный метод клонирования, который будем переопределять в наследуемых классах
        public abstract Prototype Clone();
    }



    // конкретный прототип дисциплины, созданный билдером. list - список всех билдеровских дисциплин напрямую из 
    // класса билдера, size - их кол-во (нужно для рандома).
    class PrototypeBuilder : Prototype
    {
        public static List<Discipline> listFromBuilder = Director.listOfDisciplinesBuilder;
        private int Size = listFromBuilder.Count;

        public PrototypeBuilder() { }

        public PrototypeBuilder(string name, string sem, List<string> course, List<string> spec, int numLect,
            int numLabs, string ctrl, string lectName, string lectAud, string lectDep, string type)
            : base(name, sem, course, spec, numLect, numLabs, ctrl, lectName, lectDep, lectAud, type) { }


        // метод клонирования дисциплины из билдера: берём рандомный элемент из
        // списка дисциплин, созданных билдером, и клонируем его:
        public override Prototype Clone()
        {
            Random random = new Random();
            int i = random.Next(0, Size);

            var prototypeBuilder = new PrototypeBuilder(listFromBuilder[i].Name, listFromBuilder[i].Semester,
                listFromBuilder[i].Course, listFromBuilder[i].Speciality, listFromBuilder[i].NumberOfLabs,
                listFromBuilder[i].NumberOfLections, listFromBuilder[i].Control, listFromBuilder[i].lector.Name,
                listFromBuilder[i].lector.Department, listFromBuilder[i].lector.Auditorium, listFromBuilder[i].Type);

            return prototypeBuilder;
        }


        public override string ToString()
        {
            string course = "";
            string speciality = "";
            foreach (string c in Course)
                course += c + "; ";
            foreach (string s in Speciality)
                speciality += s + "; ";

            string res = $"\t\t             PROTOTYPE (BUILDER)\n{Type}Название: {Name}\nКурс: {course}\nСеместр: {Semester}\n" +
                $"Специальность: {speciality}\nЧасов лекций: {NumberOfLections}\n" +
                $"Часов лабораторных: {NumberOfLabs}\nТип контроля: {Control}\n" +
                $"ФИО лектора: {LectorName}\nКафедра: {LectorDepartment}\n" +
                $"Аудитория: {LectorAuditorium}\n\n==============================================\n\n";
            return res;
        }
    }


    // реализация прототипа объекта дисциплины на основании абстрактной фабрики. все отличие заключается в том,
    // что мы создаем поле со списком List<DisciplineClient> - копией аналогичного листа с дисциплинами из класса 
    // фабрики, и в методе Clone() прописываем соответствующие пути к объекту для задания значений.
    class PrototypeAF : Prototype
    {
        public static List<DisciplineClient> listFromAF = AbstractFactory.listAF;
        public static int Size = AbstractFactory.listAF.Count;


        public PrototypeAF() { }

        public PrototypeAF(string name, string sem, List<string> course, List<string> spec, int numLect,
            int numLabs, string ctrl, string lectName, string lectAud, string lectDep, string type)
            : base(name, sem, course, spec, numLect, numLabs, ctrl, lectName, lectDep, lectAud, type) { }


        public override Prototype Clone()
        {
            Random random = new Random();
            int i = random.Next(0, Size);

            var prototypeAF = new PrototypeAF(listFromAF[i].discipline.Name, listFromAF[i].discipline.Semester,
                listFromAF[i].discipline.Course, listFromAF[i].discipline.Speciality, listFromAF[i].discipline.NumberOfLabs,
                listFromAF[i].discipline.NumberOfLections, listFromAF[i].discipline.Control, listFromAF[i].lector.Name,
                listFromAF[i].lector.Department, listFromAF[i].lector.Auditorium, listFromAF[i].discipline.Type);

            return prototypeAF;
        }


        public override string ToString()
        {
            string course = "";
            string speciality = "";
            foreach (string c in Course)
                course += c + "; ";
            foreach (string s in Speciality)
                speciality += s + "; ";

            string res = $"\t\t  PROTOTYPE (ABSTRACT FACTORY)\n{Type}Название: {Name}\nКурс: {course}\nСеместр: {Semester}\n" +
                $"Специальность: {speciality}\nЧасов лекций: {NumberOfLections}\n" +
                $"Часов лабораторных: {NumberOfLabs}\nТип контроля: {Control}\n" +
                $"ФИО лектора: {LectorName}\nКафедра: {LectorDepartment}\n" +
                $"Аудитория: {LectorAuditorium}\n\n==============================================\n\n";
            return res;
        }
    }
}
